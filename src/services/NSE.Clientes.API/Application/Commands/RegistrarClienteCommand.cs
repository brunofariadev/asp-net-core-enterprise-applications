using FluentValidation;
using NSE.Core.DomainObjects;
using NSE.Core.Messages;
using System;

namespace NSE.Clientes.API.Application.Commands
{
    public class RegistrarClienteCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

        public RegistrarClienteCommand(Guid id, string nome, string email, string cpf)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegistrarClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RegistrarClienteCommandValidation : AbstractValidator<RegistrarClienteCommand>
    {
        public RegistrarClienteCommandValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome do cliente não foi informado");

            RuleFor(c => c.Cpf)
                .Must(CpfIsValid)
                .WithMessage("Cpf informado inválido");

            RuleFor(c => c.Email)
                .Must(EmailIsValid)
                .WithMessage("Email informado inválido");
        }

        protected static bool CpfIsValid(string cpf)
        {
            return Cpf.Validar(cpf);
        }

        protected static bool EmailIsValid(string email)
        {
            return Email.Validar(email);
        }
    }
}
