namespace Lab1
{
    public class WindService : IWindService
    {
        public string GetWindDirection()
        {
            // Losujemy kierunek wiatru z dostępnych wartości enum
            var directions = Enum.GetValues(typeof(Models.Enums.WindDirectionEnum));
            var randomDirection = (Models.Enums.WindDirectionEnum)directions.GetValue(Random.Shared.Next(directions.Length))!;
            return $"The current wind direction is {randomDirection}.";
        }
    }
}
