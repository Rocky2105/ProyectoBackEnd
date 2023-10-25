using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithBD;

[Table("Modelo")]
public partial class Modelo
{
    [Key]
    public long ModeloId { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "varchar(100)")]
    public string Descripcion { get; set; } = null!;

    [InverseProperty("Modelo")]
    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
