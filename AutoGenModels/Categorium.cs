using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithBD;

public partial class Categorium
{
    [Key]
    public long CategoriaId { get; set; }

    [Column(TypeName = "nvarchar (50)")]
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "nvarchar(50)")]
    public string Descripcion { get; set; } = null!;

    [InverseProperty("Categoria")]
    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
