namespace Tesoreria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

     //[DataContract(IsReference = true)]
    public partial class Clientes
    {
       
        public Clientes()
        {
            Recibos = new HashSet<Recibos>();
        }

        [Key]
        public int IDCliente { get; set; }

        [StringLength(50)]
        public string Idenficacion { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellidos { get; set; }

        public virtual ICollection<Recibos> Recibos { get; set; }
    }
}
