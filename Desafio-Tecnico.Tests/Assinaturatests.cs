using Desafio_Tecnico.Domain.Enums;
using Desafio_Tecnico.Domain.Models;
using Desafio_Tecnico.Domain.Validation;
using FluentAssertions;

namespace Desafio_Tecnico.Tests
{
    public class Assinaturatests
    {
        [Fact]
        public void Assinatura_TempoAssinaturaZero_DeveLancarException()
        {
            Action action = () => new Assinatura(1, "João Silva", "joao@email.com",
                DateTime.Now.AddMonths(-1), PlanoEnum.Basico, 99.0m, true);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("O tempo de assinatura não pode ser igual a 0.");
        }

        [Fact]
        public void Assinatura_DataInicioMaiorQueDataAtual_DeveLancarException()
        {
            Action action = () => new Assinatura(1, "João Silva", "joao@email.com",
                DateTime.Now.AddDays(1), PlanoEnum.Basico, 99.0m,  true);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("A data de início da assinatura não pode ser maior que a data atual.");
        }

        [Fact]
        public void Assinatura_ValorMensalZero_DeveLancarException()
        {
            Action action = () => new Assinatura(1, "João Silva", "joao@email.com",
                DateTime.Now.AddMonths(-1), PlanoEnum.Basico, 0m,  true);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("O valor mensal da assinatura deve ser maior que 0.");
        }

        [Fact]
        public void Assinatura_EmailFormatoInvalido_DeveLancarException()
        {
            Action action = () => new Assinatura(1, "João Silva", "emailinvalido",
                DateTime.Now.AddMonths(-1), PlanoEnum.Basico, 99.0m,  true);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("O e-mail deve possuir um formato válido.");
        }

        [Fact]
        public void Assinatura_DadosValidos_DeveCriarComSucesso()
        {
            var assinatura = new Assinatura(1, "João Silva", "joao@email.com",
                DateTime.Now.AddMonths(-1), PlanoEnum.Basico, 99.0m, true);
            assinatura.Should().NotBeNull();
        }
    }
}