using FluentValidation;
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
        public int Page { get; set; } = 1;
        public int PageMax { get; set; } = 0;
        public bool Descending { get; set; } = true;
        public int NbResult { get; set; } = int.MaxValue;
        public float MaxPrice { get; set; } = float.MaxValue;
        public float MinPrice { get; set; } = 0;
        public Status? Status { get; set; } = null;
        public Category? Category { get; set; } = null;
        public string SearchName { get; set; } = "";
        public float MinReduction { get; set; } = 0;
    }

    public class FilterValidator : AbstractValidator<FilterModel>
    {
        public FilterValidator()
        {
            RuleFor(e => e.MinPrice).LessThan(e => e.MaxPrice).WithMessage("The minimum price must be lower than the maximum price");
            RuleFor(e => e.MaxPrice).LessThan(e => e.MinPrice).WithMessage("The maximum price must be higher than the minimum price");
            RuleFor(e => e.MinReduction).LessThan(100).WithMessage("The minimum reduction must be less than or equal to 100");
        }
    }
}
