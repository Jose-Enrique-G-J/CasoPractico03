namespace AutomovilesWsSoap.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Automovile
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Imagen { get; set; }

        [StringLength(50)]
        public string Marca { get; set; }

        [StringLength(50)]
        public string Modelo { get; set; }

        public int? Año { get; set; }

        [Column(TypeName = "money")]
        public decimal? Precio { get; set; }

        public DateTime? Fecha_creacion { get; set; }
    }
}
