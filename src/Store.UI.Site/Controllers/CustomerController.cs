using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.ModelsCqrs;
using Store.Application.ModelsCqrs.Commands;
using System;
using System.Threading.Tasks;

namespace Store.UI.Site.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllCustomers()));
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
        public async Task<IActionResult> Create(CustomerCreate customerViewModel)
        {
            await _mediator.Send(customerViewModel);
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
