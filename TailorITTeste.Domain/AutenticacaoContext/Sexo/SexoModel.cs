using System;

namespace TailorITTeste.Domain.AutenticacaoContext.Sexo
{
    public class SexoModel
    {
        internal SexoModel(string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                throw new InvalidOperationException("A descrição é obrigatória.");

            if (descricao.Length > 15)
                throw new InvalidOperationException("A descrição deve possuir no máximo 15 caracteres.");

            Descricao = descricao;
        }
        public SexoModel()
        {

        }
        public int SexoId { get; set; }
        public string Descricao { get; set; }

        public void Atualizar(string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                throw new InvalidOperationException("A descrição é obrigatória.");

            Descricao = descricao;
        }
    }
}
