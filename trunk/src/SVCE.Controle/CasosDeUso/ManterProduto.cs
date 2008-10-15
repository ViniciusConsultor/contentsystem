using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SVCE.Modelo.Dados;

namespace SVCE.Controle.CasosDeUso
{
    public class ManterProduto
    {
        BancoDeDados b = new BancoDeDados();
        public Produto[] Listar(int? codigoInterno, string codigoExterno, string nome)
        {
            try
            {
                b.Conectar();
                return Produto.Listar(codigoInterno, codigoExterno, nome);
            }
            finally
            {
                b.Desconectar();
            }
        }
        public void Alterar()
        {
            try
            {
                b.Conectar();
               
            }
            finally
            {
                b.Desconectar();
            }
        }
        public void Incluir()
        {
            try
            {
                b.Conectar();
            }
            finally
            {
                b.Desconectar();
            }
        }

        public void Excluir(int codigoExterno)
        {
            try
            {
                b.Conectar();
                Produto.Excluir(codigoExterno);
            }
            finally
            {
                b.Desconectar();
            }
        }
    }
}
