using System.Text.RegularExpressions;
using FluentValidation;
using Training2.Models.DTO;

namespace Training2.Validator
{
    public class ValidatorRequestCustomer : AbstractValidator<CustomerReqDTO>
    {
        public ValidatorRequestCustomer()
        {
            RuleFor(x => x.nama).NotEmpty().MinimumLength(1).WithMessage("Name is not Valid!");
            RuleFor(x => x.PhoneNumber).NotEmpty().MinimumLength(9).MaximumLength(13).Must(validPhoneNumber).WithMessage("PhoneNumber must be numeric!");
            ;
            //RuleFor(x => x.alamat).NotEmpty().Must(validAddress);
        }

        public bool validPhoneNumber(string phone)
        {
            string regxNumberOnly = @"^\d+$";
            if (Regex.IsMatch(phone, regxNumberOnly))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
