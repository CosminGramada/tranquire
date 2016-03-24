﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranquire
{
    internal static class Guard
    {
        public static void ForNull<T>(T value, string name)
        {
            if(value == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
