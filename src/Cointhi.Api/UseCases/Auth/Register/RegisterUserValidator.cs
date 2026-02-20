using Cointhi.Api.DTOs.Requests;
using FluentValidation;

namespace Cointhi.Api.UseCases.Auth.Register
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserValidator()
        {
            RuleFor(r => r.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("Invalid email");
            RuleFor(r => r.Name).NotEmpty().WithMessage("Name is required"); 
            RuleFor(r => r.Password).NotEmpty().MinimumLength(6).WithMessage("Password must be at least 6 characters");
        }
    }
}
