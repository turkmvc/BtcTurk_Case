using BtcTrader.API.Models;

using FluentValidation;

namespace BtcTrader.API.Validators
{
    public class NewOrderRequestValidator : AbstractValidator<NewOrderRequest>
    {
        public NewOrderRequestValidator()
        {
            RuleFor(x => x.DayOfMonth)
                    .GreaterThanOrEqualTo(1).WithMessage("Ayın 1-28'inci günleri için talimat verilebilir.")
                    .LessThanOrEqualTo(28).WithMessage("Ayın 1-28'inci günleri için talimat verilebilir.");

            RuleFor(x => x.Amount)
                    .GreaterThanOrEqualTo(100).WithMessage("Mininmum 100TL talimat verilebilir.")
                    .LessThanOrEqualTo(20000).WithMessage("Maksimum 20000TL talimat verilebilir.");
        }
    }
}
