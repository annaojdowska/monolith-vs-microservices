namespace MonolithicApp.Model
{
    public class Point
    {
        public Point(string name, double lat, double lon)
        {
            Name = name;
            Lat = lat;
            Lon = lon;
        }

        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}