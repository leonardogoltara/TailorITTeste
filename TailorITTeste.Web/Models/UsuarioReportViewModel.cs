using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TailorITTeste.Web.Models
{
    public class UsuarioReportViewModel
    {
        public UsuarioReportViewModel()
        {
            Filter = new UsuarioFilterViewModel();
            List = new List<UsuarioReportItemViewModel>();
        }
        public UsuarioFilterViewModel Filter { get; set; }
        public List<UsuarioReportItemViewModel> List { get; set; }
    }

    public class UsuarioFilterViewModel
    {
        public string Nome { get; set; }
        public bool? Ativo { get; set; }
    }

    public class UsuarioReportItemViewModel
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string SexoDescricao { get; set; }
        public string Ativo { get; set; }
    }
}