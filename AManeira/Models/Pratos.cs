using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AManeira.Models
{
    public class Pratos
    {
        public Pratos()
        {
            ListaEncomendasPratos = new HashSet<EncomendasPratos>();
            ListaFotos = new HashSet<Fotos>();
        }

        /// <summary>
        /// id do prato
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// nome do prato
        /// </summary>
        public string Nome { get; set; }


        /// <summary>
        /// preço do prato
        /// </summary>
        [NotMapped]  // this anotation tells the EF that this attribute must not be represented on database
        [RegularExpression("[0-9]{1,8}[,.]?[0-9]{0,2}", ErrorMessage = "Formato não aceitável")]
        [Display(Name = "Preço")]
        public string AuxPreco { get; set; }
        public decimal Preco { get; set; }

        /// <summary>
        /// foto associada ao prato
        /// </summary>
        public string Foto { get; set; }

        /// <summary>
        /// descrição do prato
        /// </summary>
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }


        /// <summary>
        /// quantidade disponível do prato
        /// </summary>
        public int NumStock { get; set; }

        /// <summary>
        /// lista de encomendas do Prato
        /// </summary>
        public ICollection<EncomendasPratos> ListaEncomendasPratos { get; set; }
        /// <summary>
        /// lista de fotos do Prato
        /// </summary>
        public ICollection<Fotos> ListaFotos { get; set; }
    }
}
