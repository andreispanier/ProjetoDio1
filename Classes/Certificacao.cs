using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIOCertificacoes;

namespace DIOCertificacoes
{
    class Certificacao : EntidadeBase
    {
       
        private AreaTecnologia AreaTecnologia { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int CargaHoraria { get; set; }
        public bool Excluido { get; set; }

       
        public Certificacao(int id, AreaTecnologia areaTecnologia, string titulo, string descricao, int cargaHoraria)
        {
            this.Id = id;
            this.AreaTecnologia = areaTecnologia;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.CargaHoraria = cargaHoraria;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Área da Técnologia: " + this.AreaTecnologia + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Carga Horária: " + this.CargaHoraria + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;

            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}
