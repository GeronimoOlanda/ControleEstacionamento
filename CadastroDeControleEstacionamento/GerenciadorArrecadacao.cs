using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeControleEstacionamento
{

    class GerenciadorArrecadacao
    {
        public float ValorHora { get; set; }
        private float _arrecadado;

        public float Arrecadado
        {
            get => _arrecadado;
            set => _arrecadado += value;
        }
        public float CalcularEstadiaCliente(DateTime entrada)
        {
            var permanencia = DateTime.Now - entrada;

            if(permanencia.Hours <= 0)
            {
                return ValorHora;
            }
            else{
                return ValorHora * permanencia.Hours;
            }
        }

    }
}
