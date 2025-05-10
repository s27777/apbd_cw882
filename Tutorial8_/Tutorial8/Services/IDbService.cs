using Tutorial8.Models.DTOs;

namespace Tutorial8.Services;

public interface IDbService
{
    Task<List<TripDTO>> GetTrips();
    Task<List<TripDTO>> GetClientTrips(int id);
}