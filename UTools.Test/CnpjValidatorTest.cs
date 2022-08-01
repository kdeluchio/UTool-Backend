using System;
using UTools.Domain.Interfaces.Validators;
using UTools.Domain.Validators;
using Xunit;

namespace UTools.Test
{
    public class CnpjValidatorTest
    {
        private readonly ICnpjValidator _cnpjValidator;

        public CnpjValidatorTest()
        {
            _cnpjValidator = new CnpjValidator();  
        }

        [Fact]
        public void ValidCNPJ()
        {
            Assert.True(_cnpjValidator.IsValid("39.381.712/0001-33"));
        }

        [Fact]
        public void InvalidCNPJ()
        {

            Assert.True(!_cnpjValidator.IsValid("39.381.712/0001-00"));
        }

    }
}
