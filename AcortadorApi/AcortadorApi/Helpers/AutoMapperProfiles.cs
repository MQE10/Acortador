using AcortadorApi.DTOs;
using AcortadorApi.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcortadorApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            //CreateMap<MateriaContenido, MateriaContenidoDTO>()
            //    .ForMember(x => x.EstadoNombre, x => x.MapFrom(y => y.IdEstadoNavigation != null ? y.IdEstadoNavigation.Nombre : ""))
            //    .ForMember(x => x.ModeloEstudioNombre, x => x.MapFrom(y => y.IdModeloEstudioNavigation != null ? y.IdModeloEstudioNavigation.Nombre : ""))
            //      .ForMember(x => x.GrupoAcademicoNombre, x => x.MapFrom(y => y.GrupoAcademico != null ? y.GrupoAcademico.Nombre : ""))
            //    .ReverseMap();

        }
    }
}
