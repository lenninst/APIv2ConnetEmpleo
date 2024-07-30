using ConnetEmpleo.Aplication.Commons.Base;
using ConnetEmpleo.Aplication.Dtos.Request;

namespace ConnetEmpleo.Aplication.Interface
{
    public interface IPostulacionAplication
   {
      Task<BaseResponse<bool>> AddPostulacion(PostulacionRequestDto postulacionRequestDto);

   }
}
