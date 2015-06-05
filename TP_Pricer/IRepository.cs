using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TP_Pricer
{
    public interface IRepository<T> where T : class
    {
        void LoadFile(string path);
        T GetAll();
        Object GetListByDate(DateTime date);
        Object GetHeader();
    }
}
