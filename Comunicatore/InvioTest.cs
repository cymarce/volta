using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UAFClientConnectorLibrary.DataTypes;
using log4net;
using System.Linq.Expressions;
using System.Configuration;
using System.ComponentModel;
using System.Web.UI.WebControls;

namespace Comunicatore
{
    public class InvioTest
    {
        static ILog log;

        public InvioTest()
        {
            log = log4net.LogManager.GetLogger("InvioTest");
        }

        public bool Invio(DatiPerInvioTest valori)
        {

            try
            {
                log.Info($"Invio esito prova (id {valori.guid}\n\tarchivio:\t{valori.nomeccsv}");
                var NGtestResult = new NG_TestResultParameter
                {
                    TensioneIsolamento = decimal.Parse(valori.tensioneisolamento),
                    ResistenzaIsolamento = decimal.Parse(valori.restistenzaisolamento),
                    TensioneRigidita = decimal.Parse(valori.tensionerigidità),
                    CorrenteRigidita = decimal.Parse(valori.correnterigidità),

                    DescrizioneEsito = valori.descrizioneesito,
                    Esito = valori.esito,

                    SerialNumber = valori.serialnumber,
                    //IdProgramma = valori.idprogramma,
                    NomeProgramma = valori.nomeprogramma,
                    CorrenteDiTerra = null,
                    ResistenzaDiTerra = null,
                    ID_Macchina = null,
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
                    //log.Debug("inizio invio");
                    var finalMaterial = valori.finalmaterial;
                    log.Debug($"Dati:FinalMaterial: {finalMaterial} - SerialNumber: {valori.serialnumber} - NomeProgramma: {valori.nomeprogramma} - DescrizioneEsito: {valori.descrizioneesito} - Esito: {valori.esito} - TensioneIsolamento: {valori.tensioneisolamento} - ResistenzaIsolamento: {valori.restistenzaisolamento} - TensioneRigidita: {valori.tensionerigidità} - CorrenteRigidita: {valori.correnterigidità}");
                    var response = Engineering.UAFClientConnectorLibrary.UAFConnector.StaticNG_SendTestResult(NGtestResult, finalMaterial);
                    //Console.WriteLine("Command NG_SendTestResult\n");
                    //Console.WriteLine($"Succeeded: {response.Succeeded}");
                    if (!response.Succeeded)
                    {
                        log.Warn("Invio fallito");
                        log.Debug($"Error {response.Error.ErrorCode}: {response.Error.ErrorMessage}");
                        return false;
                    }
                }
                catch (Exception ex)   //errore nella chiamata della libreria - si considera il sistama offline e non vanno segnati i record del db come da evitare
                {
                    log.Debug("InvioTest - errore servizio");
                    log.Debug(ex);
                    return false;
                }
            }
            catch (Exception ex)  //questa eccezzione deve fare il bubbleling al chiamante per discriminare tra un errore dei parametri ed uno della libreria
            {
                log.Error("InvioTest - errore codifica parametri");
                log.Debug(ex);
                throw new Exception();
            }
            return true;
        }

    }
}
