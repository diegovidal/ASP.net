using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCComADO.Models
{
    public class Time
    {
        [Display(Name = "Id")] // Redundante para o caso
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do time")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o estado do time")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Informe as cores do time")]
        public string Cores { get; set; }
    }
}