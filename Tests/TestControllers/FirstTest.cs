using Xunit;
using backend.Controllers;
using System;

namespace backend.Tests
{
    public class ReservaControllerTest{
        [Fact]
        public void ReservaTest()
        {
            //Given
            Assert.Equal("hola","hola");
            //When

            //Then
        }
        /*
        [Fact]
        public async Task AssertTypeRetrievedByGetReservas()
        {   
            //Act
            //var result = await Controllers.ReservaController.GetReservas();
            var controller = new ReservaController();
            var result = await controller.GetReserva();

            //Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Reserva>>>(result);
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }
        */
    }
}
