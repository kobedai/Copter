﻿using System;
namespace Copter.Mapper
{
    internal class InternalJsonNetMapper:IMapper
    {
        public TTarget Map<TSource, TTarget>(TSource source) where TSource : class where TTarget : class
        {
            throw new NotImplementedException();
        }
    }
}
