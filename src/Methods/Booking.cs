using System;

public class Booking
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int SpotId { get; set; }
    public DateTime BookingDate { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public decimal TotalPrice { get; set; }

}
