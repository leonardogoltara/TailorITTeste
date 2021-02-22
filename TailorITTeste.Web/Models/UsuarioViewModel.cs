using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TailorITTeste.Web.Models
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {

        }
        [ScaffoldColumn(false)]
        public int UsuarioId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O {0} deve possuir pelo menos {1} caracteres.")]
        [MaxLength(200, ErrorMessage = "O {0} deve possuir no máximo {1} caracteres.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A data de nascimento é obrigatória.")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [MaxLength(100, ErrorMessage = "O {0} deve possuir no máximo {1} caracteres.")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [MaxLength(30, ErrorMessage = "A {0} deve possuir no máximo {1} caracteres.")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Display(Name = "Confirme a senha")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Senha")]
        public string ConfirmeSenha { get; set; }

        public bool Ativo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O sexo é obrigatório.")]
        [ScaffoldColumn(false)]
        [Display(Name = "Sexo")]
        public long SexoSelecionado { get; set; }
        public SelectList Sexos { get; set; }

        public SexoViewModel Sexo { get; set; }

    }
}