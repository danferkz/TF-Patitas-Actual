using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PATITAS.Controllers;
using PATITAS.Datos;
using PATITAS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TestPatitasXunit
{
    public class MascotaControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewWithListOfMascotas()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MascotaIndexDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                dbContext.Mascota.AddRange(new List<Mascota> { new Mascota(), new Mascota() });
                dbContext.SaveChanges();

                var controller = new MascotaController(dbContext);

                // Act
                var result = await controller.Index();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<List<Mascota>>(viewResult.ViewData.Model);
                Assert.Equal(2, model.Count);
            }
        }

        [Fact]
        public void Crear_Get_ReturnsViewWithViewModel()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "CrearMascotaGetDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var controller = new MascotaController(dbContext);

                // Act
                var result = controller.Crear() as ViewResult;

                // Assert
                Assert.NotNull(result);
                Assert.IsType<ClienteMascotaVM>(result.Model);

                // Additional assertions for the view model, if needed
                var viewModel = Assert.IsType<ClienteMascotaVM>(result.Model);
                Assert.NotNull(viewModel.ListaClientes);
            }
        }

        [Fact]
        public void Crear_Post_RedirectsToIndexOnSuccess()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "CrearMascotaPostDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var controller = new MascotaController(dbContext);
                var mascota = new Mascota { /* Initialize mascota properties */ };

                // Act
                var result = controller.Crear(mascota);

                // Assert
                var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
                Assert.Equal("Index", redirectToActionResult.ActionName);
            }
        }

        // Add more tests as needed for Editar, Borrar, Descripcion, AgregarDescripcion actions
    }
}
