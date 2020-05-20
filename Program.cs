using System;
using System.Data.SqlClient;
using Dapper;

namespace DapperCrud
{
    class Program
    {
        static void Main(string[] args)
        {
            CRUD add = new CRUD();
            add.Create();
            add.Create();
            add.Update();
            add.Read();
            add.Delete();
        }
    }
}
