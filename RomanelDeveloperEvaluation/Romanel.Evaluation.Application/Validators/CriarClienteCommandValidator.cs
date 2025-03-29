using FluentValidation;
using Romanel.Evaluation.Application.Commands;

namespace Romanel.Evaluation.Application.Validators
{
    public class CriarClienteCommandValidator : AbstractValidator<CriarClienteCommand>
    {
        public CriarClienteCommandValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(100).WithMessage("Nome deve ter até 100 caracteres.");

            RuleFor(x => x.CPF)
                .NotEmpty().WithMessage("CPF é obrigatório.")
                .Length(11).WithMessage("CPF deve ter 11 dígitos.")
                .Matches(@"^\d{11}$").WithMessage("CPF deve conter apenas números.");

            RuleFor(x => x.DataNascimento)
                .NotEmpty().WithMessage("Data de nascimento é obrigatória.")
                .LessThan(DateTime.Today).WithMessage("Data de nascimento deve ser anterior a hoje.");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("Telefone é obrigatório.")
                .Matches(@"^\d{10,11}$").WithMessage("Telefone deve ter 10 ou 11 dígitos numéricos.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-mail é obrigatório.")
                .EmailAddress().WithMessage("E-mail inválido.");

            RuleFor(x => x.CEP)
                .NotEmpty().WithMessage("CEP é obrigatório.")
                .Length(8).WithMessage("CEP deve ter 8 dígitos.")
                .Matches(@"^\d{8}$").WithMessage("CEP deve conter apenas números.");

            RuleFor(x => x.Logradouro)
                .NotEmpty().WithMessage("Logradouro é obrigatório.")
                .MaximumLength(200).WithMessage("Logradouro deve ter até 200 caracteres.");

            RuleFor(x => x.Numero)
                .NotEmpty().WithMessage("Número é obrigatório.")
                .MaximumLength(10).WithMessage("Número deve ter até 10 caracteres.");

            RuleFor(x => x.Bairro)
                .NotEmpty().WithMessage("Bairro é obrigatório.")
                .MaximumLength(100).WithMessage("Bairro deve ter até 100 caracteres.");

            RuleFor(x => x.Cidade)
                .NotEmpty().WithMessage("Cidade é obrigatória.")
                .MaximumLength(100).WithMessage("Cidade deve ter até 100 caracteres.");

            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("Estado é obrigatório.")
                .Length(2).WithMessage("Estado deve ter 2 caracteres.");
        }
    }
}
