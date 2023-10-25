using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithBD;

[Table("Pedido")]
public partial class Pedido
{
    [Key]
    public long PedidoId { get; set; }

    [Column(TypeName = "date")]
    public byte[] Fecha { get; set; } = null!;

    public long LaboratorioId { get; set; }

    [Column(TypeName = "time")]
    public byte[] HoraEntrega { get; set; } = null!;

    [Column(TypeName = "time")]
    public byte[] HoraDevolucion { get; set; } = null!;

    [Column(TypeName = "varchar(2)")]
    public string Estado { get; set; } = null!;

    public long EstudianteId { get; set; }

    public long DocenteId { get; set; }

    [InverseProperty("Pedido")]
    public virtual ICollection<DescPedido> DescPedidos { get; set; } = new List<DescPedido>();

    [ForeignKey("DocenteId")]
    [InverseProperty("Pedidos")]
    public virtual Docente Docente { get; set; } = null!;

    [ForeignKey("EstudianteId")]
    [InverseProperty("Pedidos")]
    public virtual Estudiante Estudiante { get; set; } = null!;

    [ForeignKey("LaboratorioId")]
    [InverseProperty("Pedidos")]
    public virtual Laboratorio Laboratorio { get; set; } = null!;
}
