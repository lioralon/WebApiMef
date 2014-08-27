using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiInterface;

namespace WebApiImplementation
{
    [Export(typeof(IMEFInterface))]
    public class MEFImplementation : IMEFInterface
    {

        public string GetName(string name)
        {
            return string.Format("Welcome {0} to MEF world!", name);
        }
    }
}
