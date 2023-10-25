using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithBD;

[Table("Desc_Pedido")]
public partial class DescPedido
{
    [Key]
    [Column("Desc_PedidoId")]
    public long DescPedidoId { get; set; }

    public long Cantidad { get; set; }

    public long PedidoId { get; set; }

    public long MaterialId { get; set; }

    [ForeignKey("MaterialId")]
    [InverseProperty("DescPedidos")]
    public virtual Material Material { get; set; } = null!;

    [ForeignKey("PedidoId")]
    [InverseProperty("DescPedidos")]
    public virtual Pedido Pedido { get; set; } = null!;
}
