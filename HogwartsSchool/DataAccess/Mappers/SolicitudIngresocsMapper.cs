using DataAccess.Contracts.Entities;
using HogwartsSchool.Api.Bussiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    public class SolicitudIngresocsMapper
    {
        public static SolicitudIngresoEntitycs GetSolicitudIngresoEntity(SolicitudIngreso dto)
        {
            return new DataAccess.Contracts.Entities.SolicitudIngresoEntitycs()
            {
                Id = dto.Id == null ? 0 : Convert.ToInt64(dto.Id),                
                Nombre = dto.Nombre,
                Apellidos = dto.Apellidos,
                Documento = dto.Documento,
                Edad = Convert.ToInt32(dto.Edad),
                CasaHechicera = dto.CasaHechicera,
            };
        }

        public static SolicitudIngreso GetSolicitudIngreso(SolicitudIngresoEntitycs entity)
        {
            return new SolicitudIngreso()
            {                
                Id = entity.Id.ToString(),
                Nombre = entity.Nombre,
                Apellidos = entity.Apellidos,
                Documento = entity.Documento,
                Edad = entity.Edad.ToString(),
                CasaHechicera = entity.CasaHechicera,
            };
        }

        public static List<SolicitudIngreso> GetListSolicitudesIngreso(List<SolicitudIngresoEntitycs> entity)
        {
            List<SolicitudIngreso> lsSolicitudes = new List<SolicitudIngreso>();

            foreach (SolicitudIngresoEntitycs RequestEntity in entity)
            {
                var newRequest = new SolicitudIngreso()
                {
                    Id = RequestEntity.Id.ToString(),
                    Nombre = RequestEntity.Nombre,
                    Apellidos = RequestEntity.Apellidos,
                    Documento = RequestEntity.Documento,
                    Edad = RequestEntity.Edad.ToString(),
                    CasaHechicera = RequestEntity.CasaHechicera,
                };

                lsSolicitudes.Add(newRequest);
            }

            return lsSolicitudes;
        }
    }
}
