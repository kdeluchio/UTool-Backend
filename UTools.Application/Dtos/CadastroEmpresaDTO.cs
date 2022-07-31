using System;
using System.Collections.Generic;
using System.Text;

namespace UTools.Application.Dtos
{
    public class CadastroEmpresaDTO
    {
        private string cnpj;
        public string CNPJ
        {
            get => cnpj?.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            set => cnpj = value;
        }
        public string Abertura { get; set; }
        public string Situacao { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public string Fantasia { get; set; }
        public string Porte { get; set; }
        public string Natureza_juridica { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Municipio { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Data_situacao { get; set; }
        public string Capital_social { get; set; }
        public List<CnaeDTO> Atividade_principal { get; set; }
    }

    public class CnaeDTO
    {
        public string Code { get; set; }
        public string Text { get; set; }
    }

}
