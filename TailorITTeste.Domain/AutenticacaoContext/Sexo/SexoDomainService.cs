using System;
using System.Collections.Generic;

namespace TailorITTeste.Domain.AutenticacaoContext.Sexo
{
    public class SexoDomainService
    {
        private readonly ISexoRepository _sexoRepository;
        public SexoDomainService(ISexoRepository sexoRepository)
        {
            _sexoRepository = sexoRepository;
        }

        public void Inserir(string descricao)
        {
            try
            {
                SexoModel sexo = new SexoModel(descricao);

                _sexoRepository.Save(sexo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Atualizar(int id, string descricao)
        {
            try
            {
                SexoModel sexo = _sexoRepository.Find(id);

                if (sexo == null)
                    throw new Exception("Sexo não encontrado.");
                                
                sexo.Atualizar(descricao);

                _sexoRepository.Save(sexo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Excluir(int id)
        {
            try
            {
                SexoModel Sexo = _sexoRepository.Find(id);

                if (Sexo == null)
                    throw new Exception("Sexo não encontrado.");

                _sexoRepository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<SexoModel> List()
        {
            try
            {
                return _sexoRepository.List();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}