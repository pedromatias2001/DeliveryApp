using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AManeira.Data;
using AManeira.Models;

namespace AManeira.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PratosAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PratosAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PratosAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PratosViewModel>>> GetPratos()
        {
            return await _context.Pratos.Select(a=> new PratosViewModel
            {
                Id = a.Id,
                Nome = a.Nome,
                Preco = a.Preco,
                NumStock = a.NumStock,
                Descricao = a.Descricao,
                Fotografia = a.Foto
            }
            ).OrderByDescending(a=> a.Id).ToListAsync();
        }

        // GET: api/PratosAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pratos>> GetPratos(int id)
        {
            var pratos = await _context.Pratos.FindAsync(id);

            if (pratos == null)
            {
                return NotFound();
            }

            return pratos;
        }

        // PUT: api/PratosAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPratos(int id, [FromForm] Pratos prato, IFormFile uploadFotoPrato)
        {
            //if (id != prato.Id)
            //{
            //return BadRequest();
            //}


            //ir buscar o caminho da pasta "imagens"
            if (uploadFotoPrato != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens");

                //criar pasta se não existe
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //fazer o caminho da imagem na pasta
                string fileNameWithPath = Path.Combine(path, uploadFotoPrato.FileName);

                //colocar a imagem na pasta
                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    uploadFotoPrato.CopyTo(stream);
                }
                prato.Foto = uploadFotoPrato.FileName;
            }

            prato.Id = id;
            prato.Preco = Convert.ToDecimal(prato.AuxPreco.Replace('.', ','));


            _context.Entry(prato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PratosExists(id))
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

        // POST: api/PratosAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pratos>> PostPratos([FromForm] Pratos prato, IFormFile uploadFotoPrato)
        {
            // o anotador [FromForm] informa o ASP .NET que os dados são fornecidos 
            // em FormData

            /*
             * TAREFAS A EXECUTAR:
             * 1. validar os dados
             * 2. inserir a foto no disco rígido
             * 3. usar Try-Catch
             */

            //ir buscar o caminho da pasta "imagens"
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens");

            //criar pasta se não existe
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //fazer o caminho da imagem na pasta
            string fileNameWithPath = Path.Combine(path, uploadFotoPrato.FileName);

            //colocar a imagem na pasta
            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                uploadFotoPrato.CopyTo(stream);
            }

            prato.Foto = uploadFotoPrato.FileName;
            prato.Preco = Convert.ToDecimal(prato.AuxPreco.Replace('.', ','));

            try { 
                _context.Pratos.Add(prato);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return CreatedAtAction("GetPratos", new { id = prato.Id }, prato);
        }

        // DELETE: api/PratosAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePratos(int id)
        {
            var pratos = await _context.Pratos.FindAsync(id);
            if (pratos == null)
            {
                return NotFound();
            }

            _context.Pratos.Remove(pratos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PratosExists(int id)
        {
            return _context.Pratos.Any(e => e.Id == id);
        }
    }
}
