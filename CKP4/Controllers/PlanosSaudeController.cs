﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CKP4.Data;
using CKP4.Models;

namespace CKP4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanosSaudeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlanosSaudeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PlanosSaude
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanoSaude>>> GetPlanosSaude()
        {
            return await _context.PlanosSaude.ToListAsync();
        }

        // GET: api/PlanosSaude/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanoSaude>> GetPlanoSaude(int id)
        {
            var planoSaude = await _context.PlanosSaude.FindAsync(id);

            if (planoSaude == null)
            {
                return NotFound();
            }

            return planoSaude;
        }

        // PUT: api/PlanosSaude/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanoSaude(int id, PlanoSaude planoSaude)
        {
            if (id != planoSaude.Id)
            {
                return BadRequest();
            }

            _context.Entry(planoSaude).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanoSaudeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PlanosSaude
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlanoSaude>> PostPlanoSaude(PlanoSaude planoSaude)
        {
            _context.PlanosSaude.Add(planoSaude);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlanoSaude", new { id = planoSaude.Id }, planoSaude);
        }

        // DELETE: api/PlanosSaude/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanoSaude(int id)
        {
            var planoSaude = await _context.PlanosSaude.FindAsync(id);
            if (planoSaude == null)
            {
                return NotFound();
            }

            _context.PlanosSaude.Remove(planoSaude);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlanoSaudeExists(int id)
        {
            return _context.PlanosSaude.Any(e => e.Id == id);
        }
    }
}
