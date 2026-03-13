using Desafio_Tecnico.Domain.Enums;
using Desafio_Tecnico.Domain.Validation;
using System.Text.RegularExpressions;

namespace Desafio_Tecnico.Domain.Models
{
    public class Assinatura
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public DateTime DataInicioAssinatura { get; set; }
        public PlanoEnum Plano { get; set; }
        public decimal ValorMensalAssinatura { get; set; }
        public bool StatusAssinatura { get; set; }
        public int TempoAssinaturaMeses { get; set; }


        public Assinatura(int id, string nomeCompleto, string email, DateTime dataInicioAssinatura,
        PlanoEnum plano, decimal valorMensalAssinatura, int tempoAssinaturaMeses, bool statusAssinatura)
        {
            Id = id;
            NomeCompleto = nomeCompleto;
            Email = email;
            DataInicioAssinatura = dataInicioAssinatura;
            Plano = plano;
            ValorMensalAssinatura = valorMensalAssinatura;
            TempoAssinaturaMeses = tempoAssinaturaMeses;
            StatusAssinatura = statusAssinatura;
            ValidateDomain(nomeCompleto, email, dataInicioAssinatura, valorMensalAssinatura, tempoAssinaturaMeses);
        }

        private void ValidateDomain(string nome, string email, DateTime dataInicio,
            decimal valorMensal, int tempoAssinatura)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "O Nome não pode ser nulo.");

            DomainExceptionValidation.When(nome.Length < 3,
                "O Nome precisa ser maior que três caracteres.");

            DomainExceptionValidation.When(tempoAssinatura == 0,
                "O tempo de assinatura não pode ser igual a 0.");

            DomainExceptionValidation.When(dataInicio > DateTime.Now,
                "A data de início da assinatura não pode ser maior que a data atual.");

            DomainExceptionValidation.When(valorMensal <= 0,
                "O valor mensal da assinatura deve ser maior que 0.");

            DomainExceptionValidation.When(!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"),
                "O e-mail deve possuir um formato válido.");
        }


    }
}
