using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IMediator? _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected string? GetIpAddress()
        {
            const string ForwardedHeader = "X-Forwarded-For";

            if (Request.Headers.ContainsKey(ForwardedHeader))
            {
                return Request.Headers[ForwardedHeader];
            }

            return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
        }
    }
}
