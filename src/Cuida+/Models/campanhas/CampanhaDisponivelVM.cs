namespace Cuida_.Models.campanhas
{
    public class CampanhaDisponivelVM
    {
        public int Id { get; set; }
        public string NomeCampanha { get; set; } = "";
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public bool Ativa { get; set; }
        
    }
}