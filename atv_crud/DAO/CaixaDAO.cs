using atv_crud.Models;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atv_crud.DAO
{
    public class CaixaDAO
    {
        public void Insert(Caixa caixa)
        {
            try
            {
                string sql = "INSERT INTO Caixa(saldo_inicial_cai, total_entradas_cai, total_saidas_cai, status_cai, saldo_final_cai, id_func_fk) VALUES(@saldoInicial, @totalEntradas, @totalSaidas, @status, @saldoFinal, @IdFuncionario)";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@saldoInicial", caixa.saldoInicial);
                comando.Parameters.AddWithValue("@totalEntradas", caixa.totalEntradas);
                comando.Parameters.AddWithValue("@totalSaidas", caixa.totalSaidas);
                comando.Parameters.AddWithValue("@status", caixa.status);
                comando.Parameters.AddWithValue("@saldoFinal", caixa.saldoFinal);
                comando.Parameters.AddWithValue("@IdFuncionario", caixa.IdFuncionario);

                comando.ExecuteNonQuery();
                Console.WriteLine("Insert realizado com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao cadastrar {ex.Message}");
            }
            finally
            {
                Conexao.FecharConexao();
            }
        }

        public void Delete(Caixa caixa)
        {
            try
            {
                string sql = "Delete FROM Caixa where id_cai = @id_cai";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@id_cai", caixa.IdCaixa);
                comando.ExecuteNonQuery();
                Console.WriteLine("Registro de caixa excluido com sucesso!");
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao excluir{ex.Message}");
            }

        }
        

        public void Update(Caixa caixa)
        {
            try
            {
                string sql = "UPDATE Caixa SET saldo_inicial_cai = @saldoInicial, total_entradas_cai = @totalEntradas, total_saidas_cai= @totalSaidas, status_cai = @status, saldo_final_cai = @saldoFinal, id_func_fk = @IdFuncionario where id_cai = @id_cai";
                
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                comando.Parameters.AddWithValue("@id_cai", caixa.IdCaixa);
                comando.Parameters.AddWithValue("@saldoInicial", caixa.saldoInicial);
                comando.Parameters.AddWithValue("@totalEntradas", caixa.totalEntradas);
                comando.Parameters.AddWithValue("@totalSaidas", caixa.totalSaidas);
                comando.Parameters.AddWithValue("@status", caixa.status);
                comando.Parameters.AddWithValue("@saldoFinal", caixa.saldoFinal);
                comando.Parameters.AddWithValue("@IdFuncionario", caixa.IdFuncionario);


                comando.ExecuteNonQuery();
                Console.WriteLine("Insert realizado com sucesso!");
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar {ex.Message}");
            }
        }

        public List<Caixa> List()
        {

            List<Caixa> Caixas = new List<Caixa>();

            try
            {
                string sql = "SELECT * FROM Caixa";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Caixa caixa = new Caixa();
                        caixa.saldoInicial = dr.GetDouble("saldo_inicial_cai");
                        caixa.totalEntradas = dr.GetDouble("total_entradas_cai");
                        caixa.totalSaidas = dr.GetDouble("total_saidas_cai");
                        caixa.status = dr.GetString("status_cai");
                        caixa.saldoFinal = dr.GetDouble("saldo_final_cai");
                        caixa.IdFuncionario = dr.GetInt32("id_func_fk");
                        Caixas.Add(caixa);
                    }

                }
                Conexao.FecharConexao();

            }

            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar {ex.Message}");
            }

            return Caixas;

        }
    }

}
