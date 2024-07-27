using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhandoComListas
{
    public class Atividade
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public override string ToString()
        {
            return $"Id:{this.Id} | Descrição:{this.Descricao} | Data de Criação: {this.DataCriacao.ToString("dd/MM/yy")} ";
        }
    }
}
