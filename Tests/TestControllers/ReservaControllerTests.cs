using Xunit;
using backend.Controllers;
using System;
using backend.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        
        //AAA Principle
        [Fact]
        public async Task AssertTypeRetrievedByGetReservas()
        {
            //Arrange
            ReservaController test = new ReservaController();
            
            //Act
            var comp = test.GetReserva();

            //Assert
            Assert.IsType<NotFoundObjectResult>(comp.Result);
        }

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
