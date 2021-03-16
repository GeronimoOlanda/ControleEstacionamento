using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic; //importando componentes do visual basic
namespace CadastroDeControleEstacionamento
{
    public partial class Form1 : Form
    {
        private DataTable bancoDeDados;
        private GerenciadorArrecadacao gerenciador;

        public Form1()
        {
            InitializeComponent();

            bancoDeDados = new DataTable("Estacionamento"); //criando tabela estacionamento
            bancoDeDados.Columns.Add("Placa", typeof(string));//adicionamos uma coluna chamada placa e a convertemos para o tipo string(texto)
            bancoDeDados.Columns.Add("Entrada", typeof(string));//adicionamos uma coluna chamada entrada e a convertemos para o tipo string(texto)

            dataGridViewCarrosEstacionados.DataSource = bancoDeDados; //atrelamos o dataGridView ao DataTable
            //unicializamos o gerenciador
            gerenciador = new GerenciadorArrecadacao
            {
                ValorHora = 10,
                Arrecadado = 0
            };
            labelValorHora.Text = $"Valor da  hora: R$ {gerenciador.ValorHora.ToString("0.00")}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
           var placa = Interaction.InputBox("DIgite a placa do veiculo:", "Entrada de veiculo");
            if (!string.IsNullOrEmpty(placa))//verifica se a placa é vazia ou nao, para saber se o usuario clicou em OK ou não
            {
                bancoDeDados.Rows.Add(new string[] { placa, DateTime.Now.ToString()});
                dataGridViewCarrosEstacionados.Rows[dataGridViewCarrosEstacionados.Rows.Count - 1].MinimumHeight = 30;
            }
        }

        private void buttonConfigurar_Click(object sender, EventArgs e)
        {
            var valorDaHora = Interaction.InputBox("Digite o valor da hora:", "Valor da hora");
            if (!string.IsNullOrEmpty(valorDaHora))
            {
                gerenciador.ValorHora = float.Parse(valorDaHora);
                labelValorHora.Text = $"Valor da  hora: R$ {gerenciador.ValorHora.ToString("0.00")}";
            }
        }

        private void dataGridViewCarrosEstacionados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                var entrada = DateTime.Parse(bancoDeDados.Rows[e.RowIndex].ItemArray[1].ToString());
                var placa = bancoDeDados.Rows[e.RowIndex].ItemArray[0].ToString();

                var arrecadado = gerenciador.CalcularEstadiaCliente(entrada);

                //exibe mensagem
                if (MessageBox.Show(this, $"Deseja encerrar o ticket de {placa}? Valor: R$ {arrecadado.ToString("0.00")}", "Encerrar Ticket", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    // Remove do banco de dados
                    bancoDeDados.Rows.RemoveAt(e.RowIndex);
                    // Arrecada o valor
                    gerenciador.Arrecadado = arrecadado;
                    // Atualiza o valor na tela
                    labelValorArrecadado.Text = $"Total Arrecadado: R$ {gerenciador.Arrecadado.ToString("0.00")}";
                }
            }
        }
    }
}
