using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorimonitorReactionSimulatorV2._0.Core
{
    public static class Mediator
    {
        #region Fields
        private static IDictionary<string, List<Action<object>>> pl_dict = new Dictionary<string, List<Action<object>>>();
        #endregion

        #region Methods
        public static void Register(string token, Action<object> callback)
        {
            if (!pl_dict.ContainsKey(token))
            {
                List<Action<object>> list = new List<Action<object>>
                {
                    callback
                };
                pl_dict.Add(token, list);
            }
            else
            {
                bool found = false;
                foreach (Action<object> item in pl_dict[token])
                {
                    if (item.Method.ToString() == callback.Method.ToString())
                    {
                        found = true;
                    }
                }

                if (!found)
                {
                    pl_dict[token].Add(callback);
                }
            }
        }

        public static void Unregister(string token, Action<object> callback)
        {
            if (pl_dict.ContainsKey(token))
            {
                pl_dict[token].Remove(callback);
            }
        }

        public static void NotifyColleagues(string token, object args)
        {
            if (pl_dict.ContainsKey(token))
            {
                foreach(Action<object> callback in pl_dict[token])
                {
                    callback(args);
                }
            }
        }
        #endregion
    }
}
