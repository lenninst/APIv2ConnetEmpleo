using ConnetEmpleo.Aplication.Commons.Base;
using ConnetEmpleo.Aplication.Dtos.Request;
using ConnetEmpleo.Aplication.Dtos.Response;

namespace ConnetEmpleo.Aplication.Interface
{
   public interface IOfertaEmpleoAplication
   {
      Task<BaseResponse<bool>> AddOfertaEmpleoWhitEmpresaId(int id,
       OfertaEmpleoRequestDto ofertaEmpleoResquestDto);

      Task<BaseResponse<List<OfertasEmpleoResponseDto>>> getOfertas();

   }
}
