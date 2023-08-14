using API.Models;
using API.Utilities.Enums;

namespace API.DTOs.Bookings;

public class DetailBookingDto
{
    public Guid BookingGuid { get; set; }
    public string BookedNik { get; set; }
    public string BookedBy { get; set; }
    public string RoomName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public StatusLevel Status { get; set; }
    public string Remarks { get; set; }
}