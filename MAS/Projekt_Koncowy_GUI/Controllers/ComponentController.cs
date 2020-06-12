using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_Koncowy_GUI.Models;

namespace Projekt_Koncowy_GUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        private readonly LocalContext _context;

        public ComponentController(LocalContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id, int amount)
        {
            return Ok(await _context.Components.AnyAsync(comp => comp.Identifier == id && comp.AvailableAmount >= amount));
        }
    }

}