using Microsoft.AspNetCore.Mvc;
using RentOfWorkshopAPI.Models;
using RentOfWorkshopAPI.Services;
using RentOfWorkshopsCore.DBConnection;
using RentOfWorkshopsCore.DBContext;
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

        [HttpPost]
        public IActionResult Post(Space space)
        {
            SpaceService.Add(space);
            return CreatedAtAction(nameof(Post), new { id = space.Id }, space);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var space = SpaceService.GetSpace(id);

            if (space == null)
                return NotFound();
            SpaceService.Delete(id);

            return NoContent();
        }

        [HttpPut]
        public IActionResult Update(int id, Space space)
        {
            if (id != space.Id)
                return BadRequest();

            var currentSpace = SpaceService.GetSpace(id);
            if (currentSpace == null)
                return NotFound();

            SpaceService.Update(id, space);

            return NoContent();
        }
    }
}
