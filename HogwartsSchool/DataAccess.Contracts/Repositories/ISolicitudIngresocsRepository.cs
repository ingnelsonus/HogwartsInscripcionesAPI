using DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts.Repositories
{
    public interface ISolicitudIngresocsRepository: IGenericRepository<SolicitudIngresoEntitycs>
    {
        public Task<SolicitudIngresoEntitycs> CreateSolicitudIngresoAsync(SolicitudIngresoEntitycs solicitudIngreso);
        public Task<SolicitudIngresoEntitycs> UpdateSolicitudIngresoAsync(SolicitudIngresoEntitycs entity);

        public List<SolicitudIngresoEntitycs> GetAllSolicitudesIngreso();

        public bool DeleteAsync(SolicitudIngresoEntitycs entity);

    }
}
