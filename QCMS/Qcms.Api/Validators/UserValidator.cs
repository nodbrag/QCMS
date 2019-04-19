using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Qcms.Model.DtoModel;
using Qcms.Core.Extensions;


namespace Qcms.Api.Validators
{

    public class UserValidator : AbstractValidator<UserDtos.UserDto> {

        public UserValidator()
        {
            RuleFor(x => x.UserCode).NotEmpty().WithMessage("用户号不能为空!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("用户姓名不能为空!");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("邮件格式不合法！");

            RuleFor(x => x.Telephone).Must((o, list, context) =>
            {
                return o.Telephone.IsTelephone();
            }).WithMessage("电话号码不合法!");

            RuleFor(x => x.MobilePhone).Must((o, list, context) =>
            {
                return o.MobilePhone.IsHandset();
            }).WithMessage("手机号码不合法!");

        }
    }

}
