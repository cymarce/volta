namespace UAFClientConnectorLibrary.DataTypes
{
    public class DABGetTestCard
    {
        public DABGetTestCard()
        {
        }
        
        public string SerialNumber { get; set; }

        public class Response: BaseResponse
        {
            public Response()
            {

            }
            
            public TestCardParameter TestCard { get; set; }
        }
    }
}
