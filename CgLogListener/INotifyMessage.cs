using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CgLogListener
{
    public interface INotifyMessage
    {
        bool Notify(string message);
    }
}
