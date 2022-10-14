using System.ComponentModel.DataAnnotations;

namespace Lego_Prestigieux.Models
{
    public enum Price
    {
        [Display(Name = "↑")]
        Descending,
        [Display(Name = "↓")]
        Ascending
    }
    public class FilterModel
    {
        public bool Descending { get; set; } = true;
        public int NbResult { get; set; } = int.MaxValue;
        public float MaxPrice { get; set; } = float.MaxValue;
        public float MinPrice { get; set; } = 0;
        public Status? Status { get; set; } = null;
        public Category? Category { get; set; } = null;
        public string SearchName { get; set; } = "";
        public float MinReduction { get; set; } = 0;
    }
}
