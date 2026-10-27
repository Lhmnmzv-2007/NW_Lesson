using System.Net.Sockets;

namespace ChatClient;

class Program
{
    static void Main()
    {
        var client = new TcpClient("10.103.154.223", 27001);
        var stream = client.GetStream();
        var br = new BinaryReader(stream);
        var bw = new BinaryWriter(stream);

        while (true)
        {
            Console.WriteLine("1 - Butun masinlar");
            Console.WriteLine("2 - Id ile getir");
            Console.WriteLine("3 - Yeni masin elave et");
            Console.WriteLine("4 - Yenile");
            Console.WriteLine("5 - Sil");
            Console.WriteLine("0 - Cix");
            Console.Write("Secim: ");

            string secim = Console.ReadLine();

            if (secim == "0") break;

            if (secim == "1")
            {
                bw.Write("GET");
                bw.Write("0");

                int say = int.Parse(br.ReadString());
                Console.WriteLine($"Cemi {say} masin:");

                for (int i = 0; i < say; i++)
                {
                    PrintCar(ReadCar(br));
                }
            }
            else if (secim == "2")
            {
                Console.Write("Id: ");
                string id = Console.ReadLine();

                bw.Write("GET");
                bw.Write(id);

                string varMi = br.ReadString();
                if (varMi == "0")
                    Console.WriteLine("Tapilmadi");
                else
                    PrintCar(ReadCar(br));
            }
            else if (secim == "3")
            {
                bw.Write("POST");
                WriteCar(bw, ReadCarFromConsole(false));
                Console.WriteLine(br.ReadString());
            }
            else if (secim == "4")
            {
                bw.Write("PUT");
                WriteCar(bw, ReadCarFromConsole(true));
                Console.WriteLine(br.ReadString());
            }
            else if (secim == "5")
            {
                Console.Write("Silinecek Id: ");
                string id = Console.ReadLine();

                bw.Write("DELETE");
                bw.Write(id);
                Console.WriteLine(br.ReadString());
            }
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

    static Car ReadCarFromConsole(bool withId)
    {
        var car = new Car();

        if (withId)
        {
            Console.Write("Id: ");
            car.Id = int.Parse(Console.ReadLine());
        }

        Console.Write("Make: ");
        car.Make = Console.ReadLine();
        Console.Write("Model: ");
        car.Model = Console.ReadLine();
        Console.Write("Year: ");
        car.Year = Console.ReadLine();
        Console.Write("VIN: ");
        car.VIN = Console.ReadLine();
        Console.Write("Color: ");
        car.Color = Console.ReadLine();

        return car;
    }

    static void PrintCar(Car c)
    {
        Console.WriteLine($"| Id: {c.Id} \n| {c.Make} {c.Model}\n| {c.Year} \n| {c.Color} \n| {c.VIN}\n\n");
    }
}