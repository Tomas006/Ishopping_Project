using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IShopping.Models
{
    [Table("Utilizadores")]
    public class Utilizador
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }

        public Utilizador()
        {
            Compras = new HashSet<Compra>();
        }
    }
}