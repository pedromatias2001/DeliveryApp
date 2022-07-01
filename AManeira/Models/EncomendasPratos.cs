using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AManeira.Models
{
    public class EncomendasPratos
    {
        public int Id { get; set; }

        /// <summary>
        /// chave forasteira do prato
        /// </summary>
        [ForeignKey(nameof(Prato))]
        public int PratoFK { get; set; }
        public Pratos Prato { get; set; }


        /// <summary>
        /// chave forasteira da encomenda
        /// </summary>
        [ForeignKey(nameof(Encomenda))]
        public int EncomendaFK { get; set; }
        public Encomendas Encomenda { get; set; }

        /// <summary>
        /// número de vezes que o prato foi adicionado
        /// </summary>
        public int Quantidade { get; set; }
    }
}
