using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UTools.Application.Dtos;
using UTools.Application.Interfaces;
using UTools.Domain.Interfaces.Repositories;

namespace UTools.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly ICriarEmpresaAppService _criarEmpresaAppService;
        private readonly IExcluirEmpresaAppService _excluirEmpresaAppService;

        public EmpresaController(IMapper mapper,
                                 IEmpresaRepository empresaRepository,
                                 ICriarEmpresaAppService criarEmpresaAppService,
                                 IExcluirEmpresaAppService excluirEmpresaAppService)
        {
            _mapper = mapper;
            _empresaRepository = empresaRepository;
            _criarEmpresaAppService = criarEmpresaAppService;
            _excluirEmpresaAppService = excluirEmpresaAppService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseDTO), 400)]
        [ProducesResponseType(typeof(ResponseDTO), 404)]
        [ProducesResponseType(typeof(ResponseDTO), 500)]
        [ProducesResponseType(typeof(ResponseDTO<List<CadastroEmpresaDTO>>), 200)]
        public async Task<IActionResult> Get([FromQuery] ConsultaCnpjDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseDTO
                {
                    HasError = false,
                    Message = "Bad Request"
                });

            var entities = await _empresaRepository.GetAllAsync(request.CNPJ, request.Nome);
            if (entities == null || entities.Count == 0)
                return NotFound(new ResponseDTO
                {
                    HasError = false,
                    Message = "Não foi localizado nenhuma empresa"
                });

            return Ok(new ResponseDTO<List<CadastroEmpresaDTO>>
            {
                HasError = false,
                Result = _mapper.Map<List<CadastroEmpresaDTO>>(entities)
            });
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseDTO), 400)]
        [ProducesResponseType(typeof(ResponseDTO), 409)]
        [ProducesResponseType(typeof(ResponseDTO), 500)]
        [ProducesResponseType(typeof(ResponseDTO), 200)]
        public async Task<IActionResult> Post([FromBody] CriarEmpresaDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseDTO
                {
                    HasError = false,
                    Message = "Bad Request"
                });

            var result = await _criarEmpresaAppService.ExecuteAsync(request);

            if (result.HasError)
                return Conflict(result);

            return Ok(result);
        }


        [HttpDelete("{cnpj}")]
        [ProducesResponseType(typeof(ResponseDTO), 400)]
        [ProducesResponseType(typeof(ResponseDTO), 409)]
        [ProducesResponseType(typeof(ResponseDTO), 500)]
        [ProducesResponseType(typeof(ResponseDTO), 200)]
        public async Task<IActionResult> Delete(string cnpj)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseDTO
                {
                    HasError = false,
                    Message = "Bad Request"
                });

            cnpj = cnpj?.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            var result = await _excluirEmpresaAppService.ExecuteAsync(cnpj);

            if (result.HasError)
                return Conflict(result);

            return Ok(result);
        }

    }
}
