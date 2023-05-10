using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KJMC.EN;

namespace KJMC.EN.Interfaces
{
    public interface IServicio
    {
        public void Create(Servicio servicio);
        public void Update(Servicio servicio);
        public void Delete(Servicio servicio);
        public Task<List<Servicio>> Search(Servicio servicio);
        public Task<Servicio> GetById(int id);
        public Task<List<Servicio>> GetAll();
    }
}
