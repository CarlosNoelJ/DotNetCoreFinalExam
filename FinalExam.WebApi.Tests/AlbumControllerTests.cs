using FinalExam.WebApi.Controllers;
using FinalExam.WebApi.Repository.MySql;
using FinalExam.WebApi.Tests.Builder.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace FinalExam.WebApi.Tests
{
    public class AlbumControllerTests
    {
        private readonly ChinookDbContextBuilder _builder;
        public AlbumControllerTests()
        {
            _builder = new ChinookDbContextBuilder();
        }

        [Fact]
        public async Task AlbumController_GetAlbums_Ok()
        {
            var db = _builder.ConfigureInMemory().AddTenAlbum().Build();

            var repository = new Repository<Models.Album>(db);
            var controller = new AlbumController(repository);

            var response = (await controller.GetAlbums()).Result as OkObjectResult;

            var values = response.Value as List<Models.Album>;

            values.Count.Should().Be(10);
        }
    }
}
