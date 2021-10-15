using System;
using System.Collections.Generic;

namespace Business
{
    public class Cliente
    {
        public string Nome { get; set; }
        public List<Cliente> Clientes(string nome)
        {
            var clientes = new List<Cliente>();
            clientes.Add(new Cliente() { Nome = "Bruno" });
            return clientes;
        }
    }
}
