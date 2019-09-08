namespace OdisseiaWeb.Models
{
    public class Alternativa
    {
        public int Id { get; set; }
        public int FkQuestao { get; set; }
        public string Texto { get; set; }
        public bool Correto { get; set; }
    }
}
