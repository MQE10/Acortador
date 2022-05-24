using AcortadorApi.DTOs;
using AcortadorApi.Repositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcortadorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccesosController : ControllerBase
    {
        private readonly IRepositorio _repsositorio;
        private const int moduloId = 1300;// colocar el modulo correspodiente

        public AccesosController(IRepositorio repositorio)
        {
            _repsositorio = repositorio;
        }

        //var respuestaHTTP = await _repsositorio.Post<PagoGenerarDTO, PagoGenerarResp>("RegistrarPago", consulta);
        //var res = respuestaHTTP.Response;


        [HttpGet("RenovarToken")]
        [Authorize(Roles = "funcionario")]
        public async Task<ActionResult<UserToken>> RenovarToken()
        {
            try
            {
                var respuestaHTTP = await _repsositorio.Get<UserToken>("Funcionarios/RenovarToken");
                var res = respuestaHTTP.Response;

                if (respuestaHTTP.Error)
                {
                    return BadRequest(respuestaHTTP.HttpResponseMessage.ToString());
                }

                return Ok(res);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("Funcionario")]
        [Authorize(Roles = "funcionario")]
        public async Task<ActionResult<FuncionarioDTO>> Get()
        {

            try
            {
                var respuestaHTTP = await _repsositorio.Get<FuncionarioDTO>("Funcionarios");
                var res = respuestaHTTP.Response;

                if (respuestaHTTP.Error)
                {
                    return BadRequest(respuestaHTTP.HttpResponseMessage.ToString());
                }

                return Ok(res);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }




        }

        [HttpGet("Tareas/{interfaceId:int}")]
        [Authorize(Roles = "funcionario")]
        public async Task<ActionResult<List<TareaDTO>>> GetTareas(int interfaceId)
        {

            try
            {
                var respuestaHTTP = await _repsositorio.Get<TareaDTO>($"Funcionarios/Tareas/{interfaceId}");
                var res = respuestaHTTP.Response;

                if (respuestaHTTP.Error)
                {
                    return BadRequest(respuestaHTTP.HttpResponseMessage.ToString());
                }

                return Ok(res);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }

        [HttpGet("InterfaceTareas")]
        [Authorize(Roles = "funcionario")]
        public async Task<ActionResult<List<InterfaceDTO>>> GetInterfaceTareas()
        {
            try
            {
                var respuestaHTTP = await _repsositorio.Get<List<InterfaceDTO>>($"Funcionarios/InterfaceTareas/{moduloId}");
                var res = respuestaHTTP.Response;

                if (respuestaHTTP.Error)
                {
                    return BadRequest(respuestaHTTP.HttpResponseMessage.ToString());
                }

                return Ok(res);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }






        [HttpGet("Interfaces")]
        [Authorize(Roles = "funcionario")]
        public async Task<ActionResult<List<InterfaceDTO>>> getIterfaces()
        {

            try
            {
                var respuestaHTTP = await _repsositorio.Get<List<InterfaceDTO>>($"Funcionarios/Interfaces/{moduloId}");
                var res = respuestaHTTP.Response;

                if (respuestaHTTP.Error)
                {
                    return BadRequest(respuestaHTTP.HttpResponseMessage.ToString());
                }

                return Ok(res);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }
    }
}
