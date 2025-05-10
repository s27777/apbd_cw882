using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Tutorial8.Services;

namespace Tutorial8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbController : ControllerBase
    {
        private readonly IDbService _dbService;

        public DbController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("/api/trips")]
        public async Task<IActionResult> GetTrips()
        {
            //await using var con = new SqlConnection(ConnectionString);
            var trips = await _dbService.GetTrips();
            return Ok(trips);
        }

        [HttpGet("/api/clients/{id}/trips")]
        public async Task<IActionResult> GetClientTrips(int id)
        {
             /*if (await DoesTripExist(id)){
              return NotFound();
             }
            var trip = await _tripsService GetTrip(id);*/
             
            var trips = await _dbService.GetClientTrips(id);
            return Ok(trips);
        }

        [HttpPost("/api/clients")]
        public async Task<IActionResult> AddClient()
        {
            return Ok();
        }

        [HttpPut("/api/clients/{id}/trips/{tripId}")]
        public async Task<IActionResult> RegisterClientToTrip()
        {
            return Ok();
        }

        [HttpDelete("/api/clients/{id}/trips/{tripId}")]
        public async Task<IActionResult> RemoveClientFromTrip()
        {
            return Ok();
        }
    }
}
