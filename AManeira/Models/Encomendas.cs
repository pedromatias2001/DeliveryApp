using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AManeira.Models
{
    public class Encomendas
    {
        public Encomendas()
        {
            ListaEncomendasPratos = new HashSet<EncomendasPratos>();
        }
        
        /// <summary>
        /// id da encomenda
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// preço total da encomenda
        /// </summary>
        [Display (Name= "Preço Total")]
        public decimal PrecoTotal { get; set; }

        /// <summary>
        /// data e hora da entrega da encomenda
        /// </summary>
        [Display(Name = "Data e hora da entrega")]
        public DateTime DataHoraEntrega { get; set; }

        /// <summary>
        /// estado da encomenda
        /// </summary>
        [Display(Name = "Ativa")]
        public Boolean IsActive { get; set; }

        /// <summary>
        /// chave forasteira do cliente
        /// </summary>
        [ForeignKey(nameof(Cliente))]
        public int ClienteFK { get; set; }
        public Clientes Cliente { get; set; }

        /// <summary>
        /// lista de pratos da Encomenda
        /// </summary>
        public ICollection<EncomendasPratos> ListaEncomendasPratos { get; set; }
    }
}
