using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1_RESTFulCSharp.Models
{
    public class Aluno
    {
        string ra;
        string nome;
        string email;

        public Aluno(string ra, string nome, string email)
        {
            this.Ra = ra;
            this.Nome = nome;
            this.Email = email;
        }

        public string Ra { get => ra; set
            {
                if (value.Length != 5)
                    throw new Exception("O RA não está em formato correto.");

                ra = value;
            }
         }

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
                    throw new Exception("O e-mail deve ter no máximo 100 caracteres");

                email = value;
            }
        }
    }
}