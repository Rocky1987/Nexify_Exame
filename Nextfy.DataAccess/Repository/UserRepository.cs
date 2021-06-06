using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Nexify.DataAccess.Repository;
using Nexify.DataAccess.DataModel;
using System.Data.SQLite;

namespace Nexify.DataAccess.Repository
{
    public class UserRepository : IUerRepository
    {
        private readonly string cnStr;
        public UserRepository(string cnStr)
        {
            if (string.IsNullOrEmpty(cnStr))
                throw new ArgumentNullException("db connection is null");

            this.cnStr = cnStr;
        }

        public void Creat() {
            using (SQLiteConnection cn = new System.Data.SQLite.SQLiteConnection(cnStr)) {
                cn.Execute(@"
                    CREATE TABLE User 
                    (         
                        
                        Name VARCHAR(10),
                        DateOfBirth DATETIME,
                        Salary INTEGER,
                        Address VARCHAR(50)
                      
                    )
                ");
            }
        }

        public int Add(UserDataModel userDataModel) {

            using(var cn = new SQLiteConnection(this.cnStr)) {
               return cn.Execute(@"
                    Insert into User VALUES (
                    @Name
                   ,@DateOfBirth
                   ,@Salary
                   ,@Address)"
                    , userDataModel);
            }
        }

        public IEnumerable<UserDataModel> Query() {

            using (var cn = new SQLiteConnection(this.cnStr))
            {
                return cn.Query<UserDataModel>(@"
                    Select 
                        Name
                        ,DateOfBirth
                        ,Salary
                        ,Address
                    From User
                    Order By Name"
                );
            }           
        }
    }
}
