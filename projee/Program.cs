
bool exit = false;

while (!exit)
{

    int menu = BusStation.GetInt("0- EXIT\n" +
                         "1- Enter a Bus\n" +
                         "2- Enter a Travel\n" +
                         "3- Display Travels\n" +
                         "4- Reserve Ticket \n" +
                         "5- Purchase Ticket\n" +
                         "6- Cancel Ticket\n" +
                         "7- Travel Report ");

    switch (menu)
    {
        case 0:
            {
                exit = true;
                break;
            }
        case 1:
            {
                string busName = BusStation.GetString("Bus Name: ");
                BusType busType = (BusType)BusStation.GetInt("1 for General, 2 for VIP): ");

                
                BusStation.AddBus(busName,busType);

            }
            break;
        case 2:
            {
                string busName = BusStation.GetString("Enter Bus Name: ");
                var bus = BusStation.GetBus(busName);

                string origin = BusStation.GetString("Enter Origin: ");
                string destination = BusStation.GetString("Enter Destination: ");
                double price = Convert.ToDouble(BusStation.GetString("Enter Ticket Price: "));

                var trip = new Trip(origin, destination, price);
                bus.AddTrip(trip);


            }
            break;

        case 3:
            {
                bool exitt = false;

                while (!exitt)
                {
                    int option = BusStation.GetInt("1- Display Bus Details\n" +
                                                   "2- Display Seat Details");
                    switch (option)
                    {
                        case 1:
                            {
                                string busName = BusStation.GetString("Enter Bus Name: ");
                                var bus = BusStation.GetBus(busName);

                                Console.WriteLine($"Preview Trips for Bus '{busName}':");
                                foreach (var trip in bus.Trips)
                                {
                                    Console.WriteLine($"- From {trip.Origin} to {trip.Destination} - Price: {trip.Price}");
                                }

                                break;
                            }
                        case 2:
                            {
                                string busName = BusStation.GetString("Enter Bus Name: ");
                                var bus = BusStation.GetBus(busName);

                                int busType = (int)bus.Type;
                                switch (busType)
                                {
                                    case 1: // General Bus
                                        bus.DisplayGeneralBusSeats();
                                        break;
                                    case 2: // VIP Bus
                                        bus.DisplayVIPBusSeats();
                                        break;
                                    default:
                                        Console.WriteLine("Invalid Bus Type.");
                                        break;
                                }

                                exitt = true;
                                break;
                            }
                    }
                }

                break;
            }
        case 4:
            {
                string busName = BusStation.GetString("Enter Bus Name: ");
                var bus = BusStation.GetBus(busName);

                int seatNumberToReserve = BusStation.GetInt("Enter Seat Number to Reserve: ");
                BusStation.ReserveSeat(seatNumberToReserve);
                
                Console.WriteLine($"Seat {seatNumberToReserve} reserved for Bus '{busName}'.");

            }
            break;
        case 5:
            {
                string busName = BusStation.GetString("Enter Bus Name: ");
                var bus = BusStation.GetBus(busName);

                int seatNumberToPurchase = BusStation.GetInt("Enter Seat Number to Purchase: ");
                BusStation.PurchaseSeat(seatNumberToPurchase);
                Console.WriteLine($"Seat {seatNumberToPurchase} purchased for Bus '{busName}'.");
                
            }
            break;
        case 6:
            {
                string busName = BusStation.GetString("Enter Bus Name: ");
                var bus = BusStation.GetBus(busName);

                int seatNumberToCancel = BusStation.GetInt("Enter Seat Number to Cancel : ");

                bus.Cancel(seatNumberToCancel);
                Console.WriteLine($"Seat {seatNumberToCancel} canceled for Bus '{busName}'.");
            }
            break;
        case 7:
            {
                string busName = BusStation.GetString("Enter Bus Name: ");

                var bus = BusStation.GetBus(busName);


                int emptySeatCount = bus.EmptySeatCount();
                int ReservationCount = bus.ReservationCount();
                int PurchaseCount = bus.PurchaseCount();

                Console.WriteLine($"Trip Report for Bus '{busName}':");
                Console.WriteLine($"Empty Seats: {emptySeatCount}");
                Console.WriteLine($"Reservations: {ReservationCount}");
                Console.WriteLine($"Purchases: {PurchaseCount}");
            }
            break;


    }
}

