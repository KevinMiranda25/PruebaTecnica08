using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJMC.BL.DTOs.ServicioDTOs
{
    public class ServicioUpdateDTO
    {
        public int Id { get; set; }
        public string TipoServicio { get; set; }
        public string DescripcionServicio { get; set; }
        public decimal Precio { get; set; }
    }
}
