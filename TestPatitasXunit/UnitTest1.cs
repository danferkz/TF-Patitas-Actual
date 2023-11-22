using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PATITAS.Controllers;
using PATITAS.Datos;
using PATITAS.Models;
using Xunit;

namespace TestPatitasXunit
{
    public class CitaControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewWithListOfCitas()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "BDPatitasTF")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                // Adding varied data types for testing
                dbContext.Cita.AddRange(new List<Cita> {
                    new Cita { Cita_Id = 1, Fecha = DateTime.Now, Costo = 50.0, Mascota_Id = 1 },
                    new Cita { Cita_Id = 2, Fecha = DateTime.Now.AddDays(1), Costo = 75.0, Mascota_Id = 2 }
                });
                dbContext.SaveChanges();

                var controller = new CitaController(dbContext);

                // Act
                var result = await controller.Index();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<List<Cita>>(viewResult.ViewData.Model);
                Assert.Equal(2, model.Count);

                // Additional assertions for varied data types
                Assert.True(model.All(c => c.Fecha != default(DateTime)));
                Assert.True(model.All(c => c.Costo > 0));
            }
        }

        [Fact]
        public void Crear_Get_ReturnsViewWithViewModel()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "BDPatitasTF")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var controller = new CitaController(dbContext);

                // Act
                var result = controller.Crear() as ViewResult;

                // Assert
                Assert.NotNull(result);
                Assert.IsType<CitaMascotaTrabajadorVM>(result.Model);

                // Additional assertions for varied data types in the view model
                var viewModel = Assert.IsType<CitaMascotaTrabajadorVM>(result.Model);
                Assert.NotNull(viewModel.ListaMascota);
                Assert.True(viewModel.ListaMascota.All(item => item.Value != null && item.Text != null));
            }
        }

        [Fact]
        public void Crear_Post_RedirectsToIndexOnSuccess()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "BDPatitasTF")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var controller = new CitaController(dbContext);
                var cita = new Cita { Cita_Id = 3, Fecha = DateTime.Now.AddDays(2), Costo = 60.0, Mascota_Id = 3 };

                // Act
                var result = controller.Crear(cita);

                // Assert
                var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
                Assert.Equal("Index", redirectToActionResult.ActionName);
            }
        }
    }
}
