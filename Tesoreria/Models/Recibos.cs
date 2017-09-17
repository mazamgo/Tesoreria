namespace Tesoreria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Recibos
    {
        [Key]
        public int IDRecibo { get; set; }

        public int IDCliente { get; set; }

        public int NoRecibo { get; set; }

        [Column(TypeName = "money")]
        public decimal Monto { get; set; }

        public virtual Clientes Clientes { get; set; }
    }
}
