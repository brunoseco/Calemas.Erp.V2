using System;
using Flunt.Validations;

namespace Common.Validation
{
    public class ValidationContract : Contract
    {

        public Contract IsValidCPF(string cpf, string property, string message)
        {
            if (!cpf.IsCpfValid()) this.AddNotification(property, message);
            return this;
        }

    }
}
