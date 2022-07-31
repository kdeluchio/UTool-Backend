using System;
using System.Collections.Generic;
using System.Text;

namespace UTools.Application.Dtos
{
    public class CriarEmpresaDTO
    {
        private string cnpj;
        public string CNPJ
        {
            get => cnpj?.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            set => cnpj = value;
        }
    }
}
