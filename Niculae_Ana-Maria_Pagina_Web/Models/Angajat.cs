using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Niculae_Ana_Maria_Pagina_Web.Models
{
    public class Angajat
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string WorkTime { get; set; }

        //link to the Shop tabale
        public virtual Shop MyShop { get; set; }
    }
}
