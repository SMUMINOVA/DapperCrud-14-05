using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DapperCrud
{
    public class CRUD
    {
        public int Id = 0;
        
        public static string constring = "Data source=localhost; Initial catalog = Test; user= sa;password=S1806Kh2111; Trusted_Connection=True;";
        public void Read(){
            using(SqlConnection conn = new SqlConnection(constring)){
                conn.Open();
                var clients = conn.Query<Client>("SELECT * FROM Client").ToList();
                foreach(var client in clients){
                    System.Console.WriteLine($"{client.Id}.{client.MiddleName} {client.FirstName}  Phone: {client.Phone}");
                }
            }
        }
        
    }
}