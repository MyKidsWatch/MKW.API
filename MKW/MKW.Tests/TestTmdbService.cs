namespace MKW.Tests;

using System.Net.Http.Json;
using System.ComponentModel;
using Microsoft.Extensions.Configuration;

using Xunit;

using MKW.Services.BaseServices;

public class TestTmdbService
{
    [Fact]
    public async void GetMovie()
    {

	HttpClient client = new HttpClient();

	IConfiguration config = new ConfigurationBuilder()
	  .AddJsonFile("../MKW.API/appsettings.Development.json")
	  .AddEnvironmentVariables()
	  .Build();

	TmdbService service = new TmdbService(client, config);

	var res = await service.GetMovie(550);

        Assert.Equal(res.GetProperty("original_title"), "Fight Club");
    }
}
