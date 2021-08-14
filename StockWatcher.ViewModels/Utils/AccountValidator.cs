using FluentValidation;
using StockWatcher.Models;

namespace StockWatcher.ViewModels.Utils
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(c => c.LastName)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(64);
            RuleFor(c => c.Password)
                .NotEmpty()
                .MinimumLength(6)
                .Matches("[Aa-zZ]")
                .Matches("[0-9]")
                .Matches("[^A-Z0-9]")
                .WithMessage("Password must contains at least 6 characters with letters and digits");
            RuleFor(c => c.PasswordConfirmation).Equal(c => c.Password).WithMessage("Passwords much be identical");
        }


    }
}
