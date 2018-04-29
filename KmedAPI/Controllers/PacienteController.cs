using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using KmedAPI.Contexto;
using KmedAPI.Poco;
using System.Xml.Linq;

namespace KmedAPI.Controllers
{
    [Route("api/[controller]")]
    public class PacienteController : Controller
    {
        private readonly APIContexto _apicontexto;

        public PacienteController(APIContexto contexto)
        {
            this._apicontexto = contexto;
        }

        //GET api/paciente
        [HttpGet]
        public IEnumerable<Paciente> Get()
        {
            return this._apicontexto.Pacientes.ToList();
        }

        // GET api/paciente/{{id}}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dado = this._apicontexto.Pacientes.Where(x => x.Id == id).Select(x => x);
            if(dado.Count() < 1){
                return new NotFoundResult();
            }
            return new ObjectResult(dado);
        }

        // POST api/paciente
        [HttpPost]
        public void Post([FromBody]Paciente paciente)
        {
            this._apicontexto.Add<Paciente>(paciente);
            this._apicontexto.SaveChanges();

        }


        //PUT api/paciente/
        [HttpPut]
        public ActionResult Put([FromBody]Paciente paciente){
            var dado = this._apicontexto.Pacientes.FirstOrDefault(x => x.Id == paciente.Id);
            if(dado != null){
                dado.Nome = paciente.Nome;
                dado.Documento = paciente.Documento;
                dado.Endereco = paciente.Endereco;
                this._apicontexto.Update(dado);
                this._apicontexto.SaveChanges();
                return new ObjectResult(dado);
            }else{
                return new NotFoundResult();
            }

        }

        // DELETE api/paciente/{{id}}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dadoExistente = this._apicontexto.Pacientes.Where(x => x.Id == id);
            if (dadoExistente.Count() < 1)
            {
                return new NotFoundResult();
            }
            else
            {
                this._apicontexto.Remove(dadoExistente);
                this._apicontexto.SaveChanges();
                return new NoContentResult();
            }
        }
    }
}
