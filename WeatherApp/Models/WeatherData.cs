namespace WeatherApp.Models
{
    public class WeatherData
    {
        public string Name { get; set; }
        public MainData Main{ get; set; }
        public string Weather { get; set; }
    }

    public class MainData
    {
        public double Temp { get; set; }
    }
}
