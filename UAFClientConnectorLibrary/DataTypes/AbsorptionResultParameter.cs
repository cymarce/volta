namespace UAFClientConnectorLibrary.DataTypes
{

    public class AbsorptionResultParameter
    {
        public AbsorptionResultParameter()
        {

        }

        public string Nome { get; set; }

        public decimal? AmpereFase1 { get; set; }
        
        public decimal? AmpereFase2 { get; set; }
       
        public decimal? AmpereFase3 { get; set; }

        public decimal? TensioneFase1 { get; set; }

        public decimal? TensioneFase2 { get; set; }

        public decimal? TensioneFase3 { get; set; }

        public decimal? PotenzaFase1 { get; set; }

        public decimal? PotenzaFase2 { get; set; }

        public decimal? PotenzaFase3 { get; set; }

        public decimal? FattoreDiPotenza { get; set; }
       
        public decimal? Portata { get; set; }
       
        public decimal? Watt { get; set; }
       
        public decimal? Pressione { get; set; }
        
        public decimal? SquilibrioCorrenti { get; set; }
      
        public decimal? TensioneProva { get; set; }

        public decimal? Velocita { get; set; }

        public decimal? Pwm { get; set; }
    }
}