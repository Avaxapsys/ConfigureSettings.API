using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigureSettings.API.Models
{
    public class Aplications
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AplicationId { get; set; }
        public string Name { get; set; }
        //public List<Settings> Settings { get; set; }
    }
}
