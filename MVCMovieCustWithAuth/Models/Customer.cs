using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMovieCustWithAuth.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MenberShipType MenberShipType { get; set; }
        public int MenbershipTypeId { get; set; }
    }
}