using API.Models;

namespace API.DTOs.Rooms;

public class NewRoomDto
{
    public string Name { get; set; }
    public int Floor { get; set; }
    public int Capacity { get; set; }

    public static implicit operator Room(NewRoomDto newRoomDto)
    {
        return new Room
        {
            Guid = new Guid(),
            Name = newRoomDto.Name,
            Floor = newRoomDto.Floor,
            Capacity = newRoomDto.Capacity,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };
    }

    public static explicit operator NewRoomDto(Room room)
    {
        return new NewRoomDto
        {
            Name = room.Name,
            Floor = room.Floor,
            Capacity = room.Capacity
        };
    }
}