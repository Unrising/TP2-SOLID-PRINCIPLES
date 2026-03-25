namespace HotelReservation.Infrastructure.Interfaces;

using HotelReservation.Domain.Models;

public interface IRoomRepository
{
    void SeedRooms(List<Room> rooms);
    Room? GetById(string roomId);
    List<Room> GetAvailableRooms(DateTime from, DateTime to);
    void Save(Room room);

}
