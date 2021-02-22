using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TailorITTeste.Domain.AutenticacaoContext.Sexo;
using TailorITTeste.Domain.AutenticacaoContext.Usuario;
using TailorITTeste.Repository.AutenticacaoContext.Sexo;
using TailorITTeste.Repository.AutenticacaoContext.Usuario;
using TailorITTeste.Web.Models;

namespace TailorITTeste.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioDomainService _usuarioDomainService;
        private readonly SexoDomainService _sexoDomainService;
        public UsuarioController(UsuarioDomainService usuarioDomainService, SexoDomainService sexoDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
            _sexoDomainService = sexoDomainService;
        }
        public UsuarioController()
        {
            // TODO: Divida técnica - Tem que arrumar a injeção depois.
            _usuarioDomainService = new UsuarioDomainService(new UsuarioRepository(), new SexoRepository());
            _sexoDomainService = new SexoDomainService(new SexoRepository());
        }

        // GET: Usuario
        public ActionResult Index(UsuarioReportViewModel reportViewModel)
        {
            try
            {
                if (Session["Message"] != null)
                    ViewBag.Message = Session["Message"].ToString();
                Session["Message"] = null;


                if (reportViewModel == null)
                    reportViewModel = new UsuarioReportViewModel();

                IEnumerable<UsuarioModel> usuarios = null;
                usuarios = _usuarioDomainService.List(reportViewModel.Filter.Nome, reportViewModel.Filter.Ativo);

                if (usuarios != null && usuarios.Any())
                    reportViewModel.List = usuarios.Select(u => new UsuarioReportItemViewModel()
                    {
                        UsuarioId = u.UsuarioId,
                        Nome = u.Nome,
                        DataNascimento = u.DataNascimento,
                        Email = u.Email,
                        SexoDescricao = u.Sexo.Descricao,
                        Ativo = u.Ativo ? "Sim" : "Não"
                    })?.ToList();

                return View(reportViewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(new UsuarioReportViewModel());
            }
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            try
            {
                UsuarioViewModel usuarioViewModel = new UsuarioViewModel
                {
                    Sexos = LoadSexos()
                };

                return View(usuarioViewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(new UsuarioViewModel());
            }
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioViewModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (usuario.Senha != usuario.ConfirmeSenha)
                        throw new Exception("A senha difere da confirmação de senha.");

                    int.TryParse(usuario.SexoSelecionado.ToString(), out int sexoId);

                    _usuarioDomainService.Inserir(usuario.Nome, usuario.DataNascimento, usuario.Email, usuario.Senha, sexoId);

                    Session["Message"] = "Usuário inserido com sucesso.";
                    return RedirectToAction("Index");
                }
                else
                {
                    usuario.Sexos = LoadSexos();

                    return View(usuario);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                usuario.Sexos = LoadSexos();

                return View(usuario);
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                UsuarioModel usuario = _usuarioDomainService.Find(id);

                UsuarioViewModel usuarioViewModel = new UsuarioViewModel()
                {
                    UsuarioId = usuario.UsuarioId,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    DataNascimento = usuario.DataNascimento,
                    SexoSelecionado = usuario.SexoId,
                    Ativo = usuario.Ativo
                };

                usuarioViewModel.Sexos = LoadSexos();

                return View(usuarioViewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                var usuario = new UsuarioViewModel
                {
                    Sexos = LoadSexos()
                };

                return View(usuario);
            }
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UsuarioViewModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (usuario.Senha != usuario.ConfirmeSenha)
                        throw new Exception("A senha difere da confirmação de senha.");

                    _usuarioDomainService.Atualizar(id, usuario.Nome, usuario.DataNascimento, usuario.Email, usuario.Senha, int.Parse(usuario.SexoSelecionado.ToString()), usuario.Ativo);

                    Session["Message"] = "Usuário atualizado com sucesso.";
                    return RedirectToAction("Index");
                }
                else
                {
                    usuario.Sexos = LoadSexos();

                    return View(usuario);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                usuario.Sexos = LoadSexos();

                return View(usuario);
            }
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _usuarioDomainService.Desativar(id);

                ViewBag.Message = "Usuário desativado com sucesso.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Recover(int id)
        {
            try
            {
                _usuarioDomainService.Ativar(id);

                ViewBag.Message = "Usuário ativado com sucesso.";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private SelectList LoadSexos()
        {
            var sexos = _sexoDomainService.List()?.ToList();
            if (sexos == null)
                return null;

            return new SelectList(sexos, "SexoId", "Descricao");
        }
    }
}
