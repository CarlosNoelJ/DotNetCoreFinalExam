using FinalExam.WebApi.Controllers;
using FinalExam.WebApi.Repository.MySql;
using FinalExam.WebApi.Tests.Builder.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using GenFu;

namespace FinalExam.WebApi.Tests
{
    public class ArtistControllerTests
    {
        private readonly ChinookDbContextBuilder _builder;

        public ArtistControllerTests()
        {
            _builder = new ChinookDbContextBuilder();
        }

        [Fact]
        public async Task ArtistController_GetArtist_Ok()
        {
            var db = _builder.ConfigureInMemory().AddTenArtist().Build();

            var repository = new Repository<Models.Artist>(db);
            var controller = new ArtistController(repository);

            var response = (await controller.GetArtists()).Result as OkObjectResult;

            var values = response.Value as List<Models.Artist>;

            values.Count.Should().Be(10);
        }
    }
}
