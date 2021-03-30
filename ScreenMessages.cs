/*
 * This file contains a class with some static methods.
 * This methods contains texts of all menu heders and other texts.
 * Name of the methods shows where they called.
 */
using System;

namespace Contact_List
{
    class ScreenMessages
    {
        public static void PrintMainMenuTexts()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Adress Book".PadLeft(45,' '));
            Console.WriteLine("Main Menu".PadLeft(44,' '));
            Console.WriteLine("-------------------------------------------------------------------------------\n\n");
            Console.WriteLine("press 1: add contact");
            Console.WriteLine("press 2: edit contact");
            Console.WriteLine("press 3: delete contact");
            Console.WriteLine("press 4: search contact");
            Console.WriteLine("press 5: show all contacts");
            Console.WriteLine("press 6: import Contacts of txt file");
            Console.WriteLine("press 7: export Contacts to txt file");
            Console.WriteLine("press 8: exit");
            Console.Write("Waiting to press key: ");
        }
        public static void PrintAddContactTexts()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("Add Contact Menu".PadLeft(48, ' '));
            Console.WriteLine("--------------------------------------------------------------------------------\n\n");
        }
        public static void PrintEditMenuTexts()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Edit Contact Menu".PadLeft(48, ' '));
            Console.WriteLine("-------------------------------------------------------------------------------\n\n");
        }
        public static void PrintDeleteMenuTexts()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Delete Contact Menu".PadLeft(49, ' '));
            Console.WriteLine("-------------------------------------------------------------------------------\n\n");
        }
        public static void PrintSearchMenuTexts()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Search Menu".PadLeft(45, ' '));
            Console.WriteLine("-------------------------------------------------------------------------------\n\n");
            Console.WriteLine("press 1: search contacts with first name");
            Console.WriteLine("press 2: search contacts with middle name");
            Console.WriteLine("press 3: search contacts with last name");
            Console.WriteLine("press 4: search contacts with phone number");
            Console.WriteLine("press 5: search contacts with email");
            Console.WriteLine("press 6: main menu");
            Console.Write("Waiting to press key: ");
        }
        public static void PrintShowAllContactsMenuTexts()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("All Contact List Menu".PadLeft(50, ' '));
            Console.WriteLine("-------------------------------------------------------------------------------\n\n");
        }
        public static void PrintImportMenuTexts()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Import Menu".PadLeft(45, ' '));
            Console.WriteLine("-------------------------------------------------------------------------------\n\n");
        }
        public static void PrintExportMenuTexts()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Export Menu".PadLeft(45, ' '));
            Console.WriteLine("-------------------------------------------------------------------------------\n\n");
        }
        public static void PrintErrorMessage()
        {
            Console.Clear();
            Console.Write("Invalid entry.\nPlease try again.\nPress any key to continue.");
            Console.ReadKey();
        }
    }
}
