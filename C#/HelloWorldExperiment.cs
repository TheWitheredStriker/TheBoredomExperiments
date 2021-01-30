/** Dependencies **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/** Begin code **/

namespace Hello_World_Experiment {
    class Program {
        static void Main(string[] args) {

            int Number = 0;

            /** We COULD use while (true) here, but I like
                doing stuff in dumb ways, so I instead use
                a loop that continues for as long as the number
                is a number -- long story short, an infinite loop. **/

            while (Number.GetType() == typeof(int)) { 
                Number++;
                Console.WriteLine(Number + GetSpaces(Number) + " | Hello, world!");
                Thread.Sleep(400);
            }

            Console.ReadKey(); // Don't shut down the program until the user hits a key 
        }

        /** Space control code ~
        
              If this code isn't present, then whenever we
              reach a number like 10, 100, 1000 etc, an extra
              space will be added and the " | Hello, world!"
              part will be pushed back.
              
              This part of the code ensures an equal number of
              spaces at all times by checking whenever the number
              at the start gets larger (e. g. 9 --> 10) and then
              eliminating one space, keeping equal distance.
              
       **/

        private static string GetSpaces(int CurrentNumber) {

            int      LengthNumber     =  CurrentNumber.ToString().Length;
            int      NumberSpaces     =  (10 - LengthNumber); 
            string   Spaces           =  "";
            
            for (int i = 0; i < NumberSpaces; i++)
                    Spaces += " ";

            return Spaces;
        }
    }
}
