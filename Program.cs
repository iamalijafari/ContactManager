/*
 * This is the main method of program and calls other methods of classes.
 */
using System;

namespace Contact_List
{
    class Program
    {
        static void Main(string[] args)
        {
            char MainMenuKey;
            while(true)
            {
                ScreenMessages.PrintMainMenuTexts();
                MainMenuKey = Console.ReadKey().KeyChar;
                switch(MainMenuKey)
                {
                    case '1':
                        ScreenMessages.PrintAddContactTexts();
                        ContactsManager.AddContact();
                        break;
                    case '2':
                        ScreenMessages.PrintEditMenuTexts();
                        ContactsManager.ShowContacts(editCall:true);
                        break;
                    case '3':
                        ScreenMessages.PrintDeleteMenuTexts();
                        ContactsManager.ShowContacts(deleteCall:true);
                        break;
                    case '4':
                        ScreenMessages.PrintSearchMenuTexts();
                        char SearchMenuKey = Console.ReadKey().KeyChar;
                        Console.Write("\n\nEnter Contact ");
                        switch (SearchMenuKey)
                        {
                            case '1':
                                Console.Write("First Name: ");
                                ContactsManager.SearchContact(firstName: Console.ReadLine());
                                break;
                            case '2':
                                Console.Write("Middle Name: ");
                                ContactsManager.SearchContact(middleName: Console.ReadLine());
                                break;
                            case '3':
                                Console.Write("Last Name: ");
                                ContactsManager.SearchContact(lastName: Console.ReadLine());
                                break;
                            case '4':
                                Console.Write("Phone Number: ");
                                ContactsManager.SearchContact(phoneNumber: Console.ReadLine());
                                break;
                            case '5':
                                Console.Write("Email Addreaa: ");
                                ContactsManager.SearchContact(email: Console.ReadLine());
                                break;
                            case '6':
                                break;
                            default:
                                ScreenMessages.PrintErrorMessage();
                                break;
                        }
                        break;
                    case '5':
                        ScreenMessages.PrintShowAllContactsMenuTexts();
                        ContactsManager.ShowContacts();
                        break;
                    case '6':
                        ScreenMessages.PrintImportMenuTexts();
                        ContactsManager.ImportContactsFromTXTFile();
                        break;
                    case '7':
                        ScreenMessages.PrintExportMenuTexts();
                        ContactsManager.ExportContactsToTXTFile();
                        break;
                    case '8':
                        Environment.Exit(0);
                        break;
                    default:
                        ScreenMessages.PrintErrorMessage();
                        break;
                }
            }
        }
    }
}