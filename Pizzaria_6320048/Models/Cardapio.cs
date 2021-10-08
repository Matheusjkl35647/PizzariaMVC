using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pizzaria_6320048.Models
{
    public class Cardapio
    {
        public int Id { get; set; }
        [Required]
        public string Pizza { get; set; }
        public string Sabor { get; set; }
        public decimal ValorInt { get; set; }
        public decimal ValorBrot { get; set; }
    }
}