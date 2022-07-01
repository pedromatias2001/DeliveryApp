using System.ComponentModel.DataAnnotations;

namespace AManeira.Models
{
    public class Clientes
    {
        public Clientes()
        {
            ListaEncomendas = new HashSet<Encomendas>();
        }
        /// <summary>
        /// id do cliente
        /// </summary>
        public int ID { get; set; }


        /// <summary>
        /// nome do cliente
        /// </summary>
        [StringLength(30, ErrorMessage = "{0} não pode ter mais que {1} caracteres")]
        [RegularExpression("[A-ZÓÂÍa-zãáéçõàóíâôê ]+", ErrorMessage = "Caracteres não aceitáveis")]
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// morada para entrega da encomenda
        /// </summary>
        [Required]
        public string Morada { get; set; }

        /// <summary>
        /// código postal do cliente
        /// </summary>
        [RegularExpression("[0-9]{4}-[0-9]{3}", ErrorMessage = "Formato não aceitável")]
        public string CodPostal { get; set; }


        /// <summary>
        /// nº telemovel do cliente
        /// </summary>
        [Required]
        [RegularExpression("[9][0-9]{8}", ErrorMessage ="Número inválido")]
        public string Contacto { get; set; }

        /// <summary>
        /// lista de encomendas do Cliente
        /// </summary>
        public ICollection<Encomendas> ListaEncomendas { get; set; }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        /// <summary>
        /// atributo para executar a FK que permitirá ligar a tabela da 
        /// autenticação à tabela dos clientes
        /// </summary>
        public string UserID { get; set; }
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    }
}
