using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookCart.API
{
    [ApiController]
    [Route("api/[controller]")]
    //TODO : Disabled authorization. Do app registarion and add config in appsettings.json in AzureAd section and enable this.
    //[Authorize]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender _mediator = null!;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}