using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1_RESTFulCSharp.Models
{
    public class Professor
    {
        int     codigo;
        string  nome;
        string  email;

        public Professor(int codigo, string nome, string email)
        {
            this.codigo = codigo;
            this.Nome = nome;
            this.Email = email;
        }

        public int Codigo { get => codigo; }

        public string Nome { get => nome;
            set
            {
                if (value.Length > 50)
                    throw new Exception("O nome deve ter no máximo 50 caracteres!");

                nome = value;
            }
        }

        public string Email { get => email;
            set
            {
                if (value.Length > 100)
                    throw new Exception("O e-mail deve ter no máximo 100 caracteres!");

                email = value;
            }
        }
    }
}