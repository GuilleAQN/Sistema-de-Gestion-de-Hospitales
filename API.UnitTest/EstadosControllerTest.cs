﻿using API.UnitTest;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Gestion_de_Hospitales.API.Controller;
using Sistema_de_Gestion_de_Hospitales.API.Data;

namespace Sistema_de_Gestion_de_Hospitales.API.UnitTest
{
    public class EstadosControllerTest
    {
        private EstadosController _controller;
        private DbTestFixture<SistemaHospitalDbContext> _fixture;

        public EstadosControllerTest()
        {
            _fixture = new DbTestFixture<SistemaHospitalDbContext>();
            _controller = new EstadosController(_fixture.Context, _fixture.Mapper);
        }

        [Fact]
        public void Setup()
        {
            SeedDataTest.SeedData(_fixture.Context);
        }

        [Fact]
        public async Task GetEstados_ReturnsOkResult()
        {
            Setup();
            // Act
            var result = await _controller.GetEstados();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
