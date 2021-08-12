using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using StockWatcher.Models;

namespace StockWatcher.ViewModels.Utils
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
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
