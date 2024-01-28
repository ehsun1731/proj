
 class Seat
{
    

    public int SeatNumber { get; set; }
    public SeatStatus Status { get; set; }

    public Seat(int seatNumber)
    {
        SeatNumber = seatNumber;
        Status = SeatStatus.Empty;
        
    }

    
}
enum SeatStatus
{
    Empty,
    Reserved,
    Purchased
}

