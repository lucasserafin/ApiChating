using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiChating.WebApi.Data.Entities
{
    public class SalaChat
    {
        public int Id { get; set; }
        //[Required]
        public string CodigoChat { get; set; }
        //[Required]
        public string NomUsuario { get; set; }
    }
}
