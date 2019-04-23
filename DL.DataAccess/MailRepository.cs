using Dapper;
using DL.DataAccess.Abstract;
using DL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.DataAccess
{
    public class MailRepository : IRepository<Mail>
    {
        private DbConnection connection;

        public MailRepository()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["appConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }
        public void Add(Mail item)
        {
            var sqlQuery = "insert into Mails (Id, CreationDate, DeletedDate, Theme, Text, ReceiverId) values(@Id, @CreationDate, @DeletedDate, @Theme, @Text, @ReceiverId)";
            var result = connection.Execute(sqlQuery, item);

            if (result < 1)
            {
                throw new Exception("Запись не вставлена!");
            }
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ICollection<Mail> GetAll()
        {
            var sqlQuery = "select * from Mails";
            return connection.Query<Mail>(sqlQuery).AsList();
        }

        public void Update(Mail item)
        {
            throw new NotImplementedException();
        }
    }
}
