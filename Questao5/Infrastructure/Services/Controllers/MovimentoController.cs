using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.Repository;
using Questao5.Infrastructure.Sqlite;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Questao5.Infrastructure.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentoController : ControllerBase
    {
        private readonly DatabaseConfig _databaseConfig;

        /// <summary>
        /// Includes a new movement in the check account
        /// </summary>
        /// <param name="movimento">Json format Movimento object</param>
        /// <returns>Id moviment</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Movimento movimento)
        {
            try
            {
                string tipoMovimento = movimento.TipoMovimento.ToUpper();

                if (tipoMovimento != "C" && tipoMovimento != "D")
                {
                    return StatusCode(400, new { type = "INVALID_TYPE", message = "The moviment type must be C or D" });
                }

                if (movimento.Valor <0)
                {
                    return StatusCode(400, new { type = "INVALID_VALUE", message = "The moviment value must be greater than or equal to 0" });
                }

                //Check if is a valid or active account
                 ContaCorrenteRepository contaCorrenteRepository = new ContaCorrenteRepository();
               string contaValida = contaCorrenteRepository.GetContaCorrenteValida(movimento.IdContaCorrente);

                if (contaValida == "INVALID_ACCOUNT")
                {
                    return StatusCode(400, new { type = "INVALID_ACCOUNT", message = "Invalid Account Number" });
                }

                if (contaValida == "INACTIVE_ACCOUNT")
                {
                    return StatusCode(400, new { type = "INACTIVE_ACCOUNT", message = "Inactive checking account" });
                }

                string idMovimento = new Guid().ToString();

                movimento.IdMovimento = idMovimento;

                MovimentoRepository repository = new MovimentoRepository(_databaseConfig);

                repository.Save(movimento);

                return StatusCode(200, idMovimento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
