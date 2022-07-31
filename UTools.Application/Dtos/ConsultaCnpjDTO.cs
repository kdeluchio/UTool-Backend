using System;
using System.Collections.Generic;
using System.Text;

namespace UTools.Application.Dtos
{
    public class ConsultaCnpjDTO
    {
        private string cnpj;
        public string CNPJ 
        { 
            get => cnpj?.Trim().Replace(".", "").Replace("-", "").Replace("/", ""); 
            set => cnpj=value; 
        }
        public string Nome { get; set; }
    }
}
