using FluentValidation;
using CustomerManager.Core.Entities;

namespace CustomerManager.Core.Validators.Impl
{
    public sealed class CustomerValidator : AbstractValidator<Customer>, ICustomerValidator
    {
        #region Constructors

        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Birthday).NotNull();
            RuleFor(x => x.DocumentId).NotNull();
            RuleFor(x => x.SocialSecurityId).NotNull();
        }

        #endregion
    }
}
