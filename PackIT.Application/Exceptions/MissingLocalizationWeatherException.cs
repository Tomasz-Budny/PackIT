using PackIT.Domain.ValueObjects;
using PackIT.SharedAbstractions.Exceptions;

namespace PackIT.Application.Exceptions
{
    internal class MissingLocalizationWeatherException : PackItException
    {
        public MissingLocalizationWeatherException(Localization localization) : base($"Couldnt fetch weather data for localization {localization.Country}/{localization.City}")
        {
        }
    }
}
