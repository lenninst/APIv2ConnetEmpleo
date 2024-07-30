using ConnetEmpleo.Aplication.Dtos.Request;
using ConnetEmpleo.Aplication.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ConnectEmpleo.API.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class UserController : ControllerBase
   {
      private readonly IUserAplication _userAplication;

        public UserController(IUserAplication   userAplication)
        {
         _userAplication = userAplication;
        }

      [HttpPost("register")]
      public async Task<IActionResult> Register(UserRequestDto userRequestDto)
      {
         var response = await _userAplication.AddUserAsync(userRequestDto);
         if (response.IsSuccess)
         {
            return Ok(response);
         }
         else
         {
            return BadRequest(response);
         }
      }


    }
}
