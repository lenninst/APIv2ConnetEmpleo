using ConnetEmpleo.Aplication.Commons.Base;
using ConnetEmpleo.Aplication.Dtos.Request;

namespace ConnetEmpleo.Aplication.Interface
{
   public interface IFormacionAcademicaAplication
   {
      Task<BaseResponse<bool>> AddFormacionAcademicaWithCandidatoId(int id, FormacionAcademicaRequestDto formacionAcademicaRequestDto);
   }
}
