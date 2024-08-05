using Kookis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kookis.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        public IPieRepository _pieRepository {  get; set; }
        public SearchController(IPieRepository pieRepository) 
        {
            _pieRepository = pieRepository;
        }


        [HttpGet]
        public IActionResult GetAll() 
        {
            
            
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            
        }
    }
}
