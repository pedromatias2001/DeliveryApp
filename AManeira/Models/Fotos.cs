using System.ComponentModel.DataAnnotations.Schema;

namespace AManeira.Models
{
    public class Fotos
    {
        /// <summary>
        /// id da foot
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// nome da foto (incluir sufixo)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// chave forasteira do prato
        /// </summary>
        [ForeignKey(nameof(Prato))]
        public int PratoFK { get; set; }
        public Pratos Prato { get; set; }
    }
}
