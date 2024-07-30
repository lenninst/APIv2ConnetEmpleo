<<<<<<< HEAD
﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
﻿
using FluentValidation.Results;
>>>>>>> 6a3194b (feat: agredado user register controller)

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
