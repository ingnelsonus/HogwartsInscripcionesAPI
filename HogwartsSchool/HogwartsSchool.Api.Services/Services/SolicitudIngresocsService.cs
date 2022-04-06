using DataAccess.Contracts.Repositories;
using DataAccess.Mappers;
using HogwartsSchool.Api.Bussiness.Models;
using HogwartsSchool.Api.Services.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogwartsSchool.Api.Services.Services
{
    public class SolicitudIngresocsService : ISolicitudIngresocsService
    {
        private readonly ISolicitudIngresocsRepository _solicitudIngresocsRepository;

        public SolicitudIngresocsService(ISolicitudIngresocsRepository solicitudIngresocsRepository)
        {
            _solicitudIngresocsRepository = solicitudIngresocsRepository;
        }

        public async Task<SolicitudIngreso> CreateSolicitudIngresoAsync(SolicitudIngreso dto)
        {
            var newRequestEntity = await _solicitudIngresocsRepository.CreateSolicitudIngresoAsync(SolicitudIngresocsMapper.GetSolicitudIngresoEntity(dto));
            return SolicitudIngresocsMapper.GetSolicitudIngreso(newRequestEntity);
        }

        public bool DeleteAsync(SolicitudIngreso entity)
        {
            _solicitudIngresocsRepository.Delete(SolicitudIngresocsMapper.GetSolicitudIngresoEntity(entity));
            return true;
        }

        public List<SolicitudIngreso> GetAllSolicitudesIngreso()
        {
            return SolicitudIngresocsMapper.GetListSolicitudesIngreso(_solicitudIngresocsRepository.GetAllSolicitudesIngreso());
        }

        public async Task<SolicitudIngreso> UpdateSolicitudIngresoAsync(SolicitudIngreso entity)
        {
            return SolicitudIngresocsMapper.GetSolicitudIngreso(await _solicitudIngresocsRepository.UpdateAsync(SolicitudIngresocsMapper.GetSolicitudIngresoEntity(entity)));
        }




    }
}
