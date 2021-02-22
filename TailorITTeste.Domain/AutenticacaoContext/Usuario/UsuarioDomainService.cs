using System;
using System.Collections.Generic;
using TailorITTeste.Domain.AutenticacaoContext.Sexo;

namespace TailorITTeste.Domain.AutenticacaoContext.Usuario
{
    public class UsuarioDomainService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISexoRepository _sexoRepository;
        public UsuarioDomainService(IUsuarioRepository usuarioRepository, ISexoRepository sexoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _sexoRepository = sexoRepository;
        }

        public void Inserir(string nome, DateTime? dataNascimento, string email, string senha, int sexoId)
        {
            try
            {
                SexoModel sexo = _sexoRepository.Find(sexoId);

                if (sexo == null)
                    throw new Exception("Sexo não encontrado.");

                UsuarioModel usuario = new UsuarioModel(nome, dataNascimento, email, senha, sexoId);

                _usuarioRepository.Save(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Atualizar(int id, string nome, DateTime? dataNascimento, string email, string senha, int sexoId, bool ativo)
        {
            try
            {
                UsuarioModel usuario = _usuarioRepository.Find(id);

                if (usuario == null)
                    throw new Exception("Usuário não encontrado.");

                SexoModel sexo = _sexoRepository.Find(sexoId);

                if (sexo == null)
                    throw new Exception("Sexo não encontrado.");

                usuario.Atualizar(nome, dataNascimento, email, senha, sexo.SexoId);

                if (ativo)
                    usuario.Ativar();
                else
                    usuario.Desativar();

                _usuarioRepository.Save(usuario);
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
                UsuarioModel usuario = _usuarioRepository.Find(id);

                if (usuario == null)
                    throw new Exception("Usuário não encontrado.");

                _usuarioRepository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public UsuarioModel Find(int id)
        {
            try
            {
                UsuarioModel usuario = _usuarioRepository.Find(id);

                if (usuario == null)
                    throw new Exception("Usuário não encontrado.");

                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<UsuarioModel> List(string nome, bool? ativo)
        {
            try
            {
                return _usuarioRepository.List(nome, ativo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Ativar(int id)
        {
            try
            {
                UsuarioModel usuario = _usuarioRepository.Find(id);

                if (usuario == null)
                    throw new Exception("Usuário não encontrado.");

                usuario.Ativar();

                _usuarioRepository.Save(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Desativar(int id)
        {
            try
            {
                UsuarioModel usuario = _usuarioRepository.Find(id);

                if (usuario == null)
                    throw new Exception("Usuário não encontrado.");

                usuario.Desativar();

                _usuarioRepository.Save(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}