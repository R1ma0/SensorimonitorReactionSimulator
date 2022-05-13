using System;

namespace SensorimonitorReactionSimulatorV2._0.Core
{
    public class EventArgs<T> : EventArgs
    {
        #region Properties
        public T Value { get; private set; }
        #endregion

        #region Constructors
        public EventArgs(T value)
        {
            Value = value;
        }
        #endregion
    }
}
