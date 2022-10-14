using System.Diagnostics.CodeAnalysis;

namespace Lego_Prestigieux.Models
{
    public enum Category
    {
        Prestigieux = 0,
        Nouveautés = 1,
        MeilleursVendeurs = 2,
        Collections = 3,
        Adultes = 4,
        Enfants = 5,
        StarWars = 6
    }

    public enum Status
    {
        Disponible = 0,
        Indisponible = 1
    }
    public class ProductModel
    {
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; }
        public string Detail { get; set; }
        public float Price { get; set; }
        public float? Reduction { get; set; } = 0;
        public int Quantity { get; set; }
        public Status Status { get; set; }
        public Category Category { get; set; }
        public string URL { get; set; }
    }
}
