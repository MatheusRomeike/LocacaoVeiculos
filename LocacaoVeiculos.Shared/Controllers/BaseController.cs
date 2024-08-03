using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LocacaoVeiculos.Shared.Controllers
{
    public class BaseController : ControllerBase
    {
        public int LoggedUserId
        {
            get
            {
                var idClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                if (idClaim == null)
                {
                    throw new UnauthorizedAccessException("User ID claim not found");
                }
                return int.Parse(idClaim.Value);
            }
        }
    }
}
