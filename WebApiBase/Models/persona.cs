namespace WebApiBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("persona")]
    public partial class persona
    {
        [Key]
        public int id_persona { get; set; }

        public int id_perfil { get; set; }

        public int documento { get; set; }

        [Required]
        [StringLength(25)]
        public string nombre { get; set; }

        [StringLength(25)]
        public string apellido { get; set; }

        [StringLength(50)]
        public string direccion { get; set; }

        [StringLength(25)]
        public string telefono { get; set; }

        [StringLength(60)]
        public string email { get; set; }

        [StringLength(20)]
        public string usuario { get; set; }

        [StringLength(60)]
        public string clave { get; set; }

        public DateTime? fecha_registro { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public virtual perfil perfil { get; set; }

    }
}
