
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using Microsoft.Extensions.Logging;
using Xunit;

namespace backend.Controllers
{
    public class ReservaControllerTest : ControllerBase
    {
        ReservaController _reserva;
        CattleyaToursContext _context;
        ILogger<ReservaController> _logger;

        public ReservaControllerTest()
        {
            _reserva = new ReservaController(_context, _logger);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsActionResult()
        {
            //Act
            var res = _reserva.GetReserva();

            //Assert
            Assert.IsType<NotFoundObjectResult>(res.Result);
        }
    }
}
