using ConnetEmpleo.Aplication.Commons.Base;
using ConnetEmpleo.Aplication.Dtos.Request;

namespace ConnetEmpleo.Aplication.Interface
{
   public interface IUserAplication
   {
      Task<BaseResponse<bool>> AddUserAsync(UserRequestDto userRequestDto);
   }
}
