using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrfuAutumn.Application.Features.Customers;

namespace UrfuAutumn.Controllers;

[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly IMediator _mediator;

    public CustomerController(ILogger<CustomerController> logger, 
        IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost("create")]
    public IActionResult CreateCustomer([FromBody]CreateCustomerCommand command)
    {
        return Ok();
    }

    [HttpGet("getById")]
    public async Task<IActionResult> GetCustomer(GetCustomerQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        if (!result.IsSuccessfull)
        {
            return BadRequest(result.GetErrors().FirstOrDefault());
        }
        return Ok(result.Value);
    }
    
    [HttpGet("search")]
    public IActionResult SearchCustomers()
    {
        return Ok();
    }
}