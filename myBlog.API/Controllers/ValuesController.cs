using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myBlog.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace myBlog.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {

        private readonly DataContext context;
        public ValuesController(DataContext context){
            this.context = context;
        }

        //GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues(){
            var values = await this.context.Values.ToListAsync(); 
            return Ok(values);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id){
            var value = await this.context.Values.FirstOrDefaultAsync(x => x.Id == id); 
            return Ok(value);
        }

        //POST
        [HttpPost]
        public void Post([FromBody] string value){
            context.AddAsync(value);
        }

        //PUT 
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value){
        }

        //DELETE 
        [HttpDelete("{id}")]
        public void Delete(int id){
            
        }
    }

}
