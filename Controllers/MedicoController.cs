
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UbsAPI.Data;
using UbsAPI.Models;

namespace UbsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicosController : ControllerBase
    {
        private readonly UbsDbContext _context;

        public MedicosController(UbsDbContext context) => _context = context;

        [HttpPost]
        public async Task<IActionResult> PostMedico(MedicoModel medico)
        {
            await _context.Medicos.AddAsync(medico);

            await _context.SaveChangesAsync();

            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetMedicos()
        {
            var medicos = await _context.Medicos.ToListAsync();

            return Ok(medicos);
        }

        [HttpGet("{crm}")]
        public async Task<IActionResult> GetMedico(string crm)
        {
            var listaMedicos = await _context.Medicos.ToListAsync();

            MedicoModel medicoEncontrado = new MedicoModel();

            foreach (var medico in listaMedicos)
            {
                if (medico.Crm == crm)
                {
                    return Ok(medicoEncontrado);
                }

            }
            return NotFound("Médico não encontrado!");
        }

        [HttpPut("{crm}")]
        public async Task<IActionResult> PutMedico(string crm, [FromBody] MedicoModel medicoAtualizado)
        {

            var medicos = await _context.Medicos.ToListAsync();

            foreach (var medico in medicos)
            {
                if (medico.Crm == crm)
                {
                    medico.Nome = medicoAtualizado.Nome;
                    medico.Telefone = medicoAtualizado.Telefone;
                    medico.Especialidade = medicoAtualizado.Especialidade;

                    await _context.SaveChangesAsync();

                    return Ok(medico);
                }
            }

            return NotFound("Médico não encontrado.");
        }

        [HttpDelete("{crm}")]
        public async Task<IActionResult> DeleteMedico(string crm)
        {
            var medicos = await _context.Medicos.ToListAsync();

            MedicoModel medicoEncontrado = new MedicoModel();

            foreach (var medico in medicos)
            {
                if (medico.Crm == crm)
                {
                    _context.Medicos.Remove(medico);
                    await _context.SaveChangesAsync();
                    return Ok("Médico excluído com sucesso!");
                }
            }

            return NotFound("Médico não encontrado.");
        }
    }
}
