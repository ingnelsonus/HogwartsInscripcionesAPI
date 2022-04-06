using HogwartsSchool.Api.Bussiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogwartsSchool.Api.Services.Contracts.Services
{
    public interface ISolicitudIngresocsService
    {
        public Task<SolicitudIngreso> CreateSolicitudIngresoAsync(SolicitudIngreso solicitudIngreso);
        public Task<SolicitudIngreso> UpdateSolicitudIngresoAsync(SolicitudIngreso entity);

        public List<SolicitudIngreso> GetAllSolicitudesIngreso();

        public bool DeleteAsync(SolicitudIngreso entity);
    }
}
