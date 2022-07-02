namespace AManeira.Models
{   
    /// <summary>
    /// Este viewmodel irá recolher os dados dos Pratos que a API 
    /// irá apresentar na sua interface
    /// </summary>
    public class PratosViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int NumStock { get; set; }
        public string Descricao { get; set; }
        public string Fotografia { get; set; }
    }
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}