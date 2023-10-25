using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithBD;

[Table("Material")]
public partial class Material
{
    [Key]
    public long MaterialId { get; set; }

    public long ModeloId { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string Descripcion { get; set; } = null!;

    public long YearEntrada { get; set; }

    public long MarcaId { get; set; }

    public long CategoriaId { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string Serie { get; set; } = null!;

    [Column(TypeName = "decimal(18,2)")]
    public byte[] ValorHistorico { get; set; } = null!;

    [ForeignKey("CategoriaId")]
    [InverseProperty("Materials")]
    public virtual Categorium Categoria { get; set; } = null!;

    [InverseProperty("Material")]
    public virtual ICollection<DescPedido> DescPedidos { get; set; } = new List<DescPedido>();

    [InverseProperty("Material")]
    public virtual ICollection<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();

    [ForeignKey("MarcaId")]
    [InverseProperty("Materials")]
    public virtual Marca Marca { get; set; } = null!;

    [ForeignKey("ModeloId")]
    [InverseProperty("Materials")]
    public virtual Modelo Modelo { get; set; } = null!;
}
