using FluentValidation;
using ImdbServices.Dtos;
using ImdbServices.Services;
using System.Linq;

namespace ImdbServices.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        private readonly IUserService _userService;

        public UserValidator(IUserService userService)
        {
            _userService = userService;

            RuleFor(user => user.Username).Must(ValidarUsernameUnico).NotEmpty().NotNull().WithMessage("O campo username deve ser único de com mais de 5 caracteres");
            RuleFor(user => user.Password).NotEmpty().NotNull().WithMessage("O campo password não pode ser vazio");
        }

        private bool ValidarUsernameUnico(UserDto model, string username)
        {
            if (username.Length < 5)
                return false;

            var entity = _userService.GetAll().FirstOrDefault(x => x.Username == username && x.Id != model.Id);
            if (entity != null)
                return false;

            return true;
        }
    }
}
