using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_netcore.Infra;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Domain
{
    public class Transacao
    {

        public void Inserir (TransacaoModel formulario)
        {
            var objDAL  = DAL.GetInstancia;
            objDAL.Conectar();

            var sql = "INSERT INTO TRANSACAO (DATA, VALOR, TIPO, HISTORICO, ID_PLANO_CONTA) " +
                      "VALUES("+
                      $"'{formulario.Data.ToString("yyyy-MM-dd")}',"+
                      $"'{formulario.Valor}',"+
                      $"'{formulario.Tipo}',"+
                      $"'{formulario.Historico}',"+
                      $"'{formulario.IdPlanoConta}')";

            objDAL.ExecutarCommandoSQL(sql);
            objDAL.Desconectar();
        }


        public void Atualizar (TransacaoModel formulario)
        {
            var objDAL  = DAL.GetInstancia;
            objDAL.Conectar();
            var sql = "UPDATE TRANSACAO SET " +
                      $"DATA  = '{formulario.Data.ToString("yyyy-MM-dd")}',"+  
                      $"VALOR = '{formulario.Valor}',"+
                      $"Tipo  = '{formulario.Tipo}',"+
                      $"Historico  = '{formulario.Historico}',"+
                      $"ID_PLANO_CONTA  = '{formulario.IdPlanoConta}'"+
                      $" Where id = {formulario.Id}";

            objDAL.ExecutarCommandoSQL(sql);
            objDAL.Desconectar();
        }

        public void Excluir (int id)
        {
            var objDAL  = DAL.GetInstancia;
            objDAL.Conectar();
            var sql = $"DELETE FROM TRANSACAO WHERE ID = {id}";
            objDAL.ExecutarCommandoSQL(sql);
            objDAL.Desconectar();
        }

        public List<TransacaoModel> ListaTransacoes()
        {
            List<TransacaoModel> lista = new List<TransacaoModel>();

            var objDAL  = DAL.GetInstancia;
            objDAL.Conectar();
            
            var sql = "Select id, data, valor, tipo, historico, id_plano_conta from transacao";
            var dataTable = objDAL.RetornarDataTable(sql);

            for (int i=0; i< dataTable.Rows.Count; i++)
            {
                
				var transacao = new TransacaoModel(){
                    Id = int.Parse (dataTable.Rows[i]["id"].ToString()),
                    Data = DateTime.Parse ((dataTable.Rows[i]["data"].ToString())), 
                    Valor = Decimal.Parse ((dataTable.Rows[i]["valor"].ToString())), 
                    Tipo = dataTable.Rows[i]["tipo"].ToString(),
                    Historico = dataTable.Rows[i]["historico"].ToString(),
                    IdPlanoConta = int.Parse (dataTable.Rows[i]["id_plano_conta"].ToString())
                };
                lista.Add(transacao);
            }

            return lista;
        }

        public TransacaoModel TransacaoPorId(int? id)
        {
            var objDAL  = DAL.GetInstancia;
            objDAL.Conectar();
            
            var sql = $"Select id, data, valor, tipo, historico, id_plano_conta from transacao WHERE ID = {id}";
            var dataTable = objDAL.RetornarDataTable(sql);

			var transacao = new TransacaoModel(){
                    Id = int.Parse (dataTable.Rows[0]["id"].ToString()),
                    Data = DateTime.Parse ((dataTable.Rows[0]["data"].ToString())), 
                    Valor = Decimal.Parse ((dataTable.Rows[0]["valor"].ToString())), 
                    Tipo = dataTable.Rows[0]["tipo"].ToString(),
                    Historico = dataTable.Rows[0]["historico"].ToString(),
                    IdPlanoConta = int.Parse (dataTable.Rows[0]["id_plano_conta"].ToString())
                };

            return transacao;
        }

        public List<TransacaoModel> ListaTransacoesToDates(String dataInit, String dataEnd)
        {
            List<TransacaoModel> lista = new List<TransacaoModel>();

            var objDAL  = DAL.GetInstancia;
            objDAL.Conectar();
            
            var sql = "Select id, data, valor, tipo, historico, id_plano_conta from transacao "+
                      " where (Data between " +
                      $"'{dataInit}' and '{dataEnd}') and"+ 
                      $"(Tipo='D' or Tipo='C')";

            //select * from transacao where 
                //(data between "2022-08-27" and "2022-08-28")  
                //and (tipo='D' or tipo='C');
          
            var dataTable = objDAL.RetornarDataTable(sql);

            for (int i=0; i< dataTable.Rows.Count; i++)
            {
                
				var transacao = new TransacaoModel(){
                    Id = int.Parse (dataTable.Rows[i]["id"].ToString()),
                    Data = DateTime.Parse ((dataTable.Rows[i]["data"].ToString())), 
                    Valor = Decimal.Parse ((dataTable.Rows[i]["valor"].ToString())), 
                    Tipo = dataTable.Rows[i]["tipo"].ToString(),
                    Historico = dataTable.Rows[i]["historico"].ToString(),
                    IdPlanoConta = int.Parse (dataTable.Rows[i]["id_plano_conta"].ToString())
                };
                lista.Add(transacao);
            }

            return lista;
        }


    }
}