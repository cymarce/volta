using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comunicatore
{
    class Globali
    {
        public  static Form1 Mainform;
        public static bool InAvvio;
        public static bool InArresto = false;
        public static string dblocation;
        public static InvioTest Invio;
        public static bool InvioInCorso;
    }


    public class DatiPerInvioTest
    {
        public string nomeccsv { get; set; }
        public Guid guid { get; set; }

        public string tensionerigidità { get; set; }
        public string correnterigidità { get; set; }
        public string restistenzaisolamento { get; set; }
        public string tensioneisolamento  { get; set; }
        public string esito { get; set; }
        public string descrizioneesito  { get; set; }
        public string serialnumber  { get; set; }
        public string idprogramma { get; set; }
        public string nomeprogramma  { get; set; }
        public string finalmaterial  { get; set; }


    }
}
