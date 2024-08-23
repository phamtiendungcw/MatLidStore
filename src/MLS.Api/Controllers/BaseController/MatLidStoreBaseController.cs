using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MLS.Api.Controllers.BaseController;

[Authorize]
[Route("MatLidStoreApi/[controller]")]
[ApiController]
public class MatLidStoreBaseController : ControllerBase
{
}