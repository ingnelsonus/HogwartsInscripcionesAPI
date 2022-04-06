using DataAccess.Contracts.Entities;
using DataAccess.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class SolicitudIngresocsRepository : GenericRepository<SolicitudIngresoEntitycs>, ISolicitudIngresocsRepository
    {
        private readonly HowartsSchoolRequestDBContext _context;

        public SolicitudIngresocsRepository(HowartsSchoolRequestDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<SolicitudIngresoEntitycs> CreateSolicitudIngresoAsync(SolicitudIngresoEntitycs solicitudIngreso)
        {
            try
            {
                SolicitudIngresoEntitycs newRequest = new SolicitudIngresoEntitycs
                {
                    Nombre = solicitudIngreso.Nombre,
                    Apellidos = solicitudIngreso.Apellidos,
                    Documento = solicitudIngreso.Documento,
                    Edad = solicitudIngreso.Edad,
                    CasaHechicera = solicitudIngreso.CasaHechicera
                };

                _context.SolicitudIngreso.Add(newRequest);
                await _context.SaveChangesAsync();
                return newRequest;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<SolicitudIngresoEntitycs> GetAllSolicitudesIngreso()
        {
            var lsRequest = _context.SolicitudIngreso.ToList();
            return lsRequest;
        }

        public async Task<SolicitudIngresoEntitycs> UpdateSolicitudIngresoAsync(SolicitudIngresoEntitycs entity)
        {
            SolicitudIngresoEntitycs RequestToUpdate = _context.SolicitudIngreso.Where(a => a.Id == entity.Id).First();

            if (RequestToUpdate != null)
            {
                RequestToUpdate.Nombre = entity.Nombre;
                RequestToUpdate.Apellidos = entity.Apellidos;
                RequestToUpdate.Documento = entity.Documento;
                RequestToUpdate.Edad = entity.Edad;
                RequestToUpdate.CasaHechicera = entity.CasaHechicera;

                _context.SolicitudIngreso.Update(RequestToUpdate);
                await _context.SaveChangesAsync();
            }

            return entity;
        }

        bool ISolicitudIngresocsRepository.DeleteAsync(SolicitudIngresoEntitycs entity)
        {
            _context.SolicitudIngreso.Remove(entity);
            _context.SaveChanges();
            return true;
        }
    }
}
