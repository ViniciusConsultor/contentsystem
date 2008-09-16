using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SVCE.Modelo.Dados;
using System.Data;

namespace SVCE.Modelo.Persistencia
{
    public class GerentePersistencia
    {
        private SqlConnection conexao;
        private SqlTransaction transacao;

        public void Conectar()
        {

        }
        public void Desconectar()
        {

        }
        public void IniciarTransacao()
        {

        }
        public void ConcluirTransacao()
        {

        }
        public void AbortarTransacao()
        {

        }

        public Funcionario[] ListarFuncionarios()
        {
            return null;
        }
        public void IncluirFuncionario(Funcionario funcionario)
        {

        }
        public void AtualizarFuncionario(Funcionario funcionario)
        {

        }
        public void ExcluirFuncionario(int matricula)
        {

        }

        public Fornecedor[] ListarFornecedores(string nome, string razaoSocial, string cnpj)
        {
            return null;
        }
        public void IncluirFornecedor(Fornecedor fornecedor)
        {

        }
        public void AtualizarFornecedor(Fornecedor fornecedor)
        {

        }
        public void ExclirFornecedor(int id_fornecedor)
        {

        }

        public Produto[] ListarProdutos(int? codigoInterno, string codigoExterno, string nome)
        {
            return null;
        }
        public void IncluirProduto(Produto produto)
        {

        }
        public void AtualizarProduto(Produto produto)
        {

        }
        public void ExcluirProduto(int codigoExterno)
        {

        }
        public Transacao[] ListarPedidosCompra(int? idProduto, StatusTransacao? statusTransacao, DateTime? dataInicial, DateTime? DataFinal)
        {
            return null;
        }
        public void IncluirTransacao(Transacao transacao)
        {

        }
        public void AlterarStatusTransacao(int id_transacao, StatusTransacao novoStatusTransacao)
        {

        }
        public Transacao[] ListarCompras(int? id_produto, int? id_fornecedor, DateTime? data_inicial, DateTime? data_final, StatusTransacao statusTransacao)
        {
            return null;
        }
        public Transacao PesquisarVenda(int numeroNotaFiscal)
        {
            return null;
        }

        public RelatorioProdutosSemEstoque GerarRelatorioEstoqueMinimo()
        {
            return null;
        }
        public RelatorioProdutosMaisVendidos GerarRelatorioProdutosMaisVendidos(DateTime dataInicial, DateTime dataFinal)
        {
            return null;
        }
        public Transacao[] ListarTrocas(DateTime dataInicial, DateTime dataFinal)
        {
            return null;
        }
    }
}
