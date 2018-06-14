using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.ModelsCqrs;
using Store.Application.ModelsCqrs.Commands;
using Store.Domain.Entities;
using Store.DomainShared.Notifications;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.UI.Site.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator, INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _mediator = mediator;
        }

        //[ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60)]
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? page
            )
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            Expression<Func<Customer, bool>> predicate = x => x.Name.FirstName.Contains(searchString ?? "");

            return View(await _mediator.Send(new GetAllCustomers(sortOrder, predicate)));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            return View(await _mediator.Send(new GetCustomerDetailsById(id)));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterNewCustomer customerViewModel)
        {
            if (!ModelState.IsValid) return View(customerViewModel);
            await _mediator.Send(customerViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Customer Registered!";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (!id.HasValue) return NotFound();
            var customerV = await _mediator.Send(new GetCustomerDetailsById(id.Value));

            if (customerV == null) return NotFound();
            return View(customerV);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _mediator.Send(new RemoveCustomer(id));
            return RedirectToAction("Index");
        }
    }
}
