using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithBD;

[Table("Marca")]
public partial class Marca
{
    [Key]
    public long MarcaId { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "varchar(100)")]
    public string Descripcion { get; set; } = null!;

    [InverseProperty("Marca")]
    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
