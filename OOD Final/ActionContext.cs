using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD_Final.Interfaces;

namespace OOD_Final
{
    public class ActionContext
    {
        private IAction _action;

        public ActionContext(IAction action)
        {
            _action = action;
        }

        public void SetAction(IAction action)
        {
            _action = action;
        }

        public string PerformAction()
        {
            return _action.Attack();
        }
    }
}
