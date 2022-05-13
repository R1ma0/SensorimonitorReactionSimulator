namespace SensorimonitorReactionSimulatorV2._0.MVVM.Models.Xml
{
    public class StatisticalParameters
    {
        #region Properties
        public string ParameterTitle { get; set; } = "Null";
        public string ParameterValue { get; set; } = "Null";
        #endregion

        #region Constructors
        public StatisticalParameters() { }
        public StatisticalParameters(string parameterTitle, string parameterValue)
        {
            ParameterTitle = parameterTitle;
            ParameterValue = parameterValue;
        }
        #endregion
    }
}
