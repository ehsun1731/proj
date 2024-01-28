
  class Bus
{
    public string Name { get; set; }
    public BusType Type { get; set; }
    public List<Seat> Seats { get; set; }
    public List<Trip> Trips { get; set; }

    


    public Bus(string name, BusType type)
    {
        Name = name;
        Type = type;
        
        Trips = new List<Trip>();
        Seats = new List<Seat>();


        if (type == BusType.General)
        {
            for (int i = 1; i <= 44; i++)
            {
                AddSeat(i);
            }
        }
        else if (type == BusType.VIP)
        {
            for (int i = 1; i <= 30; i++)
            {
                AddSeat(i);
            }
        }
    }
    public void DisplayGeneralBusSeats()
    {
        

        int seatsPerRow = 4;

        for (int i = 0; i < Seats.Count; i++)
        {
            var seat = Seats[i];

            if (seat.Status == SeatStatus.Empty)
            {
                Console.Write($"{seat.SeatNumber} ");
            }
            else if (seat.Status == SeatStatus.Reserved)
            {
              
            }
            else if (seat.Status == SeatStatus.Purchased)
            {
                Console.Write("bb ");
            }

            if ((i + 1) % seatsPerRow == 0 && i != 0)
            {
                Console.WriteLine();
            }
        }

        Console.WriteLine();
    }
    public void DisplayVIPBusSeats()
    {
        Console.WriteLine($"وضعیت صندلی‌ها برای اتوبوس VIP '{Name}':");

        int seatsPerRow = 3;

        
        for (int i = 0; i < Seats.Count; i++)
        {
            var seat = Seats[i];
            
            if (seat.Status == SeatStatus.Empty)
            {
                Console.Write($"{seat.SeatNumber:D2} ");
            }
            else if (seat.Status == SeatStatus.Reserved)
            {
                string x = seat.SeatNumber.ToString();
                string myString = $"rr-{x}";
                Console.WriteLine(myString);
            }
            else if (seat.Status == SeatStatus.Purchased)
            {
                Console.Write("bb ");
            }

            if ((i + 1) % seatsPerRow == 0 && i != 0)
            {
                Console.WriteLine();
            }
        }

        Console.WriteLine();
    }

    public void AddSeat(int seatNumber)
    {
        Seats.Add(new Seat(seatNumber));
    }


    public void AddTrip(Trip trip)
    {
        Trips.Add(trip);
    }

    public void Cancel(int seatNumber)
    {
        var seat = Seats.Find(item => item.SeatNumber == seatNumber)!;

        seat.Status = SeatStatus.Empty;
        

    }

    public int EmptySeatCount()
    {
        return Seats.Count(item => item.Status == SeatStatus.Empty);
        
    }

    public int ReservationCount()
    {
        return BusStation.SeatStatusReservation.Count;

    }

    public int PurchaseCount()
    {
        return BusStation.SeatStatusPurchase.Count;
    }
}
enum BusType
{
    General=1,
    VIP=2
}

