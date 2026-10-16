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
        [HttpGet]
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



        // POST api/<AgendamentoController>
        //[HttpPost]
        //public string Post([FromBody] string value)
        //{
        //    if (medicoFuncao.CadastrarMedico())
        //    {
        //        return "Cadastro realizado com sucesso!";
        //    }
        //    return "Cadastro não realizado.";
        //}

        // PUT api/<AgendamentoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AgendamentoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           
        }
    }
}
