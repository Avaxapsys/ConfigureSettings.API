using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigureSettings.API.Models
{
    public class Settings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SettingId {  get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        [Required]
        public int AplicationId { get; set; }
        //public Aplications Aplication { get; set; }
    }
}
