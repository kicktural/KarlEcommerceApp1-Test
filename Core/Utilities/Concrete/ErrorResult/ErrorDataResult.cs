﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Concrete.ErrorResult
{
    public class ErrorDataResult<T> : ResultData<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
        }


        public ErrorDataResult(string message) : base(default, false, message)
        {

        }
        public ErrorDataResult(T data) : base(data, false)
        {

        }
    }
}
