using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace WOW_AH
{
    class Program
    {
        static void Main(string[] args)
        {
            String connetStr = "server=127.0.0.1;port=3306;user=root;password=wD980304; database=ah;";
            // server=127.0.0.1/localhost 代表本机，端口号port默认是3306可以    不写
            MySqlConnection conn = new MySqlConnection(connetStr);
            try
            {
                conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句
                Console.WriteLine("已经建立连接");
                //在这里使用代码对数据库进行增删查改
                string sql = "select * from AH where 物品名称 = '丝绸'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
                while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
                {
                    //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                    //Console.WriteLine(reader.GetInt32(0)+reader.GetString(1)+reader.GetString(2));
                    Console.WriteLine("最低价格：" + reader.GetString("最低价格") + "  " + "平均价格：" + reader.GetString("平均价格") + "  " + "物品数量：" + reader.GetString("物品数量"));//"userid"是数据库对应的列名，推荐这种方式
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
