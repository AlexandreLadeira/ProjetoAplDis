using Projeto1_RESTFulCSharp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ProjetoCliente
{
    public partial class Form1 : Form
    {
        private string URI = "http://localhost:porta/api/Projeto";
        HttpResponseMessage response = new HttpResponseMessage();
        HttpClient cliente = new HttpClient();

        public Form1()
        {
            InitializeComponent();
            txtURI.Text = this.URI;
        }

        private async void GetAll()
        {
            try
            {
                URI = txtURI.Text;

                if (String.IsNullOrEmpty(URI))
                    MessageBox.Show("Preencha o campo URI!");
                else
                {
                    response = await cliente.GetAsync(URI);
                    if (response.IsSuccessStatusCode)
                    {
                        var projetoJSONString = await response.Content.ReadAsStringAsync();
                        gvConsultaProjetos.Columns.Clear();
                        gvConsultaProjetos.DataSource = null;

                        gvConsultaProjetos.DataSource = JsonConvert.DeserializeObject<Projeto[]>(projetoJSONString).ToList();
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private async void GetPorCodigo()
        {
            try
            {
                URI = txtURI.Text;
            
               
                if (String.IsNullOrEmpty(URI))
                    MessageBox.Show("Preencha o campo URI!");
                else
                {
                    BindingSource bsDados = new BindingSource();
                    URI = txtURI.Text + "?codigo=" + txtConsultarPorCodigo.Text;
                    response = await cliente.GetAsync(URI);
                    if (response.IsSuccessStatusCode)
                    {
                        var projetoJSONString = await response.Content.ReadAsStringAsync();
                        AlunoEProfessor alEProf = JsonConvert.DeserializeObject<AlunoEProfessor>(projetoJSONString);
                        gvConsultaProjetos.Columns.Clear();
                        gvConsultaProjetos.DataSource = null;

                        gvConsultaProjetos.RowCount = 1;
                        gvConsultaProjetos.ColumnCount = 0;

                        int i;

                        for (i = 0; i < alEProf.QtosAlunos; i++)
                        {
                            gvConsultaProjetos.ColumnCount++;
                            gvConsultaProjetos.Columns[i].HeaderText = "Aluno " + (i + 1);
                            gvConsultaProjetos.Rows[0].Cells[i].Value = "RA: " + alEProf.Alunos[i].Ra;

                        }

                        for (int j = 0; j < alEProf.QtosProfs; j++, i++)
                        {
                            gvConsultaProjetos.ColumnCount++;
                            gvConsultaProjetos.Columns[i].HeaderText = "Prof. " + (j + 1);
                            gvConsultaProjetos.Rows[0].Cells[i].Value = "Código: " + alEProf.Professores[j].Codigo.ToString();
                        }
                            
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private async void GetPorNome()
        {
            try
            {
                URI = txtURI.Text;


                if (String.IsNullOrEmpty(URI))
                    MessageBox.Show("Preencha o campo URI!");
                else
                {
                    if (String.IsNullOrEmpty(txtConsultarPorNome.Text))
                        throw new Exception("O nome não deve ser nulo!");

                    BindingSource bsDados = new BindingSource();
                    URI = txtURI.Text + "?nome=" + txtConsultarPorNome.Text;
                    response = await cliente.GetAsync(URI);

                    if (response.IsSuccessStatusCode)
                    {
                        string projetoJSONString = null;

                        try
                        {
                            projetoJSONString = await response.Content.ReadAsStringAsync();
                        }
                        catch (Exception)
                        {
                            throw new Exception("Ocorreu um erro! Verifique se um projeto com esse nome existe!");
                        }
                        AlunoEProfessor alEProf = JsonConvert.DeserializeObject<AlunoEProfessor>(projetoJSONString);
                        gvConsultaProjetos.Columns.Clear();
                        gvConsultaProjetos.DataSource = null;

                        gvConsultaProjetos.RowCount = 1;
                        gvConsultaProjetos.ColumnCount = 0;

                        int i;

                        for (i = 0; i < alEProf.QtosAlunos; i++)
                        {
                            gvConsultaProjetos.ColumnCount++;
                            gvConsultaProjetos.Columns[i].HeaderText = "Aluno " + (i + 1);
                            gvConsultaProjetos.Rows[0].Cells[i].Value = "RA: " + alEProf.Alunos[i].Ra;

                        }

                        for (int j = 0; j < alEProf.QtosProfs; j++, i++)
                        {
                            gvConsultaProjetos.ColumnCount++;
                            gvConsultaProjetos.Columns[i].HeaderText = "Prof. " + (j + 1);
                            gvConsultaProjetos.Rows[0].Cells[i].Value = "Código: " + alEProf.Professores[j].Codigo.ToString();
                        }

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
          

        private async void InserirProjeto()
        {
            try
            {
                URI = txtURI.Text;
                if (String.IsNullOrEmpty(URI))
                    MessageBox.Show("Digite uma URI válida!");
                else
                {
                    if (String.IsNullOrEmpty(txtInserirNome.Text) || String.IsNullOrEmpty(txtInserirDescricao.Text) || String.IsNullOrEmpty(txtInserirAno.Text))
                        throw new Exception("Preencha os campos corretamente!");

                    Projeto p = new Projeto(0, txtInserirNome.Text, txtInserirDescricao.Text, txtInserirAno.Text);

                    var serializedProjeto = JsonConvert.SerializeObject(p);
                    var content = new StringContent(serializedProjeto, Encoding.UTF8, "application/json");
                    var response = await cliente.PostAsync(URI, content);

                    var resultString = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<int>(resultString);
                    txtCodigoProjetoInserido.Text = result.ToString();

                    MessageBox.Show("Dados do projeto inseridos com sucesso! Agora, inclua os alunos e professores abaixo.");

                    txtInserirAluno1.ReadOnly     = false;
                    txtInserirAluno2.ReadOnly     = false;
                    txtInserirAluno3.ReadOnly     = false;
                    txtInserirProfessor1.ReadOnly = false;
                    txtInserirProfessor2.ReadOnly = false;
                    btnInserirProfessores.Enabled = true;
                    btnInserirAlunos.Enabled      = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private async void DeletarProjeto()
        {
            try
            {
                URI = txtURI.Text;
                if (String.IsNullOrEmpty(txtCodigoExcluir.Text))
                {
                    MessageBox.Show("Digite um código de projeto válido!");
                    return;
                }

                int codProjeto = Convert.ToInt32(txtCodigoExcluir.Text);

                if (String.IsNullOrEmpty(txtURI.Text))
                {
                    MessageBox.Show("Digite um URI válida!");
                    return;
                }

                try
                {
                    URI += "?codProjeto=" + txtCodigoExcluir.Text;
                    response = await cliente.DeleteAsync(URI);
                    if (response.IsSuccessStatusCode)
                        MessageBox.Show("Projeto excluído com sucesso!");
                    else
                        MessageBox.Show("Falha ao excluir o projeto!");
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private async void SelecionarProjetoParaAlterar()
        {
            try
            {
                URI = txtURI.Text;


                if (String.IsNullOrEmpty(URI))
                    MessageBox.Show("Preencha o campo URI!");
                else
                {
                    BindingSource bsDados = new BindingSource();
                    URI = txtURI.Text + "?codigo=" + txtAlterarCodigoProjeto.Text;
                    response = await cliente.GetAsync(URI);
                    if (response.IsSuccessStatusCode)
                    {
                        var projetoJSONString = await response.Content.ReadAsStringAsync();
                        AlunoEProfessor alEProf = JsonConvert.DeserializeObject<AlunoEProfessor>(projetoJSONString);

                        gvAlterarAlunosEProfessores.Columns.Clear();
                        gvAlterarAlunosEProfessores.DataSource = null;

                        gvAlterarAlunosEProfessores.RowCount = 1;
                        gvAlterarAlunosEProfessores.ColumnCount = 0;

                        int i;

                        for (i = 0; i < alEProf.QtosAlunos; i++)
                        {
                            gvAlterarAlunosEProfessores.ColumnCount++;
                            gvAlterarAlunosEProfessores.Columns[i].HeaderText = "Aluno " + (i + 1);
                            gvAlterarAlunosEProfessores.Rows[0].Cells[i].Value = "RA: " + alEProf.Alunos[i].Ra;

                        }

                        for (int j = 0; j < alEProf.QtosProfs; j++, i++)
                        {
                            gvAlterarAlunosEProfessores.ColumnCount++;
                            gvAlterarAlunosEProfessores.Columns[i].HeaderText = "Prof. " + (j + 1);
                            gvAlterarAlunosEProfessores.Rows[0].Cells[i].Value = "Código: " + alEProf.Professores[j].Codigo.ToString();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private async void InserirProfessoresAoProjeto()
        {
            try
            {
                if (String.IsNullOrEmpty(txtCodigoProjetoInserido.Text))
                    throw new Exception("Por favor, insira um novo projeto antes!");

                int qtosProfessores = 0;
                int[] codigosProfessores = new int[2];

                if (!String.IsNullOrEmpty(txtInserirProfessor1.Text))
                {
                    codigosProfessores[qtosProfessores] = Convert.ToInt32(txtInserirProfessor1.Text);
                    qtosProfessores++;
                }


                if (!String.IsNullOrEmpty(txtInserirProfessor2.Text))
                {
                    codigosProfessores[qtosProfessores] = Convert.ToInt32(txtInserirProfessor2.Text);
                    qtosProfessores++;
                }

                if (qtosProfessores == 0)
                    throw new Exception("Ao menos um aluno deve ser digitado!");

                try
                {
                    string URIProfessores = URI + "?codigoProjetoProfessor=" + txtCodigoProjetoInserido.Text;
                    var serializedCodigos = JsonConvert.SerializeObject(codigosProfessores);
                    var content = new StringContent(serializedCodigos, Encoding.UTF8, "application/json");
                    var result3 = await cliente.PutAsync(URIProfessores, content);
                    MessageBox.Show("Professores foram incluídos com sucesso!");

                    txtInserirProfessor1.ReadOnly = true;
                    txtInserirProfessor2.ReadOnly = true;
                    btnInserirProfessores.Enabled = false;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private async void InserirAlunosAoProjeto()
        {
            try
            {
                if (String.IsNullOrEmpty(txtCodigoProjetoInserido.Text))
                    throw new Exception("Por favor, insira um novo projeto antes!");

                int qtosAlunos = 0;
                string[] ras = new string[3];

                if (!String.IsNullOrEmpty(txtInserirAluno1.Text))
                {
                    ras[qtosAlunos] = txtInserirAluno1.Text;
                    qtosAlunos++;
                }

                if (!String.IsNullOrEmpty(txtInserirAluno2.Text))
                {
                    ras[qtosAlunos] = txtInserirAluno2.Text;
                    qtosAlunos++;
                }

                if (!String.IsNullOrEmpty(txtInserirAluno3.Text))
                {
                    ras[qtosAlunos] = txtInserirAluno3.Text;
                    qtosAlunos++;
                }

                if (qtosAlunos == 0)
                    throw new Exception("Por favor, digite ao menos um aluno!");

                try
                {
                    string URIAlunos = URI + "?codigoProjetoAluno=" + txtCodigoProjetoInserido.Text;
                    var serializedRas = JsonConvert.SerializeObject(ras);
                    var content = new StringContent(serializedRas, Encoding.UTF8, "application/json");
                    var result = await cliente.PutAsync(URIAlunos, content);
                    MessageBox.Show("Aluno(s) inserido(s) ao projeto!");

                    txtInserirAluno1.ReadOnly = true;
                    txtInserirAluno2.ReadOnly = true;
                    txtInserirAluno3.ReadOnly = true;
                    btnInserirAlunos.Enabled = false;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private async void InserirUmAlunoAoProjeto()
        {
            try
            {
                URI = txtURI.Text;


                if (String.IsNullOrEmpty(URI))
                    MessageBox.Show("Preencha o campo URI!");
                else
                {
                    URI = txtURI.Text + "?ra=" + txtAlterarRaAluno.Text + "&codigoProjeto=" + txtAlterarCodigoProjeto.Text;
                    var response = await cliente.PutAsync(URI, null);

                    try
                    {
                        if (response.IsSuccessStatusCode)
                            MessageBox.Show("Aluno adicionado ao projeto!");
                        else
                            throw new Exception("Houve um erro ao realizar a tarefa!");
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private async void InserirUmProfessorAoProjeto()
        {
            try
            {
                URI = txtURI.Text;

                if (String.IsNullOrEmpty(URI))
                    MessageBox.Show("Preencha o campo URI!");
                else
                {
                    URI = txtURI.Text + "?codigo=" + txtAlterarCodigoProfessor.Text + "&codigoProjeto=" + txtAlterarCodigoProjeto.Text;
                    var response = await cliente.PutAsync(URI, null);

                    try
                    {
                        if (response.IsSuccessStatusCode)
                            MessageBox.Show("Professor adicionado ao projeto!");
                        else
                            throw new Exception("Houve um erro ao realizar a tarefa!");
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private async void DeletarProfessorProjeto()
        {
            URI = txtURI.Text;
            if (String.IsNullOrEmpty(txtAlterarCodigoProfessor.Text))
            {
                MessageBox.Show("Digite um código de professor válido!");
                return;
            }

            if (String.IsNullOrEmpty(txtURI.Text))
            {
                MessageBox.Show("Digite um URI válida!");
                return;
            }

            try
            {
                URI += "?codigoProfessor=" + txtAlterarCodigoProfessor.Text + "&codigoProjetoADeletar=" + txtAlterarCodigoProjeto.Text;
                response = await cliente.DeleteAsync(URI);
                if (response.IsSuccessStatusCode)
                    MessageBox.Show("Professor excluído do projeto!");
                else
                    MessageBox.Show("Falha ao excluir o professor!");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private async void DeletarAlunoProjeto()
        {
            URI = txtURI.Text;
            if (String.IsNullOrEmpty(txtAlterarRaAluno.Text))
            {
                MessageBox.Show("Digite um RA de aluno válido!");
                return;
            }

            if (String.IsNullOrEmpty(txtURI.Text))
            {
                MessageBox.Show("Digite um URI válida!");
                return;
            }

            try
            {
                URI += "?ra=" + txtAlterarRaAluno.Text + "&codigoProjetoADeletar=" + txtAlterarCodigoProjeto.Text;
                response = await cliente.DeleteAsync(URI);
                if (response.IsSuccessStatusCode)
                    MessageBox.Show("Aluno excluído do projeto!");
                else
                    MessageBox.Show("Falha ao excluir o aluno!");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void AlterarProjeto()
        {

        }

        private void btnConsultarPorCodigo_Click(object sender, EventArgs e)
        {
            this.GetPorCodigo();
        }

        private void btnConsultarProjetos_Click(object sender, EventArgs e)
        {
            this.GetAll();
        }

        private void btnExcluirProjeto_Click(object sender, EventArgs e)
        {
            this.DeletarProjeto();
        }

        private void btnInserirProjeto_Click(object sender, EventArgs e)
        {
            this.InserirProjeto();
        }

        private void btnConsultarPorNome_Click(object sender, EventArgs e)
        {
            this.GetPorNome();
        }

        private void btnAlterarSelecionarProjeto_Click(object sender, EventArgs e)
        {
            this.SelecionarProjetoParaAlterar();
        }

        private void btnInserirAlunos_Click(object sender, EventArgs e)
        {
            this.InserirAlunosAoProjeto();
        }

        private void btnInserirProfessores_Click(object sender, EventArgs e)
        {
            this.InserirProfessoresAoProjeto();
        }

        private void btnInserirRA_Click(object sender, EventArgs e)
        {
            this.InserirUmAlunoAoProjeto();
        }

        private void btnInserirCodigo_Click(object sender, EventArgs e)
        {
            this.InserirUmProfessorAoProjeto();
        }

        private void btnExcluirRA_Click(object sender, EventArgs e)
        {
            this.DeletarAlunoProjeto();
        }

        private void btnExcluirCodigo_Click(object sender, EventArgs e)
        {
            this.DeletarProfessorProjeto();
        }

        private void btnAlterarDadosProjeto_Click(object sender, EventArgs e)
        {
            this.AlterarProjeto();
        }
    }
}
