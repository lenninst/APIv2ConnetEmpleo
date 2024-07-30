using FluentValidation.Results;

namespace ConnetEmpleo.Aplication.Commons.Base
{
   public class BaseResponse<T>
   {
      public bool IsSuccess { get; set; }
      public T? Data { get; set; }
      public string? Message { get; set; }
      public string? Token { get; set; }
      public IEnumerable<ValidationFailure>? Errors { get; set; }
   }
}
