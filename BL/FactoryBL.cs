using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FactoryBL
    {
        static IBl bl = null;
        public static IBl GetBl()
        {
            if (bl == null)
                bl = new Bl_imp();
            return bl;
        }
    }
}
