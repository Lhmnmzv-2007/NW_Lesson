using ChatServer.Repo;
using System.Net;
using System.Net.Sockets;

namespace ChatServer;

class Program
{
    static void Main()
    {
        Repository repo = new Repository();

        var ip = IPAddress.Parse("10.103.154.223");
        var port = 27001;

        var listener = new TcpListener(ip, port);
        listener.Start();

        Console.WriteLine("Server ise dusdu...");

        while (true)
        {
            var client = listener.AcceptTcpClient();
            Console.WriteLine("Yeni client geldi");

            Task.Run(() =>
            {
                try
                {
                    var stream = client.GetStream();
                    var br = new BinaryReader(stream);
                    var bw = new BinaryWriter(stream);

                    while (true)
                    {
                        string method = br.ReadString();

                        if (method == "GET")
                        {
                            string idStr = br.ReadString();
                            int id = int.Parse(idStr);

                            if (id == 0)
                            {
                                var cars = repo.GetAll();
                                bw.Write(cars.Count.ToString());

                                foreach (var c in cars)
                                {
                                    WriteCar(bw, c);
                                }
                            }
                            else
                            {
                                var car = repo.GetById(id);
                                if (car == null)
                                {
                                    bw.Write("0");
                                }
                                else
                                {
                                    bw.Write("1");
                                    WriteCar(bw, car);
                                }
                            }
                        }
                        else if (method == "POST")
                        {
                            Car car = ReadCar(br);

                            var all = repo.GetAll();
                            car.Id = all.Count > 0 ? all.Max(x => x.Id) + 1 : 1;

                            repo.Add(car);
                            bw.Write("OK");
                        }
                        else if (method == "PUT")
                        {
                            Car car = ReadCar(br);
                            bool ok = repo.Update(car);
                            bw.Write(ok ? "OK" : "ERROR");
                        }
                        else if (method == "DELETE")
                        {
                            string idStr = br.ReadString();
                            int id = int.Parse(idStr);

                            bool ok = repo.Delete(id);
                            bw.Write(ok ? "OK" : "ERROR");
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Client cixdi");
                }
            });
        }
    }

    static Car ReadCar(BinaryReader br)
    {
        return new Car
        {
            Id = int.Parse(br.ReadString()),
            Make = br.ReadString(),
            Model = br.ReadString(),
            Year = br.ReadString(),
            VIN = br.ReadString(),
            Color = br.ReadString()
        };
    }

    static void WriteCar(BinaryWriter bw, Car c)
    {
        bw.Write(c.Id.ToString());
        bw.Write(c.Make);
        bw.Write(c.Model);
        bw.Write(c.Year);
        bw.Write(c.VIN);
        bw.Write(c.Color);
    }
}