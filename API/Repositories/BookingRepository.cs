using API.Contracts;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class BookingRepository : GeneralRepository<Booking>,IBookingRepository
{
    public BookingRepository(BookingDbContext context) : base(context) { }
}