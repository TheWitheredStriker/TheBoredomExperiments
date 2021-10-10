' This program is a direct conversion of HelloWorldExperiment.cs (within the C# folder) to Visual Basic .NET.
' It behaves identically to the C# program and uses the same inner methods, leveraging the same peformance.
' I made this after realizing that essentially all differences between C# and VB.NET are purely aesthetic rather than functional.
' True to this repository's name, it's just an experiment made out of boredom.

' ----------------------------------------------------------------------------------------------------------------------


' Dependencies


imports System
imports System.Collections.Generic
imports System.Linq
imports System.Text
imports System.Threading
imports System.Threading.Tasks

' Begin code

namespace Hello_World_Experiment
    class Program
        private shared sub Main(byval args as string())
    
            dim Number as integer = 0
    
            ' We COULD use while (true) here, but I like
            ' doing stuff in dumb ways, so I instead use
            ' a loop that continues for as long as the number
            ' is a number -- long story short, an infinite loop.

            while Number.[gettype]() = gettype(integer)
                Number += 1
                Console.WriteLine(Number & GetSpaces(Number) & " | Hello, world!")
                Thread.Sleep(400)
            end while

            Console.ReadKey() ' Don't shut down the program until the user hits a key 
  
        end sub

        '                    Space control code ~
        
        '      If this code isn't present, then whenever we
        '      reach a number like 10, 100, 1000 etc, an extra
        '      space will be added and the " | Hello, world!"
        '      part will be pushed back.
              
        '      This part of the code ensures an equal number of
        '      spaces at all times by checking whenever the number
        '      at the start gets larger (e. g. 9 --> 10) and then
        '      eliminating one space, keeping equal distance.

        private shared function GetSpaces(byval CurrentNumber as integer) as string
  
            dim LengthNumber as integer = CurrentNumber.ToString().Length
            dim NumberSpaces as integer = (10 - LengthNumber)
            dim Spaces as string = ""

            for i as integer = 0 to NumberSpaces - 1
                Spaces += " "
            next

            return Spaces

        end function
    end class
end namespace
