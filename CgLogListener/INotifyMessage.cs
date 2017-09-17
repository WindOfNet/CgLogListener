using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CgLogListener
{
    public interface INotifyMessage
    {
        void Notify(string message);
    }
}
