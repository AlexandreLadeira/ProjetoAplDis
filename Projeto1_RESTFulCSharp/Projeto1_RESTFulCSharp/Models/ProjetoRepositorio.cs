using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Projeto1_RESTFulCSharp.Models
{
    public class ProjetoRepositorio
    {
        SqlConnection conexao;

        public ProjetoRepositorio()
        {
            try
            {
                conexao = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conexao.Open();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Projeto> GetAll()
        {
            try
            {
                List<Projeto> projetos = new List<Projeto>();

                SqlCommand comando = new SqlCommand("Select * from ConsultaTodosOsProjetos_view");
                comando.Connection = conexao;

                SqlDataReader leitor = comando.ExecuteReader();

                if (leitor.Read())
                {
                    do
                    {
                        Projeto proj = new Projeto((int)leitor[0], (string)leitor[1], (string)leitor[2], (string)leitor[3]);
                        projetos.Add(proj);
                    }
                    while (leitor.Read());
                }

                return projetos;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public AlunoEProfessor GetAlunosEProfessoresDoProjetoPorCodigo(int codigo)
        {
            try
            {
                AlunoEProfessor alunosEProfessores = new AlunoEProfessor(); //Uma classe que armazena alunos e professores em um mesmo objeto

                SqlCommand comando = new SqlCommand("ConsultaAlunosDoProjeto_sp"); //Devolve todos os alunos relacionados ao projeto
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Connection = conexao;

                SqlParameter prmCodigo = new SqlParameter("@CodProjeto", codigo);
                prmCodigo.Direction = System.Data.ParameterDirection.Input;
                comando.Parameters.Add(prmCodigo);


                SqlDataReader leitor = comando.ExecuteReader();

                if (leitor.Read())
                {
                    do
                    {
                        Aluno a = new Aluno((string)leitor[0], (string)leitor[1], (string)leitor[2]);
                        alunosEProfessores.adicionarAluno(a);
                    }
                    while (leitor.Read());
                }

                leitor.Close();

                SqlCommand comando2 = new SqlCommand("ConsultaProfessoresDoProjeto_sp"); //Devolve todos os professores relacionados ao projeto
                comando2.CommandType = System.Data.CommandType.StoredProcedure;
                comando2.Connection = conexao;

                SqlParameter prmCodigo2 = new SqlParameter("@CodProjeto", codigo);
                prmCodigo2.Direction = System.Data.ParameterDirection.Input;
                comando2.Parameters.Add(prmCodigo2);

                SqlDataReader leitor2 = comando2.ExecuteReader();

                if (leitor2.Read())
                {
                    do
                    {
                        Professor p = new Professor((int)leitor2[0], (string)leitor2[1], (string)leitor2[2]);
                        alunosEProfessores.adicionarProfessor(p);
                    }
                    while (leitor2.Read());
                }

                return alunosEProfessores;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Projeto SelecionaDadosProjeto(int codigoParaSelecionarDados)
        {
            try
            {
                SqlCommand comando = new SqlCommand("SelecionaProjeto_sp");
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Connection = conexao;

                SqlParameter prmCodigo = new SqlParameter("@codigo", codigoParaSelecionarDados);
                prmCodigo.Direction = System.Data.ParameterDirection.Input;
                comando.Parameters.Add(prmCodigo);
                
                SqlDataReader leitor = comando.ExecuteReader();

                Projeto projeto;

                leitor.Read();
                projeto = new Projeto((int)leitor[0], (string)leitor[1], (string)leitor[2], (string)leitor[3]);
                
                leitor.Close();
                
                return projeto;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public AlunoEProfessor GetAlunosEProfessoresDoProjetoPorNome(string nome)
        {
            try
            {
                AlunoEProfessor alunosEProfessores = new AlunoEProfessor();

                SqlCommand comando = new SqlCommand("ConsultaAlunosDoProjetoPorNome_sp");
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Connection = conexao;

                SqlParameter prmNome = new SqlParameter("@nome", nome);
                prmNome.Direction = System.Data.ParameterDirection.Input;
                comando.Parameters.Add(prmNome);


                SqlDataReader leitor = comando.ExecuteReader();

                if (leitor.Read())
                {
                    do
                    {
                        Aluno a = new Aluno((string)leitor[0], (string)leitor[1], (string)leitor[2]);
                        alunosEProfessores.adicionarAluno(a);
                    }
                    while (leitor.Read());
                }

                leitor.Close();

                SqlCommand comando2 = new SqlCommand("ConsultaProfessoresDoProjetoPorNome_sp");
                comando2.CommandType = System.Data.CommandType.StoredProcedure;
                comando2.Connection = conexao;

                SqlParameter prmNome2 = new SqlParameter("@nome", nome);
                prmNome2.Direction = System.Data.ParameterDirection.Input;
                comando2.Parameters.Add(prmNome2);

                SqlDataReader leitor2 = comando2.ExecuteReader();

                if (leitor2.Read())
                {
                    do
                    {
                        Professor p = new Professor((int)leitor2[0], (string)leitor2[1], (string)leitor2[2]);
                        alunosEProfessores.adicionarProfessor(p);
                    }
                    while (leitor2.Read());
                }

                return alunosEProfessores;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    
        public void conectaAlunosAoProjeto(string[] ras, int codigoProjeto)
        {
            if (ras.Length == 0 || ras.Length > 3)
                throw new Exception("O projeto deve possuir de 1 a 3 alunos!");

            // Verifica se algum dos alunos já está em um projeto
            SqlCommand comandoVerificacao = new SqlCommand("ChecaSeJaEstaEmProjeto_sp");
            comandoVerificacao.CommandType = System.Data.CommandType.StoredProcedure;
            comandoVerificacao.Connection = conexao;

            for (int i = 0; i < ras.Length; i++)
            {
                if (!String.IsNullOrEmpty(ras[i]))
                {
                    SqlParameter prmCodigoVerificacao = new SqlParameter("@raAluno", ras[i]);
                    comandoVerificacao.Parameters.Add(prmCodigoVerificacao);

                    SqlDataReader leitorVerificacao = comandoVerificacao.ExecuteReader();
                    leitorVerificacao.Read();
                    int qtosProjetos = (int)leitorVerificacao[0];

                    if (qtosProjetos > 0)
                        throw new Exception("O aluno " + ras[i] + " já está em um projeto!");

                    comandoVerificacao.Parameters.Clear();
                    leitorVerificacao.Close();
                }
            }

            // FIM DA VERIFICACAO ------------------------------------------------------

            // Conecta alunos do vetor ao projeto
            int alunoAtual = 0;

            SqlCommand comandoRelacionarAluno = new SqlCommand("ConectaProjetoAluno_sp");
            comandoRelacionarAluno.CommandType = System.Data.CommandType.StoredProcedure;
            comandoRelacionarAluno.Connection = conexao;

            while ((alunoAtual < ras.Length) && (!String.IsNullOrEmpty(ras[alunoAtual])))
            {
                SqlParameter prmCodAluno = new SqlParameter("@raAluno", ras[alunoAtual]);
                SqlParameter prmCodProjAluno = new SqlParameter("@codProjeto", codigoProjeto);

                comandoRelacionarAluno.Parameters.Add(prmCodAluno);
                comandoRelacionarAluno.Parameters.Add(prmCodProjAluno);

                comandoRelacionarAluno.ExecuteNonQuery();
                comandoRelacionarAluno.Parameters.Clear();

                alunoAtual++;
            }
        }

        public void deletaProfessorDoProjeto(int codigoProfessor, int codigoProjeto)
        {
            try
            {
                //Verifica quantos alunos já estão conectados ao projeto
                SqlCommand comandoQuantosProfessores = new SqlCommand("checaQuantosProfessoresTem_sp");
                comandoQuantosProfessores.CommandType = System.Data.CommandType.StoredProcedure;
                comandoQuantosProfessores.Connection = conexao;

                SqlParameter prmCodProjetoQtosProfessores = new SqlParameter("@codProjeto", codigoProjeto);
                comandoQuantosProfessores.Parameters.Add(prmCodProjetoQtosProfessores);

                SqlDataReader leitorQtosAlunos = comandoQuantosProfessores.ExecuteReader();
                leitorQtosAlunos.Read();
                int qtosProfessoresNoProjeto = (int)leitorQtosAlunos[0];

                if (qtosProfessoresNoProjeto <= 0)
                    throw new Exception("O projeto não possui nenhum professor!");

                leitorQtosAlunos.Close();

                // FIM DA VERIFICACAO ------------------------------------------------------

                //Exclui o professor
                SqlCommand comandoRelacionarProfessor = new SqlCommand("excluiProfessor_sp");
                comandoRelacionarProfessor.CommandType = System.Data.CommandType.StoredProcedure;
                comandoRelacionarProfessor.Connection = conexao;

                SqlParameter prmCodProfessor = new SqlParameter("@codProfessor", codigoProfessor);
                SqlParameter prmCodProjProf = new SqlParameter("@codProjeto", codigoProjeto);

                comandoRelacionarProfessor.Parameters.Add(prmCodProfessor);
                comandoRelacionarProfessor.Parameters.Add(prmCodProjProf);

                comandoRelacionarProfessor.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        // Conectar um único professor
        public void conectaProfessorAoProjeto(int codigoProfessor, int codigoProjeto)
        {
            try
            {
                //Verifica quantos alunos já estão conectados ao projeto
                SqlCommand comandoQuantosProfessores = new SqlCommand("checaQuantosProfessoresTem_sp");
                comandoQuantosProfessores.CommandType = System.Data.CommandType.StoredProcedure;
                comandoQuantosProfessores.Connection = conexao;

                SqlParameter prmCodProjetoQtosProfessores = new SqlParameter("@codProjeto", codigoProjeto);
                comandoQuantosProfessores.Parameters.Add(prmCodProjetoQtosProfessores);


                SqlDataReader leitorQtosProfessores = comandoQuantosProfessores.ExecuteReader();
                leitorQtosProfessores.Read();
                int qtosProfessoresNoProjeto = (int)leitorQtosProfessores[0];

                if (qtosProfessoresNoProjeto >= 2)
                    throw new Exception("O projeto já tem a quantidade máxima de professores!");

                leitorQtosProfessores.Close();

                // FIM DA VERIFICACAO ------------------------------------------------------

                // Conecta professor ao projeto
                SqlCommand comandoRelacionarProfessor = new SqlCommand("ConectaProjetoProfessor_sp");
                comandoRelacionarProfessor.CommandType = System.Data.CommandType.StoredProcedure;
                comandoRelacionarProfessor.Connection = conexao;

                SqlParameter prmCodProfessor = new SqlParameter("@codProf", codigoProfessor);
                SqlParameter prmCodProjProf = new SqlParameter("@codProjeto", codigoProjeto);

                comandoRelacionarProfessor.Parameters.Add(prmCodProfessor);
                comandoRelacionarProfessor.Parameters.Add(prmCodProjProf);

                comandoRelacionarProfessor.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        // Deletar um único aluno
        public void deletaAlunoDoProjeto(string raAluno, int codigoProjeto)
        {
            try
            {
                if (String.IsNullOrEmpty(raAluno) || raAluno.Length != 5)
                    throw new Exception("O RA do aluno deve ter 5 caracteres!");

                //Verifica quantos alunos já estão conectados ao projeto
                SqlCommand comandoQuantosAlunos = new SqlCommand("checaQuantosAlunosTem_sp");
                comandoQuantosAlunos.CommandType = System.Data.CommandType.StoredProcedure;
                comandoQuantosAlunos.Connection = conexao;

                SqlParameter prmCodProjetoQtosAlunos = new SqlParameter("@codProjeto", codigoProjeto);
                comandoQuantosAlunos.Parameters.Add(prmCodProjetoQtosAlunos);

                SqlDataReader leitorQtosAlunos = comandoQuantosAlunos.ExecuteReader();
                leitorQtosAlunos.Read();
                int qtosAlunosNoProjeto = (int)leitorQtosAlunos[0];

                if (qtosAlunosNoProjeto <= 0)
                    throw new Exception("O projeto não possui nenhum aluno relacionado a ele!");

                leitorQtosAlunos.Close();

                // FIM DA VERIFICACAO ------------------------------------------------------
                 
                // Deleta o aluno do projeto
                SqlCommand comandoRelacionarAluno = new SqlCommand("excluiAluno_sp");
                comandoRelacionarAluno.CommandType = System.Data.CommandType.StoredProcedure;
                comandoRelacionarAluno.Connection = conexao;

                SqlParameter prmCodAluno = new SqlParameter("@raAluno", raAluno);
                SqlParameter prmCodProjAluno = new SqlParameter("@codProjeto", codigoProjeto);

                comandoRelacionarAluno.Parameters.Add(prmCodAluno);
                comandoRelacionarAluno.Parameters.Add(prmCodProjAluno);

                comandoRelacionarAluno.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Conecta um único aluno ao projeto
        public void conectaAlunoAoProjeto(string raAluno, int codigoProjeto)
        {
            try
            {
                if (String.IsNullOrEmpty(raAluno) || raAluno.Length != 5)
                    throw new Exception("O RA do aluno deve ter 5 caracteres!");

                //Verifica quantos alunos já estão conectados ao projeto
                SqlCommand comandoQuantosAlunos = new SqlCommand("checaQuantosAlunosTem_sp");
                comandoQuantosAlunos.CommandType = System.Data.CommandType.StoredProcedure;
                comandoQuantosAlunos.Connection = conexao;

                SqlParameter prmCodProjetoQtosAlunos = new SqlParameter("@codProjeto", codigoProjeto);
                comandoQuantosAlunos.Parameters.Add(prmCodProjetoQtosAlunos);

                SqlDataReader leitorQtosAlunos = comandoQuantosAlunos.ExecuteReader();
                leitorQtosAlunos.Read();
                int qtosAlunosNoProjeto = (int)leitorQtosAlunos[0];

                if (qtosAlunosNoProjeto >= 3)
                    throw new Exception("O projeto já tem a quantidade máxima de alunos!");

                leitorQtosAlunos.Close();
                // FIM DA VERIFICACAO ------------------------------------------------------

                // Verifica se algum dos alunos já está em um projeto
                SqlCommand comandoVerificacao = new SqlCommand("ChecaSeJaEstaEmProjeto_sp");
                comandoVerificacao.CommandType = System.Data.CommandType.StoredProcedure;
                comandoVerificacao.Connection = conexao;

                SqlParameter prmCodigoVerificacao = new SqlParameter("@raAluno", raAluno);
                comandoVerificacao.Parameters.Add(prmCodigoVerificacao);

                SqlDataReader leitorVerificacao = comandoVerificacao.ExecuteReader();
                leitorVerificacao.Read();
                int qtosProjetos = (int)leitorVerificacao[0];

                if (qtosProjetos > 0)
                    throw new Exception("O aluno " + raAluno + " já está em um projeto!");

                comandoVerificacao.Parameters.Clear();
                leitorVerificacao.Close();

                // FIM DA VERIFICACAO ------------------------------------------------------


                // Conectar aluno ao projeto
                SqlCommand comandoRelacionarAluno = new SqlCommand("ConectaProjetoAluno_sp");
                comandoRelacionarAluno.CommandType = System.Data.CommandType.StoredProcedure;
                comandoRelacionarAluno.Connection = conexao;

                SqlParameter prmCodAluno = new SqlParameter("@raAluno", raAluno);
                SqlParameter prmCodProjAluno = new SqlParameter("@codProjeto", codigoProjeto);

                comandoRelacionarAluno.Parameters.Add(prmCodAluno);
                comandoRelacionarAluno.Parameters.Add(prmCodProjAluno);

                comandoRelacionarAluno.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // Conecta professores ao projeto
        public void conectaProfessoresAoProjeto(int[] codigos, int codigoProjeto)
        {
            if (codigos.Length == 0 || codigos.Length > 2)
                throw new Exception("O projeto deve possuir de 1 a 2 professores");
            
            //Conecta o professor
            SqlCommand comandoRelacionarProfessor = new SqlCommand("ConectaProjetoProfessor_sp");
            comandoRelacionarProfessor.CommandType = System.Data.CommandType.StoredProcedure;
            comandoRelacionarProfessor.Connection = conexao;

            int professorAtual = 0;
            while ((professorAtual < codigos.Length) && (codigos[professorAtual] != 0))
            {

                SqlParameter prmCodProfessor = new SqlParameter("@codProf", codigos[professorAtual]);
                SqlParameter prmCodProjProf = new SqlParameter("@codProjeto", codigoProjeto);

                comandoRelacionarProfessor.Parameters.Add(prmCodProfessor);
                comandoRelacionarProfessor.Parameters.Add(prmCodProjProf);

                comandoRelacionarProfessor.ExecuteNonQuery();

                comandoRelacionarProfessor.Parameters.Clear();

                professorAtual++;
            }
        }

        public int AdicionarProjeto(Projeto p)
        {
            try
            {
                if (p == null)
                    throw new Exception("O projeto não deve ser nulo!");
                
                //Inserir um novo projeto
                SqlCommand comando = new SqlCommand("InsereProjeto_sp");
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Connection = conexao;


                SqlParameter prmNome = new SqlParameter("@nome", p.Nome);
                prmNome.Direction = System.Data.ParameterDirection.Input;
                comando.Parameters.Add(prmNome);

                SqlParameter prmDescricao = new SqlParameter("@descricao", p.Descricao);
                prmDescricao.Direction = System.Data.ParameterDirection.Input;
                comando.Parameters.Add(prmDescricao);

                SqlParameter prmAno = new SqlParameter("@ano", p.Ano);
                prmAno.Direction = System.Data.ParameterDirection.Input;
                comando.Parameters.Add(prmAno);

                SqlDataReader leitor = comando.ExecuteReader();

                leitor.Read();
                int codigoProjeto = (int)leitor[0];
                leitor.Close();
                
                return codigoProjeto;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void AlterarDadosProjeto(int codigo, string nome, string ano, string descricao)
        {
            try
            {
                //Alterar os dados do projeto passado por parâmetro
                SqlCommand comando = new SqlCommand("alteraProjeto_sp");
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Connection = conexao;

                SqlParameter prmCodigo = new SqlParameter("@codProjeto", codigo);
                prmCodigo.Direction = System.Data.ParameterDirection.Input;
                comando.Parameters.Add(prmCodigo);

                SqlParameter prmNome = new SqlParameter("@nome", nome);
                prmNome.Direction = System.Data.ParameterDirection.Input;
                comando.Parameters.Add(prmNome);

                SqlParameter prmDescricao = new SqlParameter("@descricao", descricao);
                prmDescricao.Direction = System.Data.ParameterDirection.Input;
                comando.Parameters.Add(prmDescricao);

                SqlParameter prmAno = new SqlParameter("@ano", ano);
                prmAno.Direction = System.Data.ParameterDirection.Input;
                comando.Parameters.Add(prmAno);

                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void ExcluirProjeto(int codProj)
        {
            try
            {
                if (codProj <= 0)
                    throw new Exception("Código não está no formato correto.");

                // Verificar se o projeto existe
                SqlCommand comandoVerificacao = new SqlCommand("ExisteProjeto_sp");
                comandoVerificacao.CommandType = System.Data.CommandType.StoredProcedure;
                comandoVerificacao.Connection = conexao;
                
                SqlParameter prmCodigoVerificacao = new SqlParameter("@codProjeto", codProj);
                comandoVerificacao.Parameters.Add(prmCodigoVerificacao);

                SqlDataReader leitorVerificacao = comandoVerificacao.ExecuteReader();
                leitorVerificacao.Read();
                int qtosProjetos = (int)leitorVerificacao[0];

                if (qtosProjetos == 0)
                    throw new Exception("O projeto não existe!");

                comandoVerificacao.Parameters.Clear();
                leitorVerificacao.Close();

                SqlCommand comando = new SqlCommand("DeletaProjeto_sp");
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Connection = conexao;

                SqlParameter prmCodProjeto = new SqlParameter("@codProjeto", codProj);

                comando.Parameters.Add(prmCodProjeto);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}