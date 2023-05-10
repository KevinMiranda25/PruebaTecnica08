using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KJMC.EN;
using KJMC.EN.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KJMC.DAL
{
    public class ServicioDAL : IServicio
    {
        readonly KJMCDbContext dbContext;

        public ServicioDAL(KJMCDbContext _dDbContext)
        {
            dbContext = _dDbContext;
        }
        public void Create(Servicio servicio)
        {
            dbContext.Add(servicio);
        }

        public void Delete(Servicio servicio)
        {
            dbContext.Remove(servicio);
        }

        public async Task<List<Servicio>> GetAll()
        {
            return await dbContext.Servicios.ToListAsync();
        }

        public async Task<Servicio> GetById(int id)
        {
            Servicio? document = await dbContext.Servicios.FirstOrDefaultAsync(s => s.Id == id);
            if (document != null)
                return document;
            else
                return new Servicio();
        }

        public Task<List<Servicio>> Search(Servicio servicio)
        {
            var query = dbContext.Servicios.AsQueryable();
            if (!string.IsNullOrWhiteSpace(servicio.TipoServicio))
                query = query.Where(s => servicio.TipoServicio.Contains(servicio.TipoServicio));
            return query.ToListAsync();
        }

        public void Update(Servicio servicio)
        {
            dbContext.Update(servicio);
        }
    }
}
