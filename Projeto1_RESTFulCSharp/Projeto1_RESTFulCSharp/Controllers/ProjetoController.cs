using Projeto1_RESTFulCSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Projeto1_RESTFulCSharp.Controllers
{
    [RoutePrefix("api/projetos")]
    public class ProjetoController : ApiController
    {
        ProjetoRepositorio projetos = new ProjetoRepositorio();

        public IEnumerable<Projeto> GetAllProjetos()
        {
            return projetos.GetAll();
        }

        public AlunoEProfessor GetAlunosEProfessoresPorCodigo(int codigo)
        {
            try
            {
                return projetos.GetAlunosEProfessoresDoProjetoPorCodigo(codigo);
            }
            catch (Exception e)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotAcceptable)
                {
                    ReasonPhrase = e.Message
                };
                throw new HttpResponseException(msg);
            }
        }

        public Projeto GetDadosProjeto(int codigoProjetoParaSelecionarDados)
        {
            try
            {
                return projetos.SelecionaDadosProjeto(codigoProjetoParaSelecionarDados);
            }
            catch (Exception e)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotAcceptable)
                {
                    ReasonPhrase = e.Message
                };
                throw new HttpResponseException(msg);
            }
        }

        public AlunoEProfessor GetAlunosEProfessorPorNome(string nome)
        {
            try
            {
                return projetos.GetAlunosEProfessoresDoProjetoPorNome(nome);
            }
            catch (Exception e)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotAcceptable)
                {
                    ReasonPhrase = e.Message
                };
                throw new HttpResponseException(msg);
            }
        }

        public void PutUmProfessorNoProjeto(int codigo, int codigoProjeto)
        {
            try
            {
                projetos.conectaProfessorAoProjeto(codigo, codigoProjeto);
            }
            catch (Exception e)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotAcceptable)
                {
                    ReasonPhrase = e.Message
                };
                throw new HttpResponseException(msg);
            }
        }

        public void PutUmAlunoNoProjeto(string ra, int codigoProjeto)
        {
            try
            {
                projetos.conectaAlunoAoProjeto(ra, codigoProjeto);
            }
            catch (Exception e)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotAcceptable)
                {
                    ReasonPhrase = e.Message
                };
                throw new HttpResponseException(msg);
            }
        }
        

        public void PutProjetoAluno(string[] ras, int codigoProjetoAluno)
        {
            try
            {
                this.projetos.conectaAlunosAoProjeto(ras, codigoProjetoAluno);
            }
            catch (Exception e)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotAcceptable)
                {
                    ReasonPhrase = e.Message
                };
                throw new HttpResponseException(msg);
            }
        }

        public void PutProjetoProfessor(int[] codigos, int codigoProjetoProfessor)
        {
            try
            {
                this.projetos.conectaProfessoresAoProjeto(codigos, codigoProjetoProfessor);
            }
            catch (Exception e)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotAcceptable)
                {
                    ReasonPhrase = e.Message
                };
                throw new HttpResponseException(msg);
            }
        } 

        public int PostProjeto(Projeto p)
        {
            try
            {
                int codigo = projetos.AdicionarProjeto(p);
                return codigo;
            }
            catch (Exception e)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotAcceptable)
                {
                    ReasonPhrase = e.Message
                };
                throw new HttpResponseException(msg);
            }
        }

        public void DeleteAlunoDoProjeto(string ra, int codigoProjetoADeletar)
        {
            try
            {
                projetos.deletaAlunoDoProjeto(ra, codigoProjetoADeletar);
            }
            catch(Exception e)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotAcceptable)
                {
                    ReasonPhrase = e.Message
                };
                throw new HttpResponseException(msg);
            }
        }

        public void DeleteProfessorDoProjeto(int codigoProfessor, int codigoProjetoADeletar)
        {
            try
            {
                projetos.deletaProfessorDoProjeto(codigoProfessor, codigoProjetoADeletar);
            }
            catch (Exception e)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotAcceptable)
                {
                    ReasonPhrase = e.Message
                };
                throw new HttpResponseException(msg);
            }
        }
        
        public void PutProjeto(int codigo, string nome, string descricao, string ano)
        {
            try
            {
                projetos.AlterarDadosProjeto(codigo, nome, ano, descricao);
            }
            catch (Exception e)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotAcceptable)
                {
                    ReasonPhrase = e.Message
                };
                throw new HttpResponseException(msg);
            }
        }

        public void DeleteProjeto(int codProjeto)
        {
            try
            {
                projetos.ExcluirProjeto(codProjeto);
            }
            catch (Exception e)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotAcceptable)
                {
                    ReasonPhrase = e.Message
                };
                throw new HttpResponseException(msg);
            }
        }
    }
}