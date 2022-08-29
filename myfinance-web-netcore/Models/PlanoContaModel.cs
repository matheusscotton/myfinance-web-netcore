using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_netcore.Infra;

namespace myfinance_web_netcore.Models
{
    public class PlanoContaModel
    {
        public int? Id {get; set;}

        public string? Descricao {get; set;}

        public string? Tipo {get; set;}

        public PlanoContaModel()
		{
			Id = 0;
			Descricao = "";
			Tipo = "";
		}
			
        public void Inserir ()
        {
            var objDAL  = DAL.GetInstancia;
            objDAL.Conectar();
            var sql = $"INSERT INTO PLANO_CONTAS (DESCRICAO, TIPO) VALUES ('{Descricao}','{Tipo}')";
            objDAL.ExecutarCommandoSQL(sql);
            objDAL.Desconectar();
        }


        public void Atualizar (int? id)
        {
            var objDAL  = DAL.GetInstancia;
            objDAL.Conectar();
            var sql = "UPDATE PLANO_CONTAS SET " +
                      $"Descricao = '{Descricao}',"+  
                      $"Tipo = '{Tipo}'"+
                      $"Where id = {id}";

            objDAL.ExecutarCommandoSQL(sql);
            objDAL.Desconectar();
        }

        public void Excluir (int id)
        {
            var objDAL  = DAL.GetInstancia;
            objDAL.Conectar();
            var sql = $"DELETE FROM PLANO_CONTAS WHERE ID = {id}";
            objDAL.ExecutarCommandoSQL(sql);
            objDAL.Desconectar();
        }

        public List<PlanoContaModel> ListaPlanoContas()
        {
            List<PlanoContaModel> lista = new List<PlanoContaModel>();
            var objDAL  = DAL.GetInstancia;
            objDAL.Conectar();
            var sql = "Select id, descricao, tipo from plano_contas";
            var dataTable = objDAL.RetornarDataTable(sql);

            for (int i=0; i< dataTable.Rows.Count; i++)
            {
                
				var plano_conta = new PlanoContaModel(){
                    Id = int.Parse (dataTable.Rows[i]["id"].ToString()),
                    Descricao = dataTable.Rows[i]["descricao"].ToString(),
                    Tipo = dataTable.Rows[i]["tipo"].ToString()                                        
                };
                lista.Add(plano_conta);
            }

            return lista;
        }

        public PlanoContaModel CarregarPlanoContaPorId(int? id)
        {
            var objDAL  = DAL.GetInstancia;
            objDAL.Conectar();
            var sql = $"Select id, descricao, tipo from plano_contas where id = {id}";
            var dataTable = objDAL.RetornarDataTable(sql);

                
    		var plano_conta = new PlanoContaModel(){
                    Id = int.Parse (dataTable.Rows[0]["id"].ToString()),
                    Descricao = dataTable.Rows[0]["descricao"].ToString(),
                    Tipo = dataTable.Rows[0]["tipo"].ToString()                                        
                };

            return plano_conta;
        }


    }
}
