using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.ControlPanel.AutoController
{
    public interface IMediator
    {
        void AddItem(object item);
        void Notify(object sender);
    }
}
