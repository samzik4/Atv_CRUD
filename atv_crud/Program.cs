using atv_crud;
using atv_crud.DAO;
using atv_crud.Models;
using static System.Console;
using static System.Convert;

try
{
    int op1 = 0;

    do
    {
        int op = 0;

        Caixa cai = new Caixa();
        CaixaDAO cdao = new CaixaDAO();

        WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
        WriteLine("Bem vindo ao caixa!");
        WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-\n");
        WriteLine("Escolha uma opção: ");
        WriteLine("[1] Inserir registro");
        WriteLine("[2] Atualizar registro");
        WriteLine("[3] Deletar registro");
        WriteLine("[4] Listar registros\n");

        op = ToInt32(ReadLine());

        switch (op)
        {

            case 1:
                //insert
                Clear();

                WriteLine("Insira o saldo inicial: ");
                cai.saldoInicial = ToDouble(ReadLine());

                WriteLine("Insira o total de entradas: ");
                cai.totalEntradas = ToDouble(ReadLine());

                WriteLine("Insira o total de saídas: ");
                cai.totalSaidas = ToDouble(ReadLine());

                WriteLine("Insira o status do caixa (aberto ou fechado): ");
                cai.status = ReadLine();

                cai.saldoFinal = cai.saldoInicial + cai.totalEntradas - cai.totalSaidas;
                WriteLine("\nO saldo final é de: " + cai.saldoFinal);


                WriteLine("\nInsira o Id do Funcionário considerando: ");
                WriteLine("[1] Eloizy");
                WriteLine("[2] Samuel");
                WriteLine("[3] Patrick");
                WriteLine("[4] Fabricio");
                cai.IdFuncionario = ToInt32(ReadLine());

                cdao.Insert(cai);

                WriteLine("Deseja fechar o programa?");
                WriteLine("[1] Sim");
                WriteLine("[2] Não");

                op1 = ToInt32(ReadLine());

                Clear();
                break;


            case 2:
                //update
                Clear();

                WriteLine("Insira o ID do registro que você deseja alterar:");
                cai.IdCaixa = ToInt32(ReadLine());

                WriteLine("Insira o novo saldo inicial: ");
                cai.saldoInicial = ToDouble(ReadLine());

                WriteLine("Insira o novo total de entradas: ");
                cai.totalEntradas = ToDouble(ReadLine());

                WriteLine("Insira o novo total de saídas: ");
                cai.totalSaidas = ToDouble(ReadLine());

                WriteLine("Insira o novo status do caixa (aberto ou fechado): ");
                cai.status = ReadLine();

                cai.saldoFinal = cai.saldoInicial + cai.totalEntradas - cai.totalSaidas;
                WriteLine("O novo saldo final é de: " + cai.saldoFinal);


                WriteLine("Insira o Id do Funcionário considerando: ");
                WriteLine("[1] Eloizy");
                WriteLine("[2] Samuel");
                WriteLine("[3] Patrick");
                WriteLine("[4] Fabricio");
                cai.IdFuncionario = ToInt32(ReadLine());

                cdao.Update(cai);

                WriteLine("Deseja fechar o programa?");
                WriteLine("[1] Sim");
                WriteLine("[2] Não");

                op1 = ToInt32(ReadLine());

                Clear();

                break;

            case 3:
                //delete
                Clear();

                WriteLine("Insira o ID do registro que você deseja apagar:");
                cai.IdCaixa = ToInt32(ReadLine());
                cdao.Delete(cai);
                WriteLine("Deseja fechar o programa?");
                WriteLine("[1] Sim");
                WriteLine("[2] Não");

                op1 = ToInt32(ReadLine());
                Clear();
                break;

            case 4:
                //list
                Clear();


                foreach (Caixa caixa in cdao.List())
                {
                    WriteLine($"Id do caixa: {caixa.IdCaixa}");
                    WriteLine($"Saldo Inicial: {caixa.saldoInicial}");
                    WriteLine($"Total Entradas: {caixa.totalEntradas}");
                    WriteLine($"Total Saídas: {caixa.totalSaidas}");
                    WriteLine($"Status: {caixa.status}");
                    WriteLine($"Saldo Final: {caixa.saldoFinal}");
                    WriteLine($"ID Funcionário: {caixa.IdFuncionario}\n");
                }

                WriteLine("Deseja fechar o programa?");
                WriteLine("[1] Sim");
                WriteLine("[2] Não");

                op1 = ToInt32(ReadLine());
                Clear();
                break;
            default:
                Console.WriteLine("Operação inválida. Escolha um número entre 1 e 4.");
                break;

        }
    } while(op1 != 1);

}

catch (Exception ex)
{
    throw new Exception($"Erro de conexão {ex.Message}");
}

