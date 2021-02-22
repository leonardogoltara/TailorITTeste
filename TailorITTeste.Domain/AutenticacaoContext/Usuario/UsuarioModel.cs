using System;
using TailorITTeste.Domain.AutenticacaoContext.Sexo;

namespace TailorITTeste.Domain.AutenticacaoContext.Usuario
{
    public class UsuarioModel
    {
        internal UsuarioModel(string nome, DateTime? dataNascimento, string email, string senha, int? sexoId)
        {

            if (string.IsNullOrEmpty(nome))
                throw new InvalidOperationException("O nome é obrigatório.");

            if (nome.Length < 3)
                throw new InvalidOperationException("O nome deve possuir pelo menos 3 caracteres.");

            if (nome.Length > 200)
                throw new InvalidOperationException("O nome deve possuir no máximo 200 caracteres.");

            if (!string.IsNullOrEmpty(email) && email.Length > 100)
                throw new InvalidOperationException("O e-mail deve possuir no máximo 100 caracteres.");

            if (!string.IsNullOrEmpty(senha) && senha.Length > 30)
                throw new InvalidOperationException("A senha deve possuir no máximo 30 caracteres.");

            if (dataNascimento == null || dataNascimento.Value.Year < (DateTime.Today.Year - 200))
                throw new InvalidOperationException("A data de nascimento é obrigatória.");

            if (sexoId == null)
                throw new InvalidOperationException("O sexo é obrigatório.");

            Nome = nome;
            DataNascimento = dataNascimento.Value;
            Email = email;
            Senha = senha;
            SexoId = sexoId.Value;
            Ativo = true;
        }
        public UsuarioModel()
        {

        }
        public int UsuarioId { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public int SexoId { get; private set; }
        public bool Ativo { get; private set; }
        public virtual SexoModel Sexo { get; private set; }

        public void Desativar()
        {
            Ativo = false;
        }
        public void Ativar()
        {
            Ativo = true;
        }
        public void Atualizar(string nome, DateTime? dataNascimento, string email, string senha, int? sexoId)
        {
            if (string.IsNullOrEmpty(nome))
                throw new InvalidOperationException("O nome é obrigatório.");

            if (nome.Length < 3)
                throw new InvalidOperationException("O nome deve possuir pelo menos 3 caracteres.");

            if (nome.Length > 200)
                throw new InvalidOperationException("O nome deve possuir no máximo 200 caracteres.");

            if (!string.IsNullOrEmpty(email) && email.Length > 100)
                throw new InvalidOperationException("O e-mail deve possuir no máximo 100 caracteres.");

            if (!string.IsNullOrEmpty(senha) && senha.Length > 30)
                throw new InvalidOperationException("A senha deve possuir no máximo 30 caracteres.");

            if (dataNascimento == null || dataNascimento.Value.Year < (DateTime.Today.Year - 200))
                throw new InvalidOperationException("A data de nascimento é obrigatória.");

            if (sexoId == null)
                throw new InvalidOperationException("O sexo é obrigatório.");

            Nome = nome;
            DataNascimento = dataNascimento.Value;
            Email = email;
            Senha = senha;
            SexoId = sexoId.Value;
        }
    }
}
