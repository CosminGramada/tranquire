﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranquire.Selenium.Targets
{
    public interface ITargetBuilder
    {
        ITarget LocatedBy(By by);
        ITargetWithParameters LocatedBy(string formatValue, Func<string, By> createBy);
    }
}
