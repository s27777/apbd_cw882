using Microsoft.Data.SqlClient;
using Tutorial8.Models.DTOs;

namespace Tutorial8.Services;

public class DbService : IDbService
{
    //private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=APBD;Integrated Security=True;";
    private readonly string _connectionString = "Data Source=db-mssql;Initial Catalog=s27777;Integrated Security=True;Trust Server Certificate=True;";
    
    
    public async Task<List<TripDTO>> GetTrips()
    {
        var trips = new List<TripDTO>();

        string command = @"SELECT IdTrip, Name, Description, DateFrom, DateTo, MaxPeople FROM Trip";
    
        using (SqlConnection conn = new SqlConnection(_connectionString))
        using (SqlCommand cmd = new SqlCommand(command, conn))
        {
            await conn.OpenAsync();

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var trip = new TripDTO
                    {
                        IdTrip = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        DateFrom = reader.GetDateTime(3),
                        DateTo = reader.GetDateTime(4),
                        MaxPeople = reader.GetInt32(5)
                    };
                    trips.Add(trip);
                }
            }
        }
        return trips;
    }
    
    public async Task<List<TripDTO>> GetClientTrips(int id)
    {
        var trips = new List<TripDTO>();

        string command = @"SELECT IdTrip, Name, Description, DateFrom, DateTo, MaxPeople FROM Trip
                            JOIN Client_Trip ON Trip.IdTrip = Client_Trip.IdTrip
                            JOIN Client ON Client.IdClient = Client_trip.IdClient";
    
        using (SqlConnection conn = new SqlConnection(_connectionString))
        using (SqlCommand cmd = new SqlCommand(command, conn))
        {
            await conn.OpenAsync();

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var trip = new TripDTO
                    {
                        IdTrip = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        DateFrom = reader.GetDateTime(3),
                        DateTo = reader.GetDateTime(4),
                        MaxPeople = reader.GetInt32(5)
                    };
                    trips.Add(trip);
                }
            }
        }

        return trips;
    }
    
    
    
}