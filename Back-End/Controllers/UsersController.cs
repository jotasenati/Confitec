using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using teste.Data;
using teste.Entites;

namespace teste.Controllers
{
    [DisableCors]
    [ApiController]
    [Route("v1/Users")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<UserEntity>>> Get([FromServices] UserContext context) 
        {
            var response = await context.Users.ToListAsync();

            return response != null
                ? Ok(response)
                : BadRequest();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<UserEntity>> GetById([FromServices] UserContext context, Guid id) 
        {
            var response = await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return response != null
                ? Ok(response)
                : BadRequest();
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<UserEntity>> Post([FromServices] UserContext context, [FromBody]UserEntity model)
        {
            if(ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();

                context.Users.Add(model);

                await  context.SaveChangesAsync();

                return Ok(model);
            }
            else
                return BadRequest();
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<ActionResult<bool>> Put([FromServices] UserContext context, [FromBody] UserEntity model, Guid id)
        {
            if(id == Guid.Empty || id == null)
                return BadRequest();

            if(ModelState.IsValid)
            {
                var userUpdate = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

                // userUpdate.Nome = model.Nome;
                // userUpdate.SobreNome = model.SobreNome;
                // userUpdate.Email = model.Email;
                // userUpdate.DataNascimento = model.DataNascimento;
                // userUpdate.Escolaridade = model.Escolaridade;

                context.Update(userUpdate);

                await  context.SaveChangesAsync();

                return Ok(userUpdate);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<ActionResult<bool>> Delete([FromServices] UserContext context, Guid id)
        {
             if(id == Guid.Empty || id == null)
                return BadRequest();

            var userDrop = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

            context.Remove(userDrop);

            return Ok(true);
        }
    }
}