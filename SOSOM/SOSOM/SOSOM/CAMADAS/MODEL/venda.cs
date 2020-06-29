using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSOM.CAMADAS.MODEL
{
    public class venda
    {
        public int id { get; set; }
        public int cliente { get; set; }
        public DateTime data { get; set; }
        public virtual string nome { get; set; }
    }
}
