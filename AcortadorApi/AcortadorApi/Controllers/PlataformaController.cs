using AcortadorApi.DTOs;
using AcortadorApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcortadorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlataformaController : ControllerBase
    {
        //listar en la base de datos
        private readonly AcortadorContext context;
        public PlataformaController(AcortadorContext _context)
        {
            context = _context;
        }

        //ingresar datos en la base de datos
        [HttpGet("ListaPlataforma")]
        public List<PlataformaDTO> GetList()
        {

            return context.plataforma.ToList().Map();
        }

        [HttpPost("EnviarPlataforma")]
        public IActionResult EnviarDTO(PlataformaDTO item)
        {
            try
            {
                //validaciones          
                var plataformas = new plataforma
                {
                    Nombre = item.nombre,
                    Descripcion = item.descripcion,
                    Estado = item.estado
                };

                context.plataforma.Add(plataformas);

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
