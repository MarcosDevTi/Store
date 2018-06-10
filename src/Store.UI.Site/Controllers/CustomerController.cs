using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Store.Application.ModelsCqrs;

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
            return View(await _mediator.Send(new GetCustomerById(id)));
        }
    }
}
