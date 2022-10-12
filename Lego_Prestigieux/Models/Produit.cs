namespace Lego_Prestigieux.Models
{
    public enum Category
    {
        Prestigieux,
        Nouveautés,
        MeilleursVendeurs,
        Collections,
        Adultes,
        Enfants,
        StarWars,
    }
    public class Produit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public float Price { get; set; }
        public float? Reduction { get; set; }
        public bool Status { get; set; }
        public Category Category { get; set; }
        public string URL { get; set; }
    }
}
