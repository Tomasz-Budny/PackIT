using PackIT.Application.DTO.External;
using PackIT.Domain.ValueObjects;

namespace PackIT.Application.Services
{
    public interface IWeatherService
    {
        Task<WeatherDTO> GetWeatherAync(Localization localization);
    }
}
