using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIOCertificacoes
{
    class CertificacaoRepositorio : IRepositorio<Certificacao>

    {
        private List<Certificacao> listaCertificacao = new List<Certificacao>();
        public void Atualiza(int id, Certificacao entidade)
        {
            listaCertificacao[id] = entidade;

        }
        public void Exclui(int id)
        {
            listaCertificacao[id].Excluir();
        }

        public void Insere(Certificacao entidade)
        {
            listaCertificacao.Add(entidade);
        }

        public List<Certificacao> Lista()
        {
            return listaCertificacao;
        }

        public int ProximoID()
        {
            return listaCertificacao.Count;
        }

        public Certificacao RetornaPorId(int id)
        {
            return listaCertificacao[id];
        }
    }
}
