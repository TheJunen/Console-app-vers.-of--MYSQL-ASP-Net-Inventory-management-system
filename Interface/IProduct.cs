using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webapp_Lagersystem_Intervju
{
    public interface IProduct
    {
        virtual void WriteOutInfo() { }
        void RetriveFromDataBase() { }
    }
}
