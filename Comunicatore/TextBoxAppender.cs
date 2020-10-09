using log4net;
using log4net.Core;

namespace Comunicatore
{
    class TextBoxAppender : log4net.Appender.AppenderSkeleton

    {
        protected override void Append(LoggingEvent loggingEvent)
        {

            if (!(Globali.Mainform == null))
            {
                Globali.Mainform.rtxtLog_AggiungiRiga(RenderLoggingEvent(loggingEvent));
            }
        }
    }
}



/*
 *     Inherits log4net.Appender.AppenderSkeleton


    Const ShrinkTo As Integer = 200
    Const ShringTrigger As Integer = 250

    Dim righe() As String
    Sub New()

    End Sub
    Protected Overloads Overrides Sub Append(ByVal loggingEvent As log4net.Core.LoggingEvent)
        'scrive il log nella finestra iniziale dell'applicazione se esistente (Splash)
        Try
            'scrive il log nella finestra principale se esistente (cioè dopo che l'applicazione è stat corretamente avviata)
            If Not Form1 Is Nothing Then
                Form1.rtxtLog_AggiungiRiga(RenderLoggingEvent(loggingEvent))
            End If
        Catch ex As Exception
        End Try

    End Sub
*/