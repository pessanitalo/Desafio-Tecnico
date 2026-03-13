using Desafio_Tecnico.Domain.Validation;

namespace Desafio_Tecnico.Domain.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string NomeContato { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public int Idade { get; set; }
        public bool Ativo { get; set; }


        public Contato(int id, string nomeContato, int idade)
        {
            Id = id;
            NomeContato = nomeContato;
            Idade = idade;
            ValidateDomain(nomeContato, idade);
        }

        private void ValidateDomain(string nome, int idade)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "O Nome não pode ser nulo.");
            DomainExceptionValidation.When(nome.Length < 3, "O Nome precisa ser maior que três caracteres.");
            NomeContato = nome;
            Idade = idade;
        }


    }
}
