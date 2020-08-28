using System;
using FluentValidator.Validation;
using TDA.Shared.ValueObjects;

namespace TDA.Domain.ValueObjects
{
    public class Email : ValueObject
    {

        public Email(string address)
        {
            Address = address;
            AddNotifications(new ValidationContract()
            .Requires()
            .IsEmail(Address, "Email.Address", "E-mail inválido")
            );
        }
        public String Address { get; private set; }

        public override string ToString()
        {
            return Address.ToString();
        }
    }
}