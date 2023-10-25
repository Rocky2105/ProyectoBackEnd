using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithBD;

[Table("Usuario")]
public partial class Usuario
{
    [Key]
    public long UsuarioId { get; set; }

    [Column("Usuario", TypeName = "varchar(50)")]
    public string Usuario1 { get; set; } = null!;

    [Column(TypeName = "varchar(50)")]
    public string Password { get; set; } = null!;

    [InverseProperty("Usuario")]
    public virtual ICollection<Coordinador> Coordinadors { get; set; } = new List<Coordinador>();

    [InverseProperty("Usuario")]
    public virtual ICollection<Docente> Docentes { get; set; } = new List<Docente>();

    [InverseProperty("Usuario")]
    public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
}
