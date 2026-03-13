using Desafio_Tecnico.Domain.Models;
using Desafio_Tecnico.Domain.Validation;
using FluentAssertions;

namespace Desafio_Tecnico.Tests
{
    public class Clientetests
    {
        [Fact]
        public void Cliente_NomeNulo_DeveLancarException()
        {
            Action action = () => new Contato(1, null, 36);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("O Nome não pode ser nulo.");
        }


        [Fact]
        public void ClienteValidarNome()
        {
            Action action = () => new Contato(1, "It", 36);
            action.Should().Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O Nome precisa ser maior que três caracteres.");
        }
    }
}