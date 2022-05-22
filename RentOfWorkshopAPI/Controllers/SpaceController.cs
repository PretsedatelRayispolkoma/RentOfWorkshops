using Microsoft.AspNetCore.Mvc;
using RentOfWorkshopAPI.Models;
using RentOfWorkshopAPI.Services;
using RentOfWorkshopsCore.DBConnection;
using System.Collections.Generic;

namespace RentOfWorkshopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpaceController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<SpaceModel>> GetSpaces() => SpaceService.SpaceList;

        [HttpGet("{id}")]
        public ActionResult<SpaceModel> Get(int id)
        {
            var space = SpaceService.GetSpace(id);

            if (space == null)
                return NotFound();
            else
                return space;
        }
    }
}
