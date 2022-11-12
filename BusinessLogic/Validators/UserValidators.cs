using BusinessLogic.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validators
{
    public class UserValidators : AbstractValidator<UserDto>
    {
        public UserValidators()
        {
            RuleFor(x => x.Id).Null();

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();
        }
    }
}
