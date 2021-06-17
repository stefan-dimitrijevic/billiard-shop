using BilliardShop.Application.DataTransfer;
using BilliardShop.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Implementation.Validators
{
    public class CreateUserUseCaseValidator : AbstractValidator<UserUseCaseDto>
    {
        private readonly BilliardShopContext _context;

        public CreateUserUseCaseValidator(BilliardShopContext context)
        {
            this._context = context;

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.UserId)
                    .Must(UserExists).WithMessage(x => $"User with an id of {x.UserId} doesn't exist.")

                    .Must((dto, userid) => !context.UserUseCases.Any(
                            x => x.UserId == userid && x.UseCaseId == dto.UseCaseId && x.Id != dto.Id))
                        .WithMessage(x => $"User with an id of {x.UserId} already has use case {x.UseCaseId}.");
                });
        }
        private bool UserExists(int userId)
        {
            return _context.UserUseCases.Any(x => x.UserId == userId);
        }
    }

}
