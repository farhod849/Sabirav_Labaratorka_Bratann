using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nol_Adin_Sabirov.Misc
{
    internal class Conn
    {
        public static Sabriov_BDEntities c;
        public static Sabriov_BDEntities context
        {
            get
            {
                if (c == null)
                    c = new Sabriov_BDEntities();
                return c;
            }
        }
    }
}
