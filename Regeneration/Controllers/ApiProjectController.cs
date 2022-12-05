using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Regeneration.Context;

namespace Regeneration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiProjectController : ControllerBase
    {

        private readonly MyContext _context;

        public ApiProjectController(MyContext context)
        {
            _context = context;
        }

        [HttpGet,Route("Search")]
        public List<Project>? Get()
        {
            return _context.Projects.ToList();
        }
        [HttpDelete,Route("DeleteProject/{id}")]
        public bool Delete(int id)
        {
            var find = _context.Projects.Find(id);
            if(find == null)
            {
                return false;
            }
            _context.Remove(find);
            _context.SaveChanges();
            return true;
        }



        [HttpGet, Route("SearchByCategory")]
        public List<Project>? GetCategory(string categoryname)
        {
            var project = (from p in _context.Category
                           join c in _context.Projects on p.Id equals c.CategoryId
                           where p.CategoryName == categoryname
                           select new Project(c.title,c.description,c.moneyCollected,c.price)
                           
   
    
                            ).ToList();
            return project;
        }

    }
}
