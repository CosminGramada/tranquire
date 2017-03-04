﻿using System;
using FluentAssertions;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Idioms;
using Tranquire.Extensions;
using Xunit;

namespace Tranquire.Tests.Extensions
{
    public interface IFunc
    {
        T Func<T1, T>(T1 value);
    }
}
