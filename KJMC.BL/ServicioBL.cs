using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KJMC.BL.Interfaces;
using KJMC.EN;
using KJMC.EN.Interfaces;
using KJMC.BL.DTOs.ServicioDTOs;

namespace KJMC.BL
{
    public class ServicioBL : IServicioBL
    {
        readonly IServicio _servicioDAL;
        readonly IUnitOfWork _unitWork;

        public ServicioBL(IServicio servicioDAL, IUnitOfWork unitWork)
        {
            _servicioDAL = servicioDAL;
            _unitWork = unitWork;
        }
        public async Task<int> Create(ServicioAddDTO servicio)
        {
            Servicio servicioDAL = new Servicio()
            {
                Id = servicio.Id,
                TipoServicio = servicio.TipoServicio,
                DescripcionServicio = servicio.DescripcionServicio,
                Precio = servicio.Precio,
            };
            _servicioDAL.Create(servicioDAL);
            return await _unitWork.SaveChangesAsync();
        }

        public async Task<int> Delete(int Id)
        {
            Servicio servicioEN = await _servicioDAL.GetById(Id);
            if (servicioEN.Id == Id)
            {
                _servicioDAL.Delete(servicioEN);
                return await _unitWork.SaveChangesAsync();
            }
            else
                return 0;
        }

        public async Task<List<ServicioGetAllDTO>> GetAll()
        {
            List<Servicio> servicio = await _servicioDAL.GetAll();
            List<ServicioGetAllDTO> list = new List<ServicioGetAllDTO>();
            servicio.ForEach(s => list.Add(new ServicioGetAllDTO
            {
                Id = s.Id,
                TipoServicio = s.TipoServicio,
            }));
            return list;
        }

        public async Task<ServicioGetByIdDTO> GetById(int Id)
        {
            Servicio servicioEN = await _servicioDAL.GetById(Id);
            return new ServicioGetByIdDTO()
            {
                Id = servicioEN.Id,
                TipoServicio = servicioEN.TipoServicio,
            };
        }

        public async Task<List<ServicioSearchOutputDTO>> Search(ServicioSearchInputDTO servicio)
        {
            List<Servicio> services = await _servicioDAL.Search(new Servicio { TipoServicio = servicio.TipoServicio });
            List<ServicioSearchOutputDTO> list = new List<ServicioSearchOutputDTO>();
            services.ForEach(s => list.Add(new ServicioSearchOutputDTO
            {

                Id = s.Id,
                TipoServicio = s.TipoServicio,
                
            }));
            return list;
        }

        public async Task<int> Update(ServicioUpdateDTO servicio)
        {
            Servicio servicioEN = await _servicioDAL.GetById(servicio.Id);
            if (servicioEN.Id == servicio.Id)
            {
                servicioEN.TipoServicio = servicioEN.TipoServicio;
                _servicioDAL.Update(servicioEN);
                return await _unitWork.SaveChangesAsync();
            }
            else
                return 0;
        }
    }
}
