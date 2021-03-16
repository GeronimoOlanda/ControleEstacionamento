using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroDeControleEstacionamento
{
    public partial class Form1 : Form
    {
        private DataTable bancoDeDados;

        public Form1()
        {
            InitializeComponent();

            bancoDeDados = new DataTable("Estacionamento"); //criando tabela estacionamento
        
            bancoDeDados.Columns.Add("Placa", typeof(string));//adicionamos uma coluna chamada placa e a convertemos para o tipo string(texto)
            bancoDeDados.Columns.Add("Entrada", typeof(string));//adicionamos uma coluna chamada entrada e a convertemos para o tipo string(texto)

            dataGridViewCarrosEstacionados.DataSource = bancoDeDados; //atrelamos o dataGridView ao DataTable
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {

        }
    }
}
