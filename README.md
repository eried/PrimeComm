PrimeComm
=========

Small application/library suite to send and receive HP Prime Calculator files. Built reverse engineering the device. Calculator Hacking needs Pepsi, wanna help? :D<br>
[<img src="https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif">](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=LTJTUX8WPHPNW)

PrimeComm
---------
<img src=http://content.screencast.com/users/erwinried/folders/Jing/media/e488be73-c0ed-4e80-ba96-43c48aaecd35/2013-12-03_0232.png /><br>
Windows application to send, receive, convert programs and do other operations with the HP Prime Calculator. Is able to do some code refactoring, convert formats like images to something the HP Prime can display, etc:

<img src=http://f.cl.ly/items/0H243P273M1g073a0N3C/Image%202013-12-22%20at%205.15.00%20PM.png /><br>

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


>_Note: The current version 0.7 don't implement yet the Command Server mode arguments and since this was a major change to a library based applications, there are some small glitches yet when Receiving and then doing something else._


Demos
=====
Version 0.1: https://www.youtube.com/watch?v=4QGBjOD3LHo (Send and receive)<br>
Version 0.5: https://www.youtube.com/watch?v=FxG-R0QZ-qI (Conversion to plain text)<br>
Version 0.7: https://www.youtube.com/watch?v=UVALe40TPkc (Command server mode)<br>


Related
=======
HID/USB Library: https://github.com/mikeobrien/HidLibrary <br>
USB Library: https://bitbucket.org/adamfettig/usb (early version) <br>
Source: https://github.com/eried/PrimeComm <br>
Download last version: http://servicios.ried.cl/primecomm/ <br> 
Details: http://ried.cl/proyecto/utilidad-para-intercambiar-archivos-con-la-hp-prime-primecomm/
