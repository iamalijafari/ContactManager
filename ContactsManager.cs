/*
 * This file contains the manager class of the whole program.
 * First method named AddContact, As the name implies this method adds a contact to contact lists.
 * AddContact method uses some optional parameters, When it called from program class it does`t user any parameter,
 * but when it called from ImportContactFromTXTFile method it uses all parameters.
 * EditContact method shows the contacts list and get id of contact to edit.
 * DeleteContact method shows the contacts list and get id of contact to delete.
 * SearchContact methos gets some optional parameters and it`s able to serch contact list by any field.
 * ShowContact method prints all contacts info.
 * ImportContactFromTXTFile method uses txt file to import contacts of file to program.
 * ExportContactToTXTFile method exports all contact in program list to txt file.
 * NOTE: Passed file for importing must have the exported file format.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Contact_List
{
    class ContactsManager
    {
        public static List<Contact> AddressBook = new List<Contact>();
        public static void AddContact(string firstName="", string middleName = "", string lastName = "", string phoneNumber = "", string email = "", bool importTxtCall = false)
        {
            StringBuilder FirstName = new StringBuilder("");
            StringBuilder MiddleName = new StringBuilder("");
            StringBuilder LastName = new StringBuilder("");
            StringBuilder PhoneNumber = new StringBuilder("");
            StringBuilder Email = new StringBuilder("");
            if (importTxtCall == false)
            {
                Console.Write("Enter Contact First Name: ");
                FirstName.Append(Console.ReadLine());
                Console.Write("Enter Contact Middle Name: ");
                MiddleName.Append(Console.ReadLine());
                Console.Write("Enter Contact Last Name: ");
                LastName.Append(Console.ReadLine());
                Console.Write("Enter Contact Phone Number: ");
                PhoneNumber.Append(Console.ReadLine());
                Console.Write("Enter Contact Email: ");
                Email.Append(Console.ReadLine());
                Console.Write("\n\nContact Saved.\nPress any key to continue.");
                Console.ReadKey();
            }
            else
            {
                FirstName.Append(firstName);
                MiddleName.Append(middleName);
                LastName.Append(lastName);
                PhoneNumber.Append(phoneNumber);
                Email.Append(email);
            }
            Contact newContact = new Contact(FirstName.ToString(), MiddleName.ToString(), LastName.ToString(), PhoneNumber.ToString(), Email.ToString());
            AddressBook.Add(newContact);
        }
        public static void EditContact(byte id)
        {
            int ID = id - 1;
            if (ID < 0 || ID > AddressBook.Count - 1)
            {
                ScreenMessages.PrintErrorMessage();
                return;
            }
            Contact person = AddressBook[ID];
            Console.Clear();
            ScreenMessages.PrintEditMenuTexts();
            Console.WriteLine("You are editting contact below:");
            Console.WriteLine($"{id}- Contact Name: {person.FirstName} {person.MiddleName} {person.LastName}, Contact Phone Number: {person.PhoneNumber}, Contact Email Address: {person.Email}");
            Console.WriteLine("*******************************************************************************");
            Console.Write("\nEnter Contact First Name: ");
            StringBuilder firstName = new StringBuilder(Console.ReadLine());
            Console.Write("Enter Contact Middle Name: ");
            StringBuilder middleName = new StringBuilder(Console.ReadLine());
            Console.Write("Enter Contact Last Name: ");
            StringBuilder lastName = new StringBuilder(Console.ReadLine());
            Console.Write("Enter Contact Phone Number: ");
            StringBuilder phoneNumber = new StringBuilder(Console.ReadLine());
            Console.Write("Enter Contact Email: ");
            StringBuilder email = new StringBuilder(Console.ReadLine());
            Console.WriteLine("*******************************************************************************");
            person.FirstName = firstName.ToString();
            person.MiddleName = middleName.ToString();
            person.LastName = lastName.ToString();
            person.PhoneNumber = phoneNumber.ToString();
            person.Email = email.ToString();
            Console.WriteLine("\nSaved changes.");
            Console.WriteLine($"{id}- Contact Name: {person.FirstName} {person.MiddleName} {person.LastName}, Contact Phone Number: {person.PhoneNumber}, Contact Email Address: {person.Email}");
            Console.Write("Press any key to continue.");
            Console.ReadKey();
        }
        public static void DeleteContact(byte id)
        {
            int ID = id - 1;
            if (ID < 0 || ID > AddressBook.Count - 1)
            {
                ScreenMessages.PrintErrorMessage();
                return;
            }
            Console.Clear();
            ScreenMessages.PrintDeleteMenuTexts();
            Contact person = AddressBook[ID];
            Console.WriteLine("You are deleting contact below:");
            Console.WriteLine($"{id}- Contact Name: {person.FirstName} {person.MiddleName} {person.LastName}, Contact Phone Number: {person.PhoneNumber}, Contact Email Address: {person.Email}");
            Console.WriteLine("*******************************************************************************");
            Console.Write("\nAre you sure? (y/n)");
            char SureKey = Console.ReadKey().KeyChar;
            Console.WriteLine("*******************************************************************************");
            Console.Write("\n");
            switch (SureKey)
            {
                case 'y':
                    AddressBook.RemoveAt(ID);
                    Console.WriteLine("Contact deleted.");
                    break;
                case 'n':
                    Console.WriteLine("Ok.");
                    break;
                default:
                    ScreenMessages.PrintErrorMessage();
                    break;
            }
            Console.Write("Press any key to continue.");
            Console.ReadKey();
        }
        public static void SearchContact(string firstName = null, string middleName = null, string lastName = null, string phoneNumber = null, string email = null)
        {
            Console.WriteLine("\n*******************************************************************************");
            Console.WriteLine($"Match contact(s)".PadLeft(48,' '));
            Console.WriteLine("*******************************************************************************");
            int id = 1;
            Contact[] contact;
            if (firstName != null) contact = AddressBook.FindAll(x => x.FirstName == firstName).ToArray();
            else if (middleName != null) contact = AddressBook.FindAll(x => x.MiddleName == middleName).ToArray();
            else if (lastName != null) contact = AddressBook.FindAll(x => x.LastName == lastName).ToArray();
            else if (phoneNumber != null) contact = AddressBook.FindAll(x => x.PhoneNumber == phoneNumber).ToArray();
            else contact = AddressBook.FindAll(x => x.Email == email).ToArray();
            if (contact != null)
            {
                foreach(Contact Person in contact) Console.WriteLine($"{id++}- Contact Name: {Person.FirstName} {Person.MiddleName} {Person.LastName}, Contact Phone Number: {Person.PhoneNumber}, Contact Email Address: {Person.Email}");
            }
            else Console.WriteLine("No such contact found.");
            Console.WriteLine("******************************************************************************");
            Console.Write("\nPress any key to continue.");
            Console.ReadKey();
        }
        public static void ShowContacts(bool editCall = false, bool deleteCall = false, bool importTxtCall = false)
        {
            if (importTxtCall == false)
            {
                Console.WriteLine($"All {AddressBook.Count} contact(s)");
                Console.WriteLine("*******************************************************************************");
            }
            int id = 1;
            foreach (Contact person in AddressBook)
            {
                Console.WriteLine($"{id++}- Contact Name: {person.FirstName} {person.MiddleName} {person.LastName}, Contact Phone Number: {person.PhoneNumber}, Contact Email Address: {person.Email}");
            }
            Console.WriteLine("*******************************************************************************");
            byte k;
            byte DefaultValue = 0;
            if (editCall)
            {
                Console.Write("Enter contact id to edit: ");
                k = byte.TryParse(Console.ReadLine(), out byte K) ? K : DefaultValue;
                EditContact(k);
            }
            else if (deleteCall)
            {
                Console.Write("Enter contact id to delete: ");
                k = byte.TryParse(Console.ReadLine(), out byte K) ? K : DefaultValue;
                DeleteContact(k);
            }
            else if (importTxtCall == false)
            {
                Console.Write("\nPress any key to continue.");
                Console.ReadKey();
            }
        }
        public static void ImportContactsFromTXTFile()
        {
            Console.Write("Enter txt file address: ");
            string address = Console.ReadLine();
            string[] TextLines = File.ReadAllLines(address);
            foreach (string line in TextLines)
            {
                AddContact(line.Split(",")[0], line.Split(",")[1], line.Split(",")[2], line.Split(",")[3], line.Split(",")[4],true);
            }
            Console.WriteLine($"\nAll contact(s) imported".PadLeft(51,' '));
            Console.WriteLine("******************************************************************************");
            ShowContacts(importTxtCall:true);
            Console.Write("\nAll contacts imported.\nPress any key to continue.");
            Console.ReadKey();
        }
        public static void ExportContactsToTXTFile()
        {
            Console.Write("Enter txt file address: ");
            string address = Console.ReadLine();
            List<string> TextLinesList = new List<string>();
            foreach (Contact person in AddressBook)
            {
                TextLinesList.Add(person.FirstName + "," + person.MiddleName + "," + person.LastName + "," + person.PhoneNumber + "," + person.Email);
            }
            string[] TextLines = TextLinesList.ToArray();
            File.WriteAllLines(address, TextLines);
            Console.Write("\n\nAll contacts saved in file.\nPress any key to continue.");
            Console.ReadKey();
        }
    }
}
