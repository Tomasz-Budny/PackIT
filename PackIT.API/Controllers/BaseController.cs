﻿using Microsoft.AspNetCore.Mvc;

namespace PackIT.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected ActionResult<TResult> OkOrNotFound<TResult>(TResult result) => result is null ? NotFound() : Ok(result);
    }
}
