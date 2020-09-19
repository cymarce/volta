using System;
using System.Collections.Generic;

namespace UAFClientConnectorLibrary.DataTypes
{
    public class DABSendTestResult: DABSendTestResult<TestResultParameter>
    {
        public DABSendTestResult()
        {
            
        }
        
    }

    public class DABSendTestResult<T>
    {
        public DABSendTestResult()
        {

        }


        public T Result { get; set; }
        public class Response : BaseResponse
        {
        }
    }
}
