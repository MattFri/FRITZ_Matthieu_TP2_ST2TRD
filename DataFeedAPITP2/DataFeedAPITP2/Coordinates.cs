namespace DataFeedAPITP2;

public class Coordinates
{ 
        public double lon { get; set; }
        public double lat { get; set; }

        public Coordinates(double longitude, double latitude)
        {
                lon = longitude;
                lat = latitude; 
        }
}