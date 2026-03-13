using Desafio_Tecnico.Domain.Enums;
using Desafio_Tecnico.Domain.Validation;

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


        public Assinatura(int id, string nomeCompleto, string email)
        {
            Id = id;
            NomeCompleto = nomeCompleto;
            Email = email;
            ValidateDomain(nomeCompleto, email);
        }

        private void ValidateDomain(string nome, string email)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "O Nome não pode ser nulo.");
            DomainExceptionValidation.When(nome.Length < 3, "O Nome precisa ser maior que três caracteres.");
            NomeCompleto = nome;
            Email = email;
        }


    }
}
