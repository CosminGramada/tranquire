﻿using OpenQA.Selenium;
using Tranquire.Selenium.Actions;
using Xunit;

namespace Tranquire.Selenium.Tests.Actions
{
    public class UsingIFrameTests : WebDriverTest
    {
        public UsingIFrameTests(WebDriverFixture fixture) : base(fixture, "PageWithIFrame.html")
        {
        }

        [Fact]
        public void UsingIFrame_ShouldAllowToReachElementsInIFrame()
        {
            //arrange
            var iframe = Target.The("iframe").LocatedBy(By.Id("IFrame"));
            var expectedElement = Target.The("element in iframe").LocatedBy(By.Id("ElementInIFrame"));
            //act
            using (Fixture.Actor.When(UsingIFrame.LocatedBy(iframe)))
            {
                var element = expectedElement.ResolveFor(Fixture.WebDriver);
                //assert
                Assert.NotNull(element);
            }
        }

        [Fact]
        public void UsingIFrame_WhenDisposed_ShouldAllowToReachElementsOutsideIFrame()
        {
            //arrange
            var iframe = Target.The("iframe").LocatedBy(By.Id("IFrame"));
            var expectedElement = Target.The("element outside iframe").LocatedBy(By.Id("ElementOutsideIFrame"));
            //act
            Fixture.Actor.When(UsingIFrame.LocatedBy(iframe)).Dispose();
            var element = expectedElement.ResolveFor(Fixture.WebDriver);
            //assert
            Assert.NotNull(element);
        }
    }
}
