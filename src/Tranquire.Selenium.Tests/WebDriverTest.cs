﻿using Xunit;

namespace Tranquire.Selenium.Tests
{
    public abstract class WebDriverTest : IClassFixture<WebDriverFixture>
    {
        protected readonly WebDriverFixture Fixture;

        protected WebDriverTest(WebDriverFixture fixture, string page)
        {
            fixture.NavigateTo(page);
            Fixture = fixture;
        }

        protected T Answer<T>(IQuestion<T> question)
        {
            return Fixture.Actor.AsksFor(question);
        }
    }
}
