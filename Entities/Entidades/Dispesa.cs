using Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{
    [Table("Dispesa")]
    public class Dispesa : Base
    {
        public decimal Valor { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public EnumTipoDispesa TipoDispesa { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime DataPagamento { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool Pago { get; set; }
        public bool DispesaAtrasada { get; set; }

        [ForeignKey("Categoria")]
        [Column(Order =1)]
        public int IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
