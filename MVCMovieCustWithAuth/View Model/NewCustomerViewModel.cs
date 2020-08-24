using MVCMovieCustWithAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMovieCustWithAuth.View_Model
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MenberShipType> MenberShipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}