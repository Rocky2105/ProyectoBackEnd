using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithBD;

[Table("Mantenimiento")]
public partial class Mantenimiento
{
    [Key]
    public long MantenimientoId { get; set; }

    [Column(TypeName = "date")]
    public byte[] Fecha { get; set; } = null!;

    public long TipoId { get; set; }

    public long MaterialId { get; set; }

    [ForeignKey("MaterialId")]
    [InverseProperty("Mantenimientos")]
    public virtual Material Material { get; set; } = null!;

    [ForeignKey("TipoId")]
    [InverseProperty("Mantenimientos")]
    public virtual Tipo Tipo { get; set; } = null!;
}
