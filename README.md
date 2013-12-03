PrimeComm
=========

Small application/library suite to send and receive HP Prime Calculator programs.

PrimeComm
---------
<img src=http://content.screencast.com/users/erwinried/folders/Jing/media/e488be73-c0ed-4e80-ba96-43c48aaecd35/2013-12-03_0232.png /><br>
Windows application to send, receive, convert programs and do other operations with the HP Prime Calculator.

PrimeCmd
--------
<img src=http://content.screencast.com/users/erwinried/folders/Jing/media/d0cd4317-e707-45ec-ac81-425915332bba/2013-12-03_0229.png /><br>
Provides commandline access for PrimeComm operations.

PrimeLib
--------
Library to include HP Prime calculator functions from PrimeComm on your application. Documentation available here: http://services.ried.cl/primecomm/Help/?topic=html/4c2db46f-2e91-7461-ee2e-68962685662e.htm

__Example:__
Small example showing how to send and convert files:
    
    
    using PrimeLib;

    class Program
    {
        static void Main(string[] args)
        {
             // Instantiate the first connected calculator
             var myCalculator = new PrimeCalculator();
             
             // This checks for hardware changes, there are events available too, 
             // to stay notified from Insertions and Removals as PrimeComm main app uses
             calculator.CheckForChanges();
             
             // Creates a ready to send data object, with a new name for the script, reading an existent program backup
             var myProgram = new PrimeUsbData("my program", new PrimeProgramFile(@"d:\my_program.hpprgm", false).Data, 
                 myCalculator.OutputChunkSize);
             
             // Check if my calculator is connected, and send the program
             if(myCalculator.IsConnected)
                 mycalculator.Send(myProgram);
             
             // Save and convert the program to plain text
             myProgram.Save(@"d:\my_program_backup.txt"); 
        }
    }


Related
=======
HID/USB Library: https://github.com/mikeobrien/HidLibrary <br>
USB Library: https://bitbucket.org/adamfettig/usb (early version) <br>
Video: https://www.youtube.com/watch?v=4QGBjOD3LHo <br>
Source: https://github.com/eried/PrimeComm <br>
Download: http://ried.cl/wp-content/uploads/2013/11/PrimeComm.zip <br> 
Details: http://ried.cl/proyecto/utilidad-para-intercambiar-archivos-con-la-hp-prime-primecomm/
