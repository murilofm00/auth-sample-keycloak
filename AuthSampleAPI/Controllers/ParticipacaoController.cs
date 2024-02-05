using AuthSampleAPI.Models;
using AuthSampleAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthSampleAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ParticipacaoController : ControllerBase
    {
        private readonly ParticipacaoService _participacaoService;
        private readonly IHttpContextAccessor _contextAccessor;


        public ParticipacaoController(IHttpContextAccessor contextAccessor, ParticipacaoService participacaoService)
        {
            _contextAccessor = contextAccessor;
            _participacaoService = participacaoService;
        }

        [HttpGet("{idAtividade}")]
        [Authorize(Roles = "STUDENT")]
        public ActionResult<Participacao> ObterParticipacao(Guid idAtividade)
        {
            var idUsuario = _contextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var participacao = _participacaoService.Obter(idAtividade, idUsuario);

            return Ok(participacao);
        }

        [HttpPut("{idAtividade}")]
        [Authorize(Roles = "STUDENT")]
        public ActionResult<Participacao> AtualizarParticipacao(Guid idAtividade, [FromBody] Participacao participacao)
        {
            var idUsuario = _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (idAtividade != participacao.IdAtividade || idUsuario != participacao.IdUsuario)
            {
                return BadRequest();
            }

            _participacaoService.Adicionar(participacao);

            return participacao;
        }
    }
}
