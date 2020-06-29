using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSOM.CAMADAS.DAL
{
    public class Conexao
    {
        public static string getConexao()
        {
            return @"Data Source=.\sqlexpress;Initial Catalog=SOSOM;Integrated Security=True";
        }
    }
}
