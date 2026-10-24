public enum HttpMethods
{
    GET,
    POST,
    PUT,
    DELETE
}

public class Command
{
    public HttpMethods Method { get; set; }
    public Car Car { get; set; }
}

public class Car
{
    public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string Year { get; set; }
    public string VIN { get; set; }
    public string Color { get; set; }
}