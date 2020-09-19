using System;
using System.Collections.Generic;

namespace UAFClientConnectorLibrary.DataTypes
{
    public class NG_SendTestResult: DABSendTestResult<NG_TestResultParameter>
    {
        public string FinalMaterialNId { get; set; }
        public NG_SendTestResult():base()
        {
        }
    }
}