using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithBD;

[Table("Estudiante")]
public partial class Estudiante
{
    [Key]
    public long EstudianteId { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "varchar(50)")]
    public string ApellidoPaterno { get; set; } = null!;

    [Column(TypeName = "varchar(50)")]
    public string ApellidoMaterno { get; set; } = null!;

    public long SemestreId { get; set; }

    public long GrupoId { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public byte[] Adeudo { get; set; } = null!;

    [Column(TypeName = "varchar(100)")]
    public string Correo { get; set; } = null!;

    public long PlantelId { get; set; }

    public long UsuarioId { get; set; }

    [ForeignKey("GrupoId")]
    [InverseProperty("Estudiantes")]
    public virtual Grupo Grupo { get; set; } = null!;

    [InverseProperty("Estudiante")]
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    [ForeignKey("PlantelId")]
    [InverseProperty("Estudiantes")]
    public virtual Plantel Plantel { get; set; } = null!;

    [ForeignKey("SemestreId")]
    [InverseProperty("Estudiantes")]
    public virtual Semestre Semestre { get; set; } = null!;

    [ForeignKey("UsuarioId")]
    [InverseProperty("Estudiantes")]
    public virtual Usuario Usuario { get; set; } = null!;
}
