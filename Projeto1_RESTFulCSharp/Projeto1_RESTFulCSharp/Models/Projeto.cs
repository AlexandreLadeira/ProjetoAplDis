using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1_RESTFulCSharp.Models
{
    public class Projeto
    {
        private int codigo;
        private string nome;
        private string descricao;
        private string ano;

        public int Codigo { get => codigo; }

        public string Nome { get => nome;
            set
            {
                if (value.Length > 50)
                    throw new Exception("O nome deve ter no máximo 50 carctetes!");

                    nome = value;
            }
        }

        public string Descricao { get => descricao;
            set
            {
                if (value.Length > 200)
                    throw new Exception("A descrição deve ter no máximo 200 carctetes!");

                descricao = value;
            }
        }
        public string Ano { get => ano;
            set
            {
                if (value.Length != 4)
                    throw new Exception("O ano deve ter 4 caracteres!");

                ano = value;
            }
        }

        public Projeto(int codigo, string nome, string descricao, string ano)
        {
            this.codigo = codigo;
            Nome = nome;
            Descricao = descricao;
            Ano = ano;
        }
    }
}