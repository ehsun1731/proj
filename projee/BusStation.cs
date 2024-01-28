
using System.Xml.Linq;

static class BusStation
{
    public static List<Bus> buses = new();
    public static List<Seat> seats = new();
    public static List<int> SeatStatusReservation = new();
    public static List<int> SeatStatusPurchase = new();


    public static void ReserveSeat(int seatNumber)
    {
        var seat = seats.Find(item => item.SeatNumber == seatNumber)!;
        seat??= new Seat(seatNumber);
        seat.Status = SeatStatus.Reserved;
        SeatStatusReservation.Add(seatNumber);

    }
    public static void PurchaseSeat(int seatNumber)
    {
        var seat = seats.Find(item => item.SeatNumber == seatNumber)!;
        seat ??= new Seat(seatNumber);
        seat.Status = SeatStatus.Purchased;
        SeatStatusPurchase.Add(seatNumber);

    }

    public static void AddBus(string Name, BusType type)
    {
        var bus = new Bus(Name, type);

        buses.Add(bus);
    }

    public static Bus GetBus(string busName)
    {
        return buses.Find(item => item.Name == busName)!;
    }

    public static void DisplayBusList()
    {
        Console.WriteLine("Bus List:");
        foreach (var bus in buses)
        {
            Console.WriteLine($"- {bus.Name} ({bus.Type})");
        }
    }

    public static int GetInt(string message)
    {
        Console.Write(message);
        return Convert.ToInt32(Console.ReadLine());
    }

    public static string GetString(string message)
    {
        Console.Write(message);
        return Console.ReadLine()!;
    }
    
}
