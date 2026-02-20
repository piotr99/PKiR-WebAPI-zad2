namespace Lab1;

public interface ITemperatureService
{
    string GetTempForCity(int cityId);
}
public interface IWindService
{
    string GetWindDirection();
}