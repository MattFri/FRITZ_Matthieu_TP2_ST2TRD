using Newtonsoft.Json; 

namespace DataFeedAPITP2;

public class WeatherApp
{
    private HttpClient HttpClient { get; set; }
    private const string API_KEY = "d139c09a3de75bea703007eca5f55d60";

    public WeatherApp()
    {
        HttpClient = new HttpClient();
    }

    private Uri BuildUri(double lat, double lon)
    {
        return new Uri(
            $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={API_KEY}");
    }
    public async Task GetWeatherAtCoord(Coordinates coord)
    {
        var uri = BuildUri(coord.lat, coord.lon);
        Root deserializeObject = await Connect(uri);
        Console.WriteLine("The weather in {0} is {1}.",deserializeObject.sys.country,deserializeObject.weather[0].description);
    }

    public async Task PrintSun(Coordinates coord)
    {
        var uri = BuildUri(coord.lat, coord.lon);
        Root deserializeObject = await Connect(uri);
        DateTimeOffset sunrisetime = DateTimeOffset.FromUnixTimeSeconds(deserializeObject.sys.sunrise);
        DateTimeOffset sunsetime = DateTimeOffset.FromUnixTimeSeconds(deserializeObject.sys.sunset);
        Console.WriteLine("The sunrise in {0} is at {1} and the sunset is at {2}.",deserializeObject.name,sunrisetime.TimeOfDay,sunsetime.TimeOfDay);
        
    }

    public async Task<int> GetHumidity(Coordinates coord)
    {
        var uri = BuildUri(coord.lat, coord.lon);
        Root deserializeObject = await Connect(uri);
        return deserializeObject.main.humidity; 
    }

    public async Task<int> GetPressure(Coordinates coord)
    {
        var uri = BuildUri(coord.lat, coord.lon);
        Root deserializeObject = await Connect(uri);
        return deserializeObject.main.pressure; 
    }

    public async Task GetTemp(Coordinates coord)
    {
        var uri = BuildUri(coord.lat, coord.lon);
        Root deserializeObject = await Connect(uri);
        var tempDegree = (Convert.ToDouble(deserializeObject.main.temp) - 273.15); 
        Console.WriteLine("The temperature in {0} is {1} °C.",deserializeObject.name,Math.Round(tempDegree));
    }

    public async Task<double> GetWind(Coordinates coord)
    {
        var uri = BuildUri(coord.lat, coord.lon);
        Root deserializeObject = await Connect(uri);
        Console.WriteLine("The Wind speed in {0} is {1} m/s.",deserializeObject.name,deserializeObject.wind.speed);
        return deserializeObject.wind.speed; 
    }

    public string GetHeavierWind(Dictionary<string, double> dico)
    {
        var SortedDict = from entry in dico orderby entry.Value ascending select entry;
        string last = SortedDict.Last().Key;
        return last; 
    }
    private async Task<Root> Connect(Uri uri)
    {
        Root deserializeObject = new Root(); 
        try
        {
            String responseBody = await HttpClient.GetStringAsync(uri);
            deserializeObject = JsonConvert.DeserializeObject<Root>(responseBody);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException caught ! ");
            Console.WriteLine("Message :{0} ",e.Message);
        }

        return deserializeObject;
    }
    
}