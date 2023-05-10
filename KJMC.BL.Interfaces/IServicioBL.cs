using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KJMC.BL.DTOs;
using KJMC.BL.DTOs.ServicioDTOs;

namespace KJMC.BL.Interfaces
{
    public interface IServicioBL
    {
        Task<int> Create(ServicioAddDTO servicio);
        Task<int> Update(ServicioUpdateDTO servicio);
        Task<int> Delete(int Id);
        Task<ServicioGetByIdDTO> GetById(int Id);
        Task<List<ServicioGetAllDTO>> GetAll();
        Task<List<ServicioSearchOutputDTO>> Search(ServicioSearchInputDTO servicio);
    }
}
