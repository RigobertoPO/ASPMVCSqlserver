namespace MVCSqlserver.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cliente
    {
        [Key]
        [StringLength(20)]
        public string IdCliente { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(150)]
        public string CorreoElectronico { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        [StringLength(20)]
        public string TipoCliente { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public bool? Activo { get; set; }
    }
}
