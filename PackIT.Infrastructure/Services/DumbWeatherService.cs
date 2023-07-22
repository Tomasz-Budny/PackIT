using PackIT.Application.DTO.External;
using PackIT.Application.Services;
using PackIT.Domain.ValueObjects;

namespace PackIT.Infrastructure.Services
{
    internal sealed class DumbWeatherService : IWeatherService
    {
        public Task<WeatherDTO> GetWeatherAync(Localization localization)
        {
            return Task.FromResult(new WeatherDTO(new Random().Next(5, 30)));
        }
    }
}
