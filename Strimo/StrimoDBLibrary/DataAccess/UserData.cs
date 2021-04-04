
using StrimoDBLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoDBLibrary.DataAccess
{
    public class UserData
    {
        public List<UserModel> GetUserById(string id) {
            SqlDataAccess sql = new SqlDataAccess();
            var parameter = new { id = id};
            var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", parameter, "DefaultConnection");
            return output;
        }
    }
}
