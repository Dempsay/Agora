using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    internal interface ICapacitacionnService : IGenericService<Capacitacion>    
    {
        public Task<List<Capacitacion>?> GetCapacitacionesAbiertasAsync();
    }
}
