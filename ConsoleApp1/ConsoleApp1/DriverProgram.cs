//Author: Melissa Jones
//CPSC 5051, April 29th, 2018
//Revision History: 0
using System;
    
namespace EncryptWordHW2
{
     class DriverProgram
     {
         //private EncryptWord objects to test
         private EncryptWord testOne;
         private EncryptWord testTwo;
         private EncryptWord testThree;

         //This is the constructor
         public DriverProgram()
         {
             testOne = new EncryptWord("Melissa!! Ann.. J2Ones&");
             testTwo = new EncryptWord("Blah! Blah@ Blah 3", 4);
             testThree = new EncryptWord();
             
         }

         public void RunTest()
         {
             Console.Write("Testing EncryptWord object one: \n");
             Console.Write("Here is the original word: ");
             string originalword = testOne.Decrypt();
             Console.Write(originalword);
             Console.Write("\nNow here is the word after encryption " +
                           "and a check to say if it is on or not. \n");
             string encryptedword = testOne.EncryptOn();
             string ison = testOne.IsEncryptWordOn().ToString();
             Console.Write(encryptedword);
             Console.Write("\n");
             Console.Write(ison);
             Console.Write("\nNow turning the encryption off, here is the word " +
                           "and test to ensure that it is turned off: \n");

             string unencrypted = testOne.Decrypt();
             string isoff = testOne.IsEncryptWordOn().ToString();
             Console.Write(unencrypted);
             Console.Write("\n");
             Console.Write(isoff);
         }
     }
}