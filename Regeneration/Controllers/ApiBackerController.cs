using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Regeneration.Context;
using Regeneration.Models;

namespace Regeneration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBackerController : ControllerBase
    {
        private readonly MyContext _context;
        public ApiBackerController(MyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Backer> Get()
        {
            return _context.Backers.ToList();
        }

        [HttpPost,Route("AddBacker")]

        public Backer Post(Backer backer)
        {
            _context.Backers.Add(backer);
            _context.SaveChanges();
            return backer;
        }


    
    
    
    }
}
