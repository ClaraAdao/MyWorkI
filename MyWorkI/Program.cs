using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkI
{
    internal class Program
    {

        static void Main(string[] args)
        {
            IOrganizationService service = ConnectionFactory.GetService();

            Entity conta = new Entity("account");
            Console.WriteLine("Nome da conta: ");
            var name = (Console.ReadLine());
            conta["name"] = (name);

            Console.Clear();
            Console.WriteLine("Entre com o ID de um contato já existente: Se não possuir um, copie e cole um desses abaixo. ");
            Console.WriteLine();
            Console.WriteLine("Júlio Almeida - 79ae8582-84bb-ea11-a812-000d3a8b3ec6 ");
            Console.WriteLine("Marcos Cardoso - cdcfa450-cb0c-ea11-a813-000d3a1b1223 ");
            Console.WriteLine("Julieta Pena - d1bf9a01-b056-e711-abaa-00155d701c02 ");
            var id = (Console.ReadLine());
            conta["createdby"] = new Guid(id);

            Console.Clear();
            Console.WriteLine("Escolha uma opcão de contato: ");
            Console.WriteLine("1 - Email ");
            Console.WriteLine("2 - Telefone ");
            int op = int.Parse(Console.ReadLine());

            while (op != 1 && op != 2)
            {
                Console.Clear();
                Console.WriteLine("Opção inexistente! Tente novamente: ");
                Console.WriteLine("Escolha uma opcão de contato: ");
                Console.WriteLine("1 - Email ");
                Console.WriteLine("2 - Telefone ");
                op = int.Parse(Console.ReadLine());
            }
            conta["preferredcontactmethodcode"] = new OptionSetValue(Convert.ToInt32(op));
       
            Console.Clear();
            Console.WriteLine("Núnero de funcionários: ");
            var nfunc = (Console.ReadLine());
            conta["numberofemployees"] = (Convert.ToInt32(nfunc));

            Console.Clear();
            Console.WriteLine("Taxa de câmbio: ");
            var taxa = Console.ReadLine();
            conta["exchangerate"] = new decimal(Convert.ToDouble(taxa));

            Guid accountId = service.Create(conta);

            Console.Clear();
            Console.WriteLine("CONTA CADASTRADA COM SUCESSO!!");
            Console.WriteLine(" ");
            Console.WriteLine("DADOS DA CONTA");
            Console.WriteLine(" ");
            Console.WriteLine("Nome da conta: {0}", name);
            Console.WriteLine("Opção escolhida: {0}", op);
            Console.WriteLine("Número de funcionários: {0}", nfunc);
            Console.WriteLine("Taxa de câmbio: {0}", taxa);
            Console.WriteLine("Conta criada por: {0}", id);

            Console.WriteLine(" ");
            Console.WriteLine("Deseja cadastrar um contato vinculado a esta conta?");
            Console.WriteLine("S - sim");
            Console.WriteLine("N - não");
            string p = Console.ReadLine();

            while (p != "S" && p != "N")
            {
                Console.Clear();
                Console.WriteLine("Opção inexistente! Tente novamente: ");
                Console.WriteLine("Obs.: Utilize letra maiúscula neste campo. ");
                Console.WriteLine(" ");
                Console.WriteLine("Deseja cadastrar um contato vinculado a esta conta? Escolha: ");
                Console.WriteLine("S - sim");
                Console.WriteLine("N - não");
                p = (Console.ReadLine());
            }
            if (p == "S")
            {
                Entity contato = new Entity("contact");
                Console.WriteLine(" ");

                Console.Clear();
                Console.WriteLine("Nome do contato: ");
                var nome = Console.ReadLine();
                contato["firstname"] = nome;

                Console.Clear();
                Console.WriteLine("Sobrenome do contato: ");
                var sobrenome = Console.ReadLine();
                contato["lastname"] = sobrenome;

                Console.Clear();
                Console.WriteLine("Celular: ");
                var celular = Console.ReadLine();
                contato["mobilephone"] = celular;

                contato["parentcustomerid"] = new EntityReference("account", accountId);

                service.Create(contato);

                Console.Clear();

                Console.WriteLine(" ");
                Console.WriteLine("DADOS DA CONTA");
                Console.WriteLine(" ");
                Console.WriteLine("Nome da conta: {0}", name);
                Console.WriteLine("Opção escolhida: {0}", op);
                Console.WriteLine("Número de funcionários: {0}", nfunc);
                Console.WriteLine("Taxa de câmbio: {0}", taxa);
                Console.WriteLine("Conta criada por: {0}", id);


                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("CONTATO CADASTRADO COM SUCESSO!");
                Console.WriteLine(" ");
                Console.WriteLine("DADOS DO CONTATO");
                Console.WriteLine(" ");
                Console.WriteLine("Nome: {0} {1} ", nome, sobrenome);
                Console.WriteLine("Celular: {0}", celular);
                Console.WriteLine("Contato vinculado a conta: {0} ",name);
                Console.WriteLine("ID da conta: {0}", accountId);


            }
            else if(p == "N")
            {
                Environment.Exit(0);
            }

            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Obrigado por utilizar nossos serviços! Aperte qualquer tecla para sair.");
            Console.ReadKey();
        }
    }
}
