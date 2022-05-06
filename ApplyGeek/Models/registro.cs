using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ApplyGeek.Models
{
    public class Registro
    {
        [PrimaryKey, AutoIncrement]
        public int IdCliente { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        [MaxLength (50)]
        public string Apellido { get; set; }
        [MaxLength (50)]
        public int Edad { get; set; }
        [MaxLength(2)] 
        public string Direccion { get; set; }
        [MaxLength (200)]
        public string Email { get; set; }
    }
}
