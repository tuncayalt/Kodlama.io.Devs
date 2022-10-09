using Application.Features.OperationClaims.Models;
using Application.Features.OperationClaims.Queries.GetListOperationClaim;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {
        public OperationClaimsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListOperationClaimQuery getListOperationClaimQuery = new() { PageRequest = pageRequest };
            GetListOperationClaimsModel result = await _mediator!.Send(getListOperationClaimQuery);
            return Ok(result);
        }
    }
}
