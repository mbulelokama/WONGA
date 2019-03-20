using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA_Architecture
{
    [Serializable]
    public class RequesterObject
    {
        private string requestproerty;

        public string Requestproerty
        {
            get { return requestproerty; }
            set { requestproerty = value; }
        }
    }
}
