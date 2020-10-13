using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UAFClientConnectorLibrary.DataTypes;
using log4net;
using System.Linq.Expressions;

namespace Comunicatore
{
    public class InvioTest
    {
        static ILog log;

        public InvioTest()
        {
            log = log4net.LogManager.GetLogger("InvioTest");

        }

        public  void Invio(string serialnumber, string idmacchina, string programma, string esito, string correnterigidità, string tensionerigidità, string restistenzaisolamento, string tensioneisolamento)
        {

            try
            {
                log.Debug("creazione richiesta");
                var NGtestResult = new NG_TestResultParameter
                {
                    SerialNumber = serialnumber,
                    DescrizioneEsito = esito,
                    TensioneIsolamento = decimal.Parse(tensioneisolamento),
                    CorrenteDiTerra = null,
                    ResistenzaDiTerra = null,
                    CorrenteRigidita = decimal.Parse(correnterigidità),
                    ResistenzaIsolamento = decimal.Parse(restistenzaisolamento),
                    Esito = esito,
                    TensioneRigidita = decimal.Parse(tensionerigidità),
                    ID_Macchina = idmacchina,
                    IdProgramma = null,
                    NomeProgramma = programma,
                    NG_ReleaseSoftwareNfc = null,
                    NG_FotoCurvaAssorbimento = null,
                    NG_FotoLed1 = null,
                    NG_FotoLed2 = null,

                    Assorbimenti = new List<AbsorptionResultParameter>() 
                    { 
                    new AbsorptionResultParameter
                    {
                        Nome = "AssorbimentoMonofase",
                        AmpereFase1 = null,
                        AmpereFase2 = null,
                        AmpereFase3 = null,
                        TensioneFase1 = null,
                        TensioneFase2 = null,
                        TensioneFase3 = null,
                        PotenzaFase1 = null,
                        PotenzaFase2 = null,
                        PotenzaFase3 = null,
                        FattoreDiPotenza = null,
                        Portata = null,
                        Watt = null,
                        Pressione = null,
                        SquilibrioCorrenti = null,
                        TensioneProva = null,
                        Velocita = null,
                        Pwm = null
                    }
                }
                };
                try
                {
                    var finalMaterial = "FM";
                    var response = Engineering.UAFClientConnectorLibrary.UAFConnector.StaticNG_SendTestResult(NGtestResult, finalMaterial);
                    //Console.WriteLine("Command NG_SendTestResult\n");
                    //Console.WriteLine($"Succeeded: {response.Succeeded}");
                    if (!response.Succeeded)
                    {
                        log.Warn("Invio fallito");
                        log.Warn($"Error {response.Error.ErrorCode}: {response.Error.ErrorMessage}");
                                            }
                }
                catch (Exception ex)
                {
                    log.Debug("InvioTest - errore servizio");
                    log.Debug(ex);
                    return;
                }
            }
            catch (Exception ex)
            {
                log.Debug("InvioTest - errore codifica parametri");
                log.Debug(ex);
            }

        }

    }
}
