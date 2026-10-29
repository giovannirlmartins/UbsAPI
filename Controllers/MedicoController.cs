using Microsoft.AspNetCore.Mvc;
using UbsAPI.Services;
using UbsAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UbsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        MedicoService medicoFuncao = new MedicoService();

        // GET: api/<AgendamentoController>
        [HttpGet("listamedicos")]
        public IActionResult GetListarMedicos()
        {
            List<MedicoModel> listaMedicoController = medicoFuncao.ListarMedicos();
            return Ok(listaMedicoController);
        }

        // GET api/<AgendamentoController>/5
        [HttpGet("{crm}")]
        public IActionResult GetMedico(string crm)
        {
            MedicoModel medicoEncontrado = medicoFuncao.BuscarMedico(crm);
            if (medicoEncontrado != null)
            {
                return Ok(medicoEncontrado);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult CadastrarMedico([FromBody] MedicoModel medico)
        {
            bool situacaoCadastro = medicoFuncao.CadastrarMedico(medico);
            if (situacaoCadastro)
            {
                return Created("api/Medico/listamedicos", medico);
            }
            return BadRequest("Médico já cadastrado!");
        }



        // PUT api/<AgendamentoController>/5
        [HttpPut("{crm}")]
        public IActionResult EditarMedico(string crm, [FromBody] MedicoModel medicoEditado)
        {
            bool situacaoEditar = medicoFuncao.EditarMedico(crm, medicoEditado);
            if (situacaoEditar)
            {
                return Ok("Medico Editado com sucesso!");
            }
            return BadRequest("CRM não encontrado!");
        }

        // DELETE api/<AgendamentoController>/5
        [HttpDelete("{crm}")]
        public IActionResult DeletarMedico(string crm)
        {
            bool situacaoDeletar = medicoFuncao.ApagarMedico(crm);
            if (situacaoDeletar)
            {
                return NoContent();
            }
            return BadRequest("CRM não encontrado");
        }
    }
}
