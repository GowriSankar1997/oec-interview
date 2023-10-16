using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using RL.Backend.Commands;
using RL.Backend.Commands.Handlers.Plans;
using RL.Backend.Models;
using RL.Data;
using RL.Data.DataModels;

namespace RL.Backend.Controllers;

[ApiController]
[Route("Plan")]
public class PlanController : ControllerBase
{
    private readonly ILogger<PlanController> _logger;
    private readonly RLContext _context;
    private readonly IMediator _mediator;

    public PlanController(ILogger<PlanController> logger, RLContext context, IMediator mediator)
    {
        _logger = logger;
        _context = context;
        _mediator = mediator;
    }

   
    [EnableQuery]
    public IEnumerable<Plan> Get()
    {
        return _context.Plans;
    }

    [HttpPost]
    
    public async Task<IActionResult> PostPlan([FromBody]CreatePlanCommand command, CancellationToken token)
    {
        var response = await _mediator.Send(command, token);

        return response.ToActionResult();
    }

    [HttpPost("AddProcedureToPlan")]
    public async Task<IActionResult> AddProcedureToPlan(AddProcedureToPlanCommand command, CancellationToken token)
    {
        var response = await _mediator.Send(command, token);

        return response.ToActionResult();
    }

    [HttpPost("AddUserToProcedure")]
    public async Task<IActionResult> AddUserToProcedure(AddUserToProcedureCommand command, CancellationToken token)
    {
        var response = await _mediator.Send(command, token);

        return response.ToActionResult();
    }
}
