using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSOM.CAMADAS.MODEL
{
    public class itemvenda
    {
        public int id { get; set; }
        public int venda { get; set; }
        public int produto { get; set; }
        public virtual string descricao { get; set; }
        public virtual string marca { get; set; }
        public int quantidade { get; set; }
        public float valor { get; set; }
    }
}
