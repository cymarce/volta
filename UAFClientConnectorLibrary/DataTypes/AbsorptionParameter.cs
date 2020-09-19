﻿namespace UAFClientConnectorLibrary.DataTypes
{
    public class AbsorptionParameter
    {
        public AbsorptionParameter()
        { }

        public decimal? Ampere { get; set; }
        
        public decimal? AmperePercent { get; set; }
        
        public string Nome { get; set; }
        
        public decimal? Portata { get; set; }
       
        public decimal? PortataPercent { get; set; }
        
        public decimal? Pressione { get; set; }
        
        public decimal? PressionePercent { get; set; }
        
        public decimal? WatPercent { get; set; }
        
        public decimal? Watt { get; set; }
    }
}
