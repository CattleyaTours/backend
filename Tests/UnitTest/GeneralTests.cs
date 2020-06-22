using Xunit;
using backend.Controllers;
using System;
using backend.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Seeders;

namespace backend.Tests
{
    public class ReservaControllerTest
    {
        [Fact(DisplayName = "String comparison test")]
        public void ReservaTest()
        {
            //Given
            Assert.Equal("hola", "hola");
            //When

            //Then
        }

        [Fact(DisplayName = "Test GetReserva")]
        public void GetReservaObject_Test()
        {
            using (var context = new CattleyaToursContext(TestBootstrapper.GetInMemoryDbContextOptions("testDb")))
            {
                //Arrange
                var controller = new ReservaController(context);

                //Act
                var result = controller.GetReserva().ToString();
                var two = controller.GetReserva();

                //Assert
                Assert.IsNotType<OkObjectResult>(result);
                Assert.IsType<string>(result);
                Assert.IsType<ActionResult<IEnumerable<Reserva>>>(two.Result);
            }
            /*
             // Arrange
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            var controller = new IdeasController(mockRepo.Object);
            var nonExistentSessionId = 999;

            // Act
            var result = await controller.ForSessionActionResult(nonExistentSessionId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<List<IdeaDTO>>>(result);
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
            */
        }
  
        [Fact(DisplayName = "Test Action Result")]
        public async Task ConfirmActionResult_DelteReserva_TestAsync()
        {
            using (var context = new CattleyaToursContext(TestBootstrapper.GetInMemoryDbContextOptions("testDb")))
            {   
                
                //Arrange
                var controller = new ReservaController(context);
                var inexistentUsuarioId = 999;
                var inexistentPublicacionId = 999;

                //Act
                var result = await controller.DeleteReserva(inexistentUsuarioId, inexistentPublicacionId);
                
                //Assert
                    //The first test confirms that the controller returns an ActionResult but not a nonexistent list of ideas for a nonexistent session id
                        //- The ActionResult type is ActionResult<<Reserva>>.
                        //-The Result is a NotFoundResult.
        
                    //For a valid session id's, the second test confirms that the method returns:
                        //-An ActionResult with a List<IdeaDTO> type.
                        //-The ActionResult<T>.Value is a List<IdeaDTO> type.
                        //-The first item in the list is a valid idea matching the idea stored in the mock session (obtained by calling GetTestSession).
                var actionResult = Assert.IsType<ActionResult<Reserva>>(result);
                Assert.IsType<NotFoundResult>(actionResult.Result);
            }
        }

        [Theory(DisplayName = "Data test")]
        [InlineData(1, 2, 3)]
        [InlineData(2, 2, 3)]
        public void SumTest(int first, int second, int sum)
        {
            //Arrange and Act
            var result = first + second;

            //Assert
            Assert.Equal(result, sum);
        }

        [Theory(DisplayName = "Delete reserva test")]
        [InlineData(4, 1)]
        [InlineData(1, 2)]
        public async Task RemoveReserva_TestAsync(int usuarioId, int publicacionId)
        {
            using (var context = new CattleyaToursContext(TestBootstrapper.GetInMemoryDbContextOptions("testDb")))
            {
                //Arrange
                var controller = new ReservaController(context);

                //Act
                ActionResult<Reserva> actionResult = await controller.DeleteReserva(usuarioId, publicacionId);

                //Assert
                //Assert.NotNull(actionResult);
                Assert.Null(actionResult.Result);
                //Assert.IsType<NotFoundResult>(actionResult.Result);
            }
        }
    }
}
