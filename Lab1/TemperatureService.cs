namespace Lab1
{
    public class TemperatureService : ITemperatureService
    {
        // Usuwamy 'static' - teraz to normalna metoda instancyjna
        public string GetTempForCity(int cityId)
        {
            // Random.Shared jest bardziej wydajny w aplikacjach webowych
            int temp = Random.Shared.Next(-20, 40);
            return $"The current temperature for city {cityId} is {temp}°C.";
        }
    }
}