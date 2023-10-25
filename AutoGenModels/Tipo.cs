using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithBD;

[Table("Tipo")]
public partial class Tipo
{
    [Key]
    public long TipoId { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "varchar(100)")]
    public string Descripcion { get; set; } = null!;

    [InverseProperty("Tipo")]
    public virtual ICollection<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();
}
