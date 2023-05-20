using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoteApp.Controllers;
using Xunit;

namespace NoteApp.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_RedirectsToDashboard()
        {
            var fakeLogger = A.Fake<ILogger<HomeController>>();
            var controller = new HomeController(fakeLogger);

            var result = controller.Index() as RedirectResult;

            Assert.NotNull(result);
            Assert.Equal("~/Dashboard", result.Url);
        }
    }
}
