using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Niculae_Ana_Maria_Pagina_Web.Models
{
    public class ShopDetailsViewModel
    {

        public Shop Shop { get; set; }
        public List<Angajat> Angajats { get; set; }

        public int GroupId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string WorkTime { get; set; }

    }
}
