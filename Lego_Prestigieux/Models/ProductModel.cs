using System.Diagnostics.CodeAnalysis;

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

    public enum Status
    {
        Disponible,
        Indisponible
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
