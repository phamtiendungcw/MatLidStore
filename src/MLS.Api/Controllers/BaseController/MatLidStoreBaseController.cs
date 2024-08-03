using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MLS.Api.Controllers.BaseController;

[Route("MatLidStoreApi/[controller]")]
[ApiController]
[AllowAnonymous]
public class MatLidStoreBaseController : ControllerBase
{
}