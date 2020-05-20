using System;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DapperCrud
{
    public class CRUD
    {
        public int Id = 0;
        
        public static string constring = "Data source=localhost; Initial catalog = Test; user= sa;password=S1806Kh2111; Trusted_Connection=True;";
        public void Create(){
            Client client = new Client();
            System.Console.Write("FirstName: ");
            client.FirstName = Console.ReadLine();
            System.Console.Write("MiddleName: ");
            client.MiddleName = Console.ReadLine();
            System.Console.Write("Phone: ");
            client.Phone = int.Parse(Console.ReadLine());
            using(SqlConnection conn = new SqlConnection(constring)){
                conn.Open();
                var res = conn.Execute($"INSERT INTO Client(FirstName, MiddleName, Phone) VALUES({client.FirstName},{client.MiddleName},{client.Phone})");
                if(res > 0){
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine("Client inserted successfully!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Error!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public void Read(){
            using(SqlConnection conn = new SqlConnection(constring)){
                conn.Open();
                var clients = conn.Query<Client>("SELECT * FROM Client").ToList();
                foreach(var client in clients){
                    System.Console.WriteLine($"{client.Id}.{client.MiddleName} {client.FirstName}  Phone: {client.Phone}");
                }
                conn.Close();
            }
        }
        
    }
}