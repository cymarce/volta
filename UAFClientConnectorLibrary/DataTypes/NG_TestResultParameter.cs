namespace UAFClientConnectorLibrary.DataTypes
{
    public class NG_TestResultParameter:TestResultParameter
    {
        public string NG_ReleaseSoftwareNfc { get; set; }

        public string NomeProgramma { get; set; }

        public int? IdProgramma { get; set; }

        public byte[] NG_FotoCurvaAssorbimento { get; set; }

        public byte[] NG_FotoLed1 { get; set; }

        public byte[] NG_FotoLed2 { get; set; }
    }
}