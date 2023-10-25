using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithBD;

[Table("Laboratorio")]
public partial class Laboratorio
{
    [Key]
    public long LaboratorioId { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "nvarchar(100)")]
    public string Descripcion { get; set; } = null!;

    [InverseProperty("Laboratorio")]
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
