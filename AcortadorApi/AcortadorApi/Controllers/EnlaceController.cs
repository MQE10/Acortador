using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AcortadorApi.DTOs;
using AcortadorApi.Models;
using AcortadorApi.Business;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using AcortadorApi.Helpers;

namespace AcortadorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //listar en la base de datos
    public class EnlaceController : ControllerBase
    {
        private readonly AcortadorContext context;
        public EnlaceController(AcortadorContext _context)
        {
            context = _context;
        }

        //Traer todo
        [HttpGet("GetList")]
        public List<EnlaceDTO> GetList()
        {
            var idfuncionario = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "-100");
            return context.enlace.Where(x => x.IdFuncionario == idfuncionario).Include(x => x.IdPlataformaNavigation).ToList().Map();
        }

        //Traer paginado de 10 en 10
        [HttpGet("GetM")]
        public async Task<ActionResult<List<EnlaceDTO>>> GetM([FromQuery] PaginacionDTO paginacion)
        {
            var idfuncionario = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "-100");
            var lEnlace = context.enlace.Include(x => x.IdPlataformaNavigation).Where(x => x.IdFuncionario == idfuncionario).AsQueryable();
            await HttpContext.InsertarParametrosPaginacion(lEnlace, paginacion.CantidadRegistrosPorPagina);
            return  lEnlace.Paginar(paginacion).ToList().Map();
             
        }

        //Buscar por nombre/codigo 
        [HttpGet("Search")]
        public List<EnlaceDTO> Search(string cad)
        {
            var idfuncionario = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "-100");
            var list = context.enlace.Where(x => x.Codigo.Contains(cad) || x.Titulo.Contains(cad)).Where(x => x.IdFuncionario == idfuncionario).Include(x => x.IdPlataformaNavigation).ToList().Map();
            return list;
        }


        [HttpGet("Getforcode")]
        public EnlaceDTO Getforcode(string code)
        {
            try
            {
                var enlace = context.enlace.FirstOrDefault(x => x.Codigo == code);
                if(enlace == null) return new EnlaceDTO();
                return enlace.Map(); 
            }
            catch (Exception ex)
            {
                return new EnlaceDTO();
            }
        }

        [HttpPost("Guardar")]
        public IActionResult saveDTO(EnlaceDTO item)
        {
            try
            {
                //validaciones 

            //    int idFuncionario = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "-100");

                var enlaces = new enlace
                {
                    Codigo = item.cod,
                    Titulo = item.tit,
                    Descripcion = item.desc,
                    Enlace1 = item.enlace,
                    Estado = item.estado,
                    IdPlataforma = item.idplataforma,
                    IdFuncionario = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "-100")
            };

                context.enlace.Add(enlaces);

                context.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("PostDelete")]
        public IActionResult deleteDTO(EnlaceDTO item)
        {
            try
            {
                var enlaces = new enlace
                {
                    Codigo = item.cod
                };
                context.enlace.Remove(enlaces);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
