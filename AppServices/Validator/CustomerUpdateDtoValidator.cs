using AppModels.Mapper;
using FluentValidation;

namespace AppServices.Validator
{
    public class CustomerUpdateDtoValidator : AbstractValidator<CustomerUpdateDto>
    {
        public CustomerUpdateDtoValidator()
        {
            RuleFor(customer => customer.FullName)
                .NotEmpty().WithMessage("O campo Nome Completo é obrigatório. ");

            RuleFor(customer => customer.Email)
                .NotEmpty().WithMessage("O campo Email é obrigatório. ")
                .EmailAddress().WithMessage("Este endereço de e-mail não é válido. ")
                .Equal(customer => customer.EmailConfirmation).WithMessage("Os e-mails informados devem ser os mesmos. ");

            RuleFor(customer => customer.Cpf)
                .NotNull().WithMessage("CPF não pode estar em branco.")
                .Must(cpf => ValidateCpf(cpf)).WithMessage("Este CPF não é válido. ");

            RuleFor(customer => customer.DateOfBirth)
                .NotEmpty().WithMessage("O campo Data de Nascimento é obrigatório. ");

            RuleFor(customer => customer.Country)
                .NotEmpty().WithMessage("O campo País é obrigatório. ");

            RuleFor(customer => customer.City)
                .NotEmpty().WithMessage("O campo Cidade é obrigatório. ");

            RuleFor(customer => customer.PostalCode)
                .NotEmpty().WithMessage("O campo CEP é obrigatório. ")
                .Length(8).WithMessage("Este CEP não é válido ");

            RuleFor(customer => customer.Address)
                .NotEmpty().WithMessage("O campo Endereço é obrigatório. ");

            RuleFor(customer => customer.Number)
                .NotEmpty().WithMessage("O campo Número é obrigatório. ");
        }

        public bool ValidateCpf(string cpf)
        {
            int[] firstMultiplier = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] secondMultiplier = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum = 0;
            int module;
            string finalDigits;

            if (cpf.Length != 11) return false;            

            if (cpf.All(x =>x == cpf.First())) return false;

            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(cpf[i].ToString()) * firstMultiplier[i];
            }
            module = sum % 11;

            if (module < 2)
            {
                module = 0;
            }
            else
            {
                module = 11 - module;
            }
            finalDigits = module.ToString();
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(cpf[i].ToString()) * secondMultiplier[i];
            }
            module = sum % 11;
            if (module < 2)
            {
                module = 0;
            }
            else
            {
                module = 11 - module;
            }
            finalDigits += module.ToString();
            return cpf.EndsWith(finalDigits);
        }
    }
}
