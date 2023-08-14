using API.Contracts;
using API.DTOs.Rooms;
using API.Models;

namespace API.Services;

public class RoomService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IBookingRepository _bookingRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public RoomService(IRoomRepository roomRepository, IBookingRepository bookingRepository, IEmployeeRepository employeeRepository)
    {
        _roomRepository = roomRepository;
        _bookingRepository = bookingRepository;
        _employeeRepository = employeeRepository;
    }

    public IEnumerable<RoomDto> GetAll()
    {
        var rooms = _roomRepository.GetAll();
        if (!rooms.Any())
        {
            return Enumerable.Empty<RoomDto>();
        }

        var RoomDtos = new List<RoomDto>();
        foreach (var room in rooms)
        {
            RoomDtos.Add((RoomDto)room);
        }

        return RoomDtos;
    }

    public RoomDto? GetByGuid(Guid guid)
    {
        var room = _roomRepository.GetByGuid(guid);
        if (room is null)
        {
            return null;
        }

        return ((RoomDto)room);
    }

    public RoomDto? Create(NewRoomDto newRoomDto)
    {
        var room = _roomRepository.Create(newRoomDto);
        if (room is null)
        {
            return null;
        }

        return ((RoomDto)room);
    }

    public int Update(RoomDto RoomDto)
    {
        var room = _roomRepository.GetByGuid(RoomDto.Guid);
        if (room is null)
        {
            return -1;
        }

        Room toUpdate = RoomDto;
        toUpdate.CreatedDate = room.CreatedDate;
        var result = _roomRepository.Update(toUpdate);
        return result ? 1 
            : 0;
    }

    public int Delete(Guid guid)
    {
        var room = _roomRepository.GetByGuid(guid);
        if (room is null)
        {
            return -1;
        }

        var result = _roomRepository.Delete(room);
        return result ? 1
            : 0;
    }

    public IEnumerable<BookedRoomDto> GetRoom()
    {
        var today = DateTime.Today.ToString("dd-MM-yyyy");
        var book = _bookingRepository.GetAll().Where(b => b.StartDate.ToString("dd-MM-yyyy").Equals(today));

        if (!book.Any())
        {
            return null;
        }

        var bookToday = new List<BookedRoomDto>();

        foreach (var booking in book)
        {
            var employee = _employeeRepository.GetByGuid(booking.EmployeeGuid);
            var room = _roomRepository.GetByGuid(booking.RoomGuid);

            BookedRoomDto bookedRoomDto = new BookedRoomDto
            {
                BookingGuid = booking.Guid,
                RoomName = room.Name,
                Status = booking.Status,
                Floor = room.Floor,
                BookedBy = employee.FirstName + " " + employee.LastName
            };
            
            bookToday.Add(bookedRoomDto);
        }

        return bookToday;
    }
}