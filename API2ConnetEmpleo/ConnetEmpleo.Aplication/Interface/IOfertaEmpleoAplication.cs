using ConnetEmpleo.Aplication.Commons.Base;
using ConnetEmpleo.Aplication.Dtos.Request;

namespace ConnetEmpleo.Aplication.Interface
{
   public interface IOfertaEmpleoAplication
   {
      Task<BaseResponse<bool>> AddOfertaEmpleoWhitEmpresaId(int id,
       OfertaEmpleoRequestDto ofertaEmpleoResquestDto);

   }
}
