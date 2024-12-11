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
        public List<IAction> Actions { get; }

        public ActionContext(List<IAction> actions)
        {
            if (actions == null || actions.Count == 0) // logic check for null
            {
                throw new System.ArgumentException("Actions cannot be null or empty.");
            }
            Actions = actions;
            _action = actions[0]; // Default to the first action
        }

        // set the current action to perform
        public void SetAction(IAction action)
        {
            if (!Actions.Contains(action)) // check action is in list
            {
                throw new System.ArgumentException("Action not found in the available actions list.");
            }

            _action = action;
        }

        // perform the action in setaction
        public string PerformAction()
        {
            return _action.Attack(); // returns action details
        }
    }
}
