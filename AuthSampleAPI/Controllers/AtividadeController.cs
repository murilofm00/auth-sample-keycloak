using AuthSampleAPI.Models;
using AuthSampleAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AuthSampleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtividadeController : ControllerBase
    {

        private AtividadesService _atividadesService;

        private HashSet<Participacao> _participacoes = new();

        private readonly IHttpContextAccessor _contextAccessor;


        public AtividadeController( IHttpContextAccessor contextAccessor, AtividadesService atividades)
        {
            _contextAccessor = contextAccessor;
            _atividadesService = atividades;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Atividade>> Get()
        {
            var idUsuario = _contextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var isProfessor = _contextAccessor.HttpContext!.User.IsInRole("PROFESSOR");
            if (isProfessor)
            {
                return Ok(_atividadesService.ListarPorUsuario(idUsuario));
            }
            return Ok(_atividadesService.ListarTodas());
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "PROFESSOR,ADMIN")]
        public ActionResult Delete(Guid id)
        {
            var idUsuario = _contextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = _contextAccessor.HttpContext!.User.IsInRole("ADMIN");

            var atividade = _atividadesService.Obter(id);

            if (atividade is null)
            {
                return BadRequest("Atividade não encontrada.");
            }

            if(atividade.CreatedBy != idUsuario && !isAdmin)
            {
                return BadRequest("Você não possui permissão para remover essa atividade.");
            }

            _atividadesService.Remover(id);
            return NoContent();
        }
    }
}
