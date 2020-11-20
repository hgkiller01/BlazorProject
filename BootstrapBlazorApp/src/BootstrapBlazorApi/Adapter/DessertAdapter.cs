using BootstrapBlazorApi.Adapter.Interface;
using DataLibrary.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace BootstrapBlazorApi.Adapter
{
    public class DessertAdapter : DataBase, IDessertAdapter
    {
        public IEnumerable<Dessert> GetList(int pageIndex, int pageSize)
        {
            pageIndex -= 1;
            using(conn = new SqlConnection(ConnStr))
            {
                string sql = @"select * from Dessert order by DessertID offset 
                                @pageIndex * @pageSize rows fetch next @pageSize rows only";
                return conn.Query<Dessert>(sql,new { pageIndex = pageIndex, pageSize = pageSize });
            }
        }

        public int GetTotalCount()
        {
            using(conn = new SqlConnection(ConnStr))
            {
                string sql = @"select count(*) from Dessert";
                return conn.Query<int>(sql).FirstOrDefault();
            }
        }
    }
}
