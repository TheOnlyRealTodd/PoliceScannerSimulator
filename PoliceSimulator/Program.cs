using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Speech.Synthesis;
using Microsoft.SqlServer.Server;

namespace PoliceSimulator
{
    
    class Program
    {
        private readonly SpeechSynthesizer dispatcher = new SpeechSynthesizer();
        private readonly SpeechSynthesizer officer = new SpeechSynthesizer();
        private string firstOfficer = "";
        private string secondOfficer = "";
        private string thirdOfficer = "";
        private bool isCode3 = false;
        static void Main(string[] args)
        {
            Program p = new Program();
            
            while (true)
            {
                p.DispatchNewCall();
                Thread.Sleep(5000);
                
            }
            
        }

       private void DispatchNewCall()
       {
            Random random = new Random();
            Dispatcher dispatcherInfo = new Dispatcher();
            Officer officer = new Officer();
           string dispatchMessage;
           firstOfficer = officer.OfficersToPick[random.Next(0, officer.OfficersToPick.Length)];
            secondOfficer = officer.OfficersToPick[random.Next(0, officer.OfficersToPick.Length)];
            thirdOfficer = officer.OfficersToPick[random.Next(0, officer.OfficersToPick.Length)];
            while (firstOfficer == secondOfficer || firstOfficer == thirdOfficer || secondOfficer == thirdOfficer)
           {
                if(firstOfficer == secondOfficer)
                    secondOfficer = officer.OfficersToPick[random.Next(0, officer.OfficersToPick.Length)];
                else if(firstOfficer == thirdOfficer)
                    thirdOfficer = officer.OfficersToPick[random.Next(0, officer.OfficersToPick.Length)];
                else if (secondOfficer == thirdOfficer)
                    thirdOfficer = officer.OfficersToPick[random.Next(0, officer.OfficersToPick.Length)];
            }
            string thisCall = Globals.CallTypes[random.Next(0, Globals.CallTypes.Length)];
           string thisCallsLocation = random.Next(0, 9999).ToString() + " " +
                                      Globals.Streets[random.Next(0, Globals.Streets.Length)];
           if (thisCall.Contains("hot prowl") || thisCall.Contains("fight") || thisCall.Contains("code cover"))
           {
               dispatchMessage = dispatcherInfo.StationName + " to " + firstOfficer + " and " + secondOfficer + "with " + thirdOfficer +
                                        " to cover " +
                                        "for " + thisCall + " at " + thisCallsLocation;
               isCode3 = true;
           }
           else
           {
               dispatchMessage = dispatcherInfo.StationName + " to " + firstOfficer + " and " + secondOfficer +
                                        " to cover " +
                                        "for " + thisCall + " at " + thisCallsLocation;
           }

           Console.WriteLine("[" + DateTime.Now.ToString("hh:mm:ss t z") + "] " + dispatchMessage);
           dispatcher.SelectVoiceByHints(VoiceGender.Female);
            dispatcher.Speak(dispatchMessage);
            Thread.Sleep(2000);
           OfficersEnRoute();



       }

        private void OfficersEnRoute()
        {
            Dispatcher dispatcherInfo = new Dispatcher();
            dispatcher.SelectVoiceByHints(VoiceGender.Female);
            officer.SelectVoiceByHints(VoiceGender.Male);
            if (isCode3)
            {
                officer.Speak(firstOfficer + " copy, enroute code.");
                officer.Speak(secondOfficer + " copy, en route code 3.");
                Thread.Sleep(1000);
                dispatcher.Speak(thirdOfficer + "?");
                officer.Speak(thirdOfficer + " en route code as well.");
                dispatcher.Speak("Ten four, all units en route; The channel is now clear for emergency traffic only. "
                                 + dispatcherInfo.StationName + " clear.");
                isCode3 = false;
            }
            else
            {
                officer.Speak(firstOfficer + " copy.");
                dispatcher.Speak("Unit to cover?");
                Thread.Sleep(1000);
                officer.Speak(secondOfficer + " en route.");
                dispatcher.Speak("Ten four, both units en route, " + dispatcherInfo.StationName + " clear at " +
                                 DateTime.Now.ToString("hh:mm:ss"));
            }
        }
    }
}
