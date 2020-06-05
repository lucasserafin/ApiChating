using ApiChating.WebApi.Data;
using ApiChating.WebApi.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiChating.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalasDeChatController : ControllerBase
    {
        private readonly ApiContext context;

        public SalasDeChatController(ApiContext context)
        {
            this.context = context;
        }



        [HttpGet]
        public ActionResult<IEnumerable<SalaChat>> Get()
        {
            return context.SalasDeChat.ToList();

        }
        [HttpGet("{id}", Name = "ObtenersalachatPorId")]
        public ActionResult<SalaChat> Get(int id)
        {
            var salachat = context.SalasDeChat.FirstOrDefault(p => p.Id == id);
            if (salachat == null)
            {
                return NotFound();
            }
            return salachat;
        }


        [HttpPost]
        public ActionResult<SalaChat> Post([FromBody]SalaChat salachat)
        {
            context.SalasDeChat.Add(salachat);
            context.SaveChanges();
            //return salachat;
            return new CreatedAtRouteResult("ObtenerSalachatPorId", new { Id = salachat.Id }, salachat);
        }

        [HttpPut("{id}")]
        public ActionResult<SalaChat> Put(int id, [FromBody]SalaChat salachat)
        {
            if (id != salachat.Id)
            {
                return BadRequest();
            }
            context.Entry(salachat).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult<SalaChat> Delete(int id)
        {
            var salachat = context.SalasDeChat.FirstOrDefault(p => p.Id == id);
            if (salachat == null)
            {
                return NotFound();
            }
            context.SalasDeChat.Remove(salachat);
            context.SaveChanges();
            return Ok();
        }

    }
}
