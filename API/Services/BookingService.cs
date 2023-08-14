using API.Contracts;
using API.DTOs.Bookings;
using API.DTOs.Employees;
using API.DTOs.Rooms;
using API.Models;
using API.Utilities.Enums;

namespace API.Services;

public class BookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IRoomRepository _roomRepository;

    public BookingService(IBookingRepository bookingRepository, IRoomRepository roomRepository, IEmployeeRepository employeeRepository)
    {
        _bookingRepository = bookingRepository;
        _roomRepository = roomRepository;
        _employeeRepository = employeeRepository;
    }

    public IEnumerable<BookingDto> GetAll()
    {
        var bookings = _bookingRepository.GetAll();
        if (!bookings.Any())
        {
            return Enumerable.Empty<BookingDto>();
        }

        var bookingDtos = new List<BookingDto>();
        foreach (var booking in bookings)
        {
            bookingDtos.Add((BookingDto)booking);
        }

        return bookingDtos;
    }

    public BookingDto? GetByGuid(Guid guid)
    {
        var booking = _bookingRepository.GetByGuid(guid);
        if (booking is null)
        {
            return null;
        }

        return (BookingDto)booking;
    }

    public BookingDto? Create(NewBookingDto newBookingDto)
    {
        var booking = _bookingRepository.Create(newBookingDto);
        if (booking is null)
        {
            return null;
        }

        return (BookingDto)booking;
    }

    public int Update(BookingDto bookingDto)
    {
        var booking = _bookingRepository.GetByGuid(bookingDto.Guid);
        if (booking is null)
        {
            return -1;
        }

        Booking toUpdate = bookingDto;
        toUpdate.CreatedDate = booking.CreatedDate;
        var result = _bookingRepository.Update(toUpdate);
        return result ? 1 
            : 0;

    }

    public int Delete(Guid guid)
    {
        var booking = _bookingRepository.GetByGuid(guid);
        if (booking is null)
        {
            return -1;
        }

        var result = _bookingRepository.Delete(booking);
        return result ? 1 
            : 0;
    }

    public IEnumerable<DetailBookingDto> GetAllDetail()
    {
        var result = from booking in _bookingRepository.GetAll()
            join employee in _employeeRepository.GetAll() on booking.EmployeeGuid equals employee.Guid
            join room in _roomRepository.GetAll() on booking.RoomGuid equals room.Guid
            select new DetailBookingDto
            {
                BookingGuid = booking.Guid,
                BookedNik = employee.Nik,
                BookedBy = employee.FirstName + " " + employee.LastName,
                RoomName = room.Name,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                Status = booking.Status,
                Remarks = booking.Remarks
            };
        return result;
        
    }
    
    public DetailBookingDto? GetDetailBookingByGuid(Guid guid)
    {
        return GetAllDetail().SingleOrDefault(e => e.BookingGuid == guid);
    }
    
    public IEnumerable<RoomDto> FreeRoomsToday()
    { 
        List<RoomDto> roomDtos = new List<RoomDto>();
        var bookings = GetAll();
        var freeBookings = bookings.Where(b => b.Status == StatusLevel.Done);
        var freeBookingsToday = freeBookings.Where(b => b.EndDate<DateTime.Now);
         
        foreach (var booking in freeBookingsToday)
        { 
            var roomGuid = booking.RoomGuid;
            var room = _roomRepository.GetByGuid(roomGuid);
            RoomDto roomDto = new RoomDto()
            {
                Guid = roomGuid,
                Capacity = room.Capacity,
                Floor = room.Floor,
                Name = room.Name
            };
            roomDtos.Add(roomDto);
        }
         
        if (!roomDtos.Any())
        { 
            return null; // No free room today
        }
        return roomDtos; // free room today
    }
    
    public IEnumerable<BookingLengthDto> BookingLength()
    {
        List<BookingLengthDto> listBookingLength = new List<BookingLengthDto>();
        TimeSpan workingHour = new TimeSpan(8, 30, 0);
        var timeSpan = new TimeSpan();
        var bookings = GetAll();
        foreach (var booking in bookings)
        {
            var currentDate = booking.StartDate;
            var endDate = booking.EndDate;
            while (currentDate <= endDate)
            {
        // Memeriksa apakah hari saat ini adalah Sabtu atau Minggu
                if (currentDate.DayOfWeek != DayOfWeek.Saturday && 
                    currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
        // Hari kerja, menghitung waktu kerja dengan memperhitungkan jam
                    DateTime openRoom = currentDate.Date.AddHours(9); // Misalnya, waktu kerja dimulai pada pukul 09:00
                    DateTime closeRoom = currentDate.Date.AddHours(17).AddMinutes(30); // Misalnya, waktu kerja selesai pada pukul 17:30
                    TimeSpan dayTime = closeRoom - openRoom;
                    timeSpan += dayTime;
                }
                currentDate = currentDate.AddDays(1); // Pindah ke hari berikutnya
            }
            var room = _roomRepository.GetByGuid(booking.RoomGuid);
            var bookingLengthDto = new BookingLengthDto()
            {
                RoomGuid = booking.RoomGuid,
                RoomName = room.Name,
                BookingLength = timeSpan.TotalHours
            };
            listBookingLength.Add(bookingLengthDto);
        }
        if (!listBookingLength.Any())
        {
            return null;
        }
        return listBookingLength;
    }


}