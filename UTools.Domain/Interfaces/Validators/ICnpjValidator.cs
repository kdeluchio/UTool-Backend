using System;
using System.Collections.Generic;
using System.Text;

namespace UTools.Domain.Interfaces.Validators
{
    public interface ICnpjValidator
    {
        bool IsValid(string cnpj);
    }
}
