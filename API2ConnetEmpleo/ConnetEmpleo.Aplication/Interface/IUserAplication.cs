<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnetEmpleo.Aplication.Interface
{
   internal class IUserAplication
   {
=======
﻿using ConnetEmpleo.Aplication.Commons.Base;
using ConnetEmpleo.Aplication.Dtos.Request;

namespace ConnetEmpleo.Aplication.Interface
{
   public interface IUserAplication
   {
      Task<BaseResponse<bool>> AddUserAsync(UserRequestDto userRequestDto);
>>>>>>> 6a3194b (feat: agredado user register controller)
   }
}
