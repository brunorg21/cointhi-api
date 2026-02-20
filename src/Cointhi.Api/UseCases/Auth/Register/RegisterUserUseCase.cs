using Cointhi.Api.Cryptography;
using Cointhi.Api.Database.Repositories;
using Cointhi.Api.Database.Repositories.User;
using Cointhi.Api.DTOs.Requests;
using Cointhi.Api.Entities;
using Cointhi.Api.Exceptions;
using FluentValidation;

namespace Cointhi.Api.UseCases.Auth.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        public RegisterUserUseCase(IUserRepository userRepository, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }
        public async Task Execute(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            Validate(request);

            var userAlreadyExists = await _userRepository.GetByEmail(request.Email, cancellationToken);

            if(userAlreadyExists is not null)
            {
                throw new UserAlreadyExistsException($"User with email {request.Email} already exists.");
            }


            var user = new User
            {
                Email = request.Email,
                Name = request.Name,
                Password = request.Password
            };

            user.Password = _passwordHasher.Encrypt(user.Password);

            await _userRepository.Add(user, cancellationToken);

            await _unitOfWork.Commit(cancellationToken);
        }

        private void Validate(RegisterUserRequest request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
