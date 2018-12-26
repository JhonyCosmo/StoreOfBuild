using System;
using System.Collections.Generic;
using System.Text;

namespace StoreOfBuild.Domain.Products
{
    public class Category : Entity
    {
        public string Name { get;  set; }

        protected Category() { }

        public Category(string name)
        {
            ValidateNameAndSetName(name);   
        }

        private void ValidateNameAndSetName(string name)
        {
            //Lançando exceção caso o dado esteja inválido
            Domain.DomainException.When(string.IsNullOrEmpty(name), "Name is required");
            DomainException.When(name.Length < 3, "Name invalid");
            //Impossibilita que o usuário lance dados errados nos ojetos
            //Usando o conceito de classe ativa
            //A mesma nunca podera possuir dados inválidos, por esse motivo as propriedades
            //só podem ter seus valores alterados pelo construtor, que está validando os dados.

            this.Name = name;
        }

        public void Update(string name)
        {
            ValidateNameAndSetName(name);
        }
    }
}
