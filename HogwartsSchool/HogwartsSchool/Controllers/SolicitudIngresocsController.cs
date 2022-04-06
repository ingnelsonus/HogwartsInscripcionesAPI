using HogwartsSchool.Api.Bussiness.Models;
using HogwartsSchool.Api.Services.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HogwartsSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudIngresocsController : ControllerBase
    {
        private readonly ISolicitudIngresocsService _solicitudIngresocsService;

        public SolicitudIngresocsController(ISolicitudIngresocsService solicitudIngresocsService)
        {
            _solicitudIngresocsService = solicitudIngresocsService;
        }

        /// <summary>
        /// Registro de solicitud de ingreso.
        /// </summary>
        /// <param name="newRequeest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateSolicitudIngresoAsync")]        
        public async Task<ActionResult<ApiStandardResponse>> CreateSolicitudIngresoAsync([FromBody] SolicitudIngreso newRequeest)
        {
            var requestResponse = new ApiStandardResponse();

            try
            {
                if (ModelState.IsValid)
                {                                        
                    var NewRequestToAdd = new SolicitudIngreso
                    {                   
                        Nombre = newRequeest.Nombre,
                        Apellidos = newRequeest.Apellidos,
                        Documento = newRequeest.Documento,
                        Edad = newRequeest.Edad,
                        CasaHechicera = newRequeest.CasaHechicera,
                    };

                    var result = await _solicitudIngresocsService.CreateSolicitudIngresoAsync(NewRequestToAdd);
                    if (Convert.ToInt64(result.Id)>0)
                    {
                        requestResponse.IsSuccess = true;
                        requestResponse.Message = "Solicitud registrada con exito";
                        requestResponse.Result = result;
                        requestResponse.Count = 1;
                        return Ok(requestResponse);
                    }
                    else
                    {
                        requestResponse.IsSuccess = false;
                        requestResponse.Message = "No se registro la solicitud, intenta en unos minutos: ";
                        requestResponse.Result = null;
                        return BadRequest(requestResponse);
                    }
                }
                else
                {
                    requestResponse.IsSuccess = false;
                    requestResponse.Message = "La solicitud enviada no cumple con las validaciones minimas requeridas:";
                    requestResponse.Result = null;
                    return BadRequest(requestResponse);
                }
            }
            catch (Exception ex)
            {
                //TODO: Register Log Error
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("GetAllSolicitudesIngreso")]        
        public ActionResult<List<SolicitudIngreso>> GetAllSolicitudesIngreso()
        {
            try
            {         
                //Consultamos todos los usuarios registrados.
                var lsusers = _solicitudIngresocsService.GetAllSolicitudesIngreso();
                return lsusers;

            }
            catch (Exception ex)
            {
               //TODO:Register Log Error
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateSolicitudIngresoAsync")]
        public async Task<ActionResult<ApiStandardResponse>> UpdateSolicitudIngresoAsync([FromBody] SolicitudIngreso requestToEdit)
        {
            var editRequestResponse = new ApiStandardResponse();

            try
            {
                if (ModelState.IsValid)
                {                                    
                    var result = await _solicitudIngresocsService.UpdateSolicitudIngresoAsync(requestToEdit);

                    if (Convert.ToInt64(result.Id)>0)
                    {
                        editRequestResponse.IsSuccess = true;
                        editRequestResponse.Message = "Solicitud modificada con exito";
                        editRequestResponse.Result = result;
                        editRequestResponse.Count = 1;
                        return Ok(editRequestResponse);
                    }
                    else
                    {
                        editRequestResponse.IsSuccess = false;
                        editRequestResponse.Message = "No fue posible modicar la solicitud: " + requestToEdit.Id;
                        editRequestResponse.Result = null;
                        return BadRequest(editRequestResponse);
                    }
                }
                else
                {
                    editRequestResponse.IsSuccess = false;
                    editRequestResponse.Message = "Informacion, estructura de la solicitud incompleta: " + requestToEdit.Id;
                    editRequestResponse.Result = null;
                    return BadRequest(editRequestResponse);
                }
            }
            catch (Exception ex)
            {
                //TODO: Register Log Error
                return BadRequest(editRequestResponse);
            }
        }


        [HttpDelete]        
        [Route("DeleteAsync")]
        public async  Task<ActionResult<ApiStandardResponse>> DeleteAsync([FromBody] SolicitudIngreso requestToDelete)
        {
            var requestResponse = new ApiStandardResponse();

            try
            {
                if (ModelState.IsValid)
                {
                    var requestToDeleteResponse = _solicitudIngresocsService.DeleteAsync(requestToDelete);

                    if (requestToDeleteResponse==true)
                    { 
                        requestResponse.IsSuccess = true;
                        requestResponse.Message = "Solicitud eliminada con exito";
                        requestResponse.Result = requestToDeleteResponse;
                        requestResponse.Count = 1;
                        return Ok(requestResponse);
                    }
                    else
                    {
                        requestResponse.IsSuccess = false;
                        requestResponse.Message = "La solicitud enviada no fue eliminada:";
                        requestResponse.Result = null;
                        return BadRequest(requestResponse);
                    }
                }
                else
                {
                    requestResponse.IsSuccess = false;
                    requestResponse.Message = "La solicitud enviada no cumple con las validaciones minimas requeridas:";
                    requestResponse.Result = null;
                    return BadRequest(requestResponse);
                }
            }
            catch (Exception ex)
            {
                //TODO: Register Log Error
                return BadRequest(ex.Message);
            }
        }

    }
}
