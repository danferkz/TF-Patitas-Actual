using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PATITAS.Controllers;
using PATITAS.Datos;
using PATITAS.Models;
using Xunit;

namespace TestPatitasXunit
{
    public class ClienteControllerTests
    {
        [Fact]
        public void Index_ReturnsViewWithListOfClientes()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "BDPatitasTF")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                dbContext.Cliente.AddRange(new List<Cliente> { new Cliente { Cliente_Id = 1, NombreApellido = "Cliente1" }, new Cliente { Cliente_Id = 2, NombreApellido = "Cliente2" } });
                dbContext.SaveChanges();

                var controller = new ClienteController(dbContext);

                // Act
                var result = controller.Index();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<List<Cliente>>(viewResult.ViewData.Model);
                Assert.Equal(2, model.Count);
            }
        }

        [Fact]
        public void Crear_Get_ReturnsView()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "CrearGetDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var controller = new ClienteController(dbContext);

                // Act
                var result = controller.Crear() as ViewResult;

                // Assert
                Assert.NotNull(result);
            }
        }

        [Fact]
        public void Crear_Post_RedirectsToIndexOnSuccess()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "CrearPostDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var controller = new ClienteController(dbContext);
                var cliente = new Cliente { Cliente_Id = 3, NombreApellido = "Cliente3" };

                // Act
                var result = controller.Crear(cliente);

                // Assert
                var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
                Assert.Equal("Index", redirectToActionResult.ActionName);
            }
        }

        [Fact]
        public void Editar_Get_ReturnsViewWithCliente()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "EditarGetDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                dbContext.Cliente.Add(new Cliente { Cliente_Id = 1, NombreApellido = "Cliente1" });
                dbContext.SaveChanges();

                var controller = new ClienteController(dbContext);

                // Act
                var result = controller.Editar(1) as ViewResult;

                // Assert
                Assert.NotNull(result);
                var model = Assert.IsType<Cliente>(result.Model);
                Assert.Equal(1, model.Cliente_Id);
            }
        }

        [Fact]
        public void Editar_Post_RedirectsToIndexOnSuccess()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "EditarPostDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                dbContext.Cliente.Add(new Cliente { Cliente_Id = 1, NombreApellido = "Cliente1" });
                dbContext.SaveChanges();

                var controller = new ClienteController(dbContext);
                var cliente = new Cliente { Cliente_Id = 1, NombreApellido = "Cliente1_Modificado" };

                // Act
                var result = controller.Editar(cliente);

                // Assert
                var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
                Assert.Equal("Index", redirectToActionResult.ActionName);
            }
        }

        [Fact]
        public void Borrar_RedirectsToIndexOnSuccess()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "BorrarDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                dbContext.Cliente.Add(new Cliente { Cliente_Id = 1, NombreApellido = "Cliente1" });
                dbContext.SaveChanges();

                var controller = new ClienteController(dbContext);

                // Act
                var result = controller.Borrar(1);

                // Assert
                var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
                Assert.Equal("Index", redirectToActionResult.ActionName);
            }
        }
    }
}
