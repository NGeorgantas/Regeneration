using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Regeneration;
using Regeneration.Context;


namespace Regeneration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCreatorController : ControllerBase
    {

        private readonly MyContext _context;

        public ApiCreatorController(MyContext context)
        {
            _context = context;
        }


        [HttpGet,Route("FindAllCreator")]
        public List<Creator>? Get()
        {
            var creator = _context.Creators.ToList();
            if(creator == null)
            {
                return null;
            }
            return creator;
        }

        [HttpGet, Route("FindCreatorById/{id}")]
        public Creator? Get(int id)
        {
            var c = _context.Creators.Find(id);
            if (c == null)
            {
                return null;
            }
            return c;

        }

        [HttpPost, Route("AddCreator")]

        public Creator? Post(Creator creator)
        {           
            _context.Creators.Add(creator);
            _context.SaveChanges();           
            return creator;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var creator = _context.Creators.Find(id);
            if(creator == null)
            {
                return false;
            }
            _context.Remove(creator);
            _context.SaveChanges();
            return true;
        }

    }
}
