using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FactoryDal
    {
        static IDal dal = null;
        public static IDal GetDal()
        {
            if (dal == null)
            {
                dal = new Dal_XML_imp();
                //dal = new Dal_imp();
            }
            return dal;
        }
    }
}
