
namespace DataFeedAPITP2;

public class Program
{
    public static async Task Main(String[] args)
    {
        var WeatherApp = new WeatherApp();
        
        Console.WriteLine();
        Console.WriteLine("1. What's the weather like in Morocoo ? ");
        Console.WriteLine();
        var MoroccoCoord = new Coordinates(-7.092620, 31.791702);
        await WeatherApp.GetWeatherAtCoord(MoroccoCoord);
        Console.WriteLine();
        Console.WriteLine("2. When will the sun rise and set today in Oslo (in readable,UTC time) ?");
        Console.WriteLine();
        var Oslocoord = new Coordinates(10.752245, 59.913869);
        await WeatherApp.PrintSun(Oslocoord);
        Console.WriteLine();
        Console.WriteLine("3. What's the temperature in Jakarta (in Celsius) ?");
        Console.WriteLine();
        var Jakartacoord = new Coordinates(106.845599, -6.208763);
        await WeatherApp.GetTemp(Jakartacoord);
        Console.WriteLine();
        Console.WriteLine("4. Where is it more windy, New-York, Tokyo or Paris ? ");
        Console.WriteLine();
        var NYcoord = new Coordinates(-74.005941,40.712784);
        var NYwind = await WeatherApp.GetWind(NYcoord);
        var Tokyocoord = new Coordinates(139.69235,35.6894);
        var Tokyowind = await WeatherApp.GetWind(Tokyocoord);
        var Pariscoord = new Coordinates(2.352222,48.856614); 
        var Pariswind = await WeatherApp.GetWind(Pariscoord);

        Dictionary<string, double> winds = new Dictionary<string, double>();
        winds.Add("New-York",NYwind);
        winds.Add("Paris",Pariswind);
        winds.Add("Tokyo",Tokyowind);
        Console.WriteLine("The city where the wind is the heavier is : {0}.",WeatherApp.GetHeavierWind(winds));
        Console.WriteLine();

        Console.WriteLine("5. What is the humidity and pressure like in Kiev, Moscow and Berlin ?");
        Console.WriteLine();
        var Kievcoord = new Coordinates(30.523400, 50.450100);
        var Moscowcoord = new Coordinates(37.617300, 55.755826);
        var Berlincoord = new Coordinates(13.404954, 52.520007);

        var Kievhumidity = await WeatherApp.GetHumidity(Kievcoord);
        var Kievpressure = await WeatherApp.GetPressure(Kievcoord);
        Console.WriteLine("The humidity in Kiev is {0}% and the pressure is {1} hPa.",Kievhumidity,Kievpressure);

        var Moscowhumidity = await WeatherApp.GetHumidity(Moscowcoord);
        var Moscowpressure = await WeatherApp.GetPressure(Moscowcoord); 
        Console.WriteLine("The humidity in Moscow is {0}% and the pressure is {1} hPa.",Moscowhumidity,Moscowpressure);

        var Berlinhumidity = await WeatherApp.GetHumidity(Berlincoord);
        var Berlinpressure = await WeatherApp.GetPressure(Berlincoord); 
        Console.WriteLine("The humidity in Berlin is {0}%  and the pressure is {1} hPa.",Berlinhumidity,Berlinpressure);
    }
}