using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithBD;

[Table("Grupo")]
public partial class Grupo
{
    [Key]
    public long GrupoId { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string Nombre { get; set; } = null!;

    [InverseProperty("Grupo")]
    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
}
