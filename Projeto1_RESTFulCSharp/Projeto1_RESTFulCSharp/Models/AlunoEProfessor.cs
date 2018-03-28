using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1_RESTFulCSharp.Models
{
    public class AlunoEProfessor
    {
        private Aluno[]     alunos      = new Aluno     [3];
        private Professor[] professores = new Professor [2];
        private int         qtosProfs   = 0;
        private int         qtosAlunos  = 0;

        public Aluno[] Alunos { get => alunos; set => alunos = value; }
        public Professor[] Professores { get => professores; set => professores = value; }
        public int QtosProfs { get => qtosProfs; set => qtosProfs = value; }
        public int QtosAlunos { get => qtosAlunos; set => qtosAlunos = value; }

        public void adicionarAluno(Aluno a)
        {
            if (a == null)
                throw new Exception("O aluno não deve ser nulo!");

            if (QtosAlunos >= 3)
                throw new Exception("O projeto não pode ter mais alunos!");

            Alunos[QtosAlunos] = a;
            qtosAlunos++;
        }

        public void adicionarProfessor(Professor p)
        {
            if (p == null)
                throw new Exception("O professor não deve ser nulo!");

            if (QtosProfs >= 2)
                throw new Exception("O projeto não pode ter mais professores!");

            Professores[QtosProfs] = p;
            qtosProfs++;
        }
    }
}