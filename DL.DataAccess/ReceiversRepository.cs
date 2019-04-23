using DL.DataAccess.Abstract;
using DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using Dapper;

namespace DL.DataAccess
{
    public class ReceiversRepository : IRepository<Receiver>
    {
        private DbConnection connection;

        public ReceiversRepository()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["appConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }
        

        public void Add(Receiver item)
        {
            var sqlQuery = "insert into Receivers (Id, CreationDate, DeletedDate, FullName, Address) values(@Id, @CreationDate, @DeletedDate, @FullName, @Address)";
            var result = connection.Execute(sqlQuery, item);

            if(result < 1)
            {
                throw new Exception("Запись не вставлена!");
            }
        }

        public void Delete(Guid id)
        {
            
        }

        public void Dispose()
        {

        }

        public ICollection<Receiver> GetAll()
        {
            var sqlQuery = "select * from Receivers";
            return connection.Query<Receiver>(sqlQuery).AsList();
        }

        public void Update(Receiver item)
        {
            throw new NotImplementedException();
        }
    }
}
