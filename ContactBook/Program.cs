using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactBook
{
    class Program
    {

        static void Main(string[] args)
        {
            //Varible used as an option selector in the main manu
            var choice = "0";

            //Main data storage dictionary declaration
            Dictionary<string, Tuple<string, string, string>> contactBook = new Dictionary<string, Tuple<string, string, string>>
            {
                { "", new Tuple<string, string, string> ("", "", "")},
            };

            //Contact info variables declaration
            var contactLastName = "";
            var contactName = "";
            var contactAddress = "";
            var contactPhoneNumber = "";


            //Welcome message
            Console.WriteLine("WELCOME TO YOUR CONTACT BOOK:");
            Console.WriteLine("----------------------------------------------");

            //Exit loop
            do
            {
                choice = Menu(); //Main menu function



                switch (choice)
                {
                    case "1": //Add new contact

                        Console.Clear();

                        ContactAdd(contactLastName, contactName, contactAddress, contactPhoneNumber, contactBook);

                        Console.WriteLine();

                        OutputAll(contactBook);


                        Console.WriteLine();
                        break;


                    case "2": //Change existing contact
                        Console.Clear();
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("2) CHANGE EXISTING CONTACT:");

                        var searchCheck = "";

                        OutputAll(contactBook);

                        do
                        {
                            Console.WriteLine("Input the phone number of the contact you want edit: ");
                            var editContact = Console.ReadLine();

                            if (contactBook.ContainsKey(editContact))
                            {
                                Console.WriteLine("\nChoose the element you would like to change(1-3):");
                                Console.WriteLine("1) Contact name");
                                Console.WriteLine("2) Contact address");
                                Console.WriteLine("3) Contact number");

                                var value = "0";

                                Console.Write("\nEnter value(1-3): ");
                                value = Console.ReadLine();

                                switch (value)
                                {
                                    case "1":
                                        Console.Write("Input new last name: ");
                                        var lastName2 = Console.ReadLine();

                                        Console.Write("Input new first name: ");
                                        var firstName2 = Console.ReadLine();

                                        var addressHolder = contactBook[editContact].Item3;

                                        contactBook[editContact] = new Tuple<string, string, string>(lastName2, firstName2, addressHolder);


                                        break;

                                    case "2":
                                        Console.Write("Input new address: ");
                                        var address2 = Console.ReadLine();

                                        var lastNameHolder = contactBook[editContact].Item1;
                                        var firstNameHolder = contactBook[editContact].Item2;

                                        contactBook[editContact] = new Tuple<string, string, string>(lastNameHolder, firstNameHolder, address2);

                                        break;

                                    case "3":
                                        Console.Write("Input new number: ");
                                        var number2 = Console.ReadLine();

                                        contactBook[number2] = contactBook[editContact];

                                        contactBook.Remove(editContact);

                                        break;
                                    default:
                                        Console.WriteLine("\nInvalid input!");
                                        Console.WriteLine("Please insert an acceptable value(1-6)\n");
                                        break;
                                }
                            }
                            else
                                Console.WriteLine("\nThere are no contacts with that phone number");

                            OutputAll(contactBook);
                            Console.WriteLine("Would you like to modify another contact(yes/no)?");
                            searchCheck = Console.ReadLine();

                        } while (searchCheck.ToLower() == "yes");

                        break;

                    case "3": // Delete contact

                        Console.Clear();
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("3) DELETE CONTACT:");

                        OutputAll(contactBook);

                        var deleteContact = "";

                        do
                        {
                            Console.Write("Input the phone number of the contact you want to delete: ");
                            deleteContact = Console.ReadLine();

                            if (!contactBook.ContainsKey(deleteContact))
                                Console.WriteLine("Invalid input!");

                        } while (!contactBook.ContainsKey(deleteContact));

                        Console.WriteLine($"Are you sure you want to delete {contactBook[deleteContact].Item2} {contactBook[deleteContact].Item1} from your contacts (yes/no)?");
                        var deleteConfirm = Console.ReadLine();

                        if (deleteConfirm.ToLower() != "yes" && deleteConfirm.ToLower() != "no")
                        {
                            do
                            {
                                Console.WriteLine("Invalid input!");
                                Console.WriteLine($"Are you sure you want to delete {contactBook[deleteContact].Item2} {contactBook[deleteContact].Item1} from your contacts (yes/no)?");
                                deleteConfirm = Console.ReadLine();
                            } while (deleteConfirm.ToLower() != "yes" && deleteConfirm.ToLower() != "no");
                        }
                        if (deleteConfirm.ToLower() == "yes")
                            contactBook.Remove(deleteContact);
                        else if (deleteConfirm.ToLower() == "no")
                            break;


                        Console.WriteLine();
                        break;


                    case "4": //Search by number
                        Console.Clear();
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("4) SEARCH BY NUMBER:");

                        OutputAll(contactBook);

                        searchCheck = "";
                        do
                        {
                            Console.WriteLine("Input the phone number of the contact you want to find: ");
                            var searchByNumber = Console.ReadLine();

                            if (contactBook.ContainsKey(searchByNumber))
                                Console.WriteLine($"{searchByNumber} - {contactBook[searchByNumber].Item1} {contactBook[searchByNumber].Item2}, {contactBook[searchByNumber].Item3}");
                            else
                                Console.WriteLine("There are no contacts with that phone number");

                            Console.WriteLine("Would you like to search again(yes/no)?");
                            searchCheck = Console.ReadLine();

                        } while (searchCheck.ToLower() == "yes");
                        break;

                    case "5": //Search by name
                        Console.Clear();
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("5) SEARCH BY NAME:");


                        OutputAll(contactBook);

                        searchCheck = "";

                        do
                        {
                            Console.WriteLine("Input the first name or the last name of the contact you want to find: ");
                            var searchByName = Console.ReadLine();

                            foreach (var el in contactBook.OrderBy(el => el.Value.Item1))
                            {

                                if (el.Value.Item1.Contains(searchByName) || el.Value.Item1.Contains(searchByName))
                                    Console.WriteLine($"{el.Value.Item1} {el.Value.Item2}, {el.Value.Item3}, {el.Key}");

                            }

                            Console.WriteLine("\nWould you like to search again(yes/no)?");
                            searchCheck = Console.ReadLine();

                        } while (searchCheck.ToLower() == "yes");

                        break;

                    case "6": //Exit
                        Console.Clear();
                        Console.WriteLine("GOODBYE!");
                        break;

                    default:
                        Console.WriteLine("\nInvalid input!");
                        Console.WriteLine("Please insert an acceptable value(1-6)\n");
                        break;
                }

            } while (choice != "6");
        }












        static string Menu()
        {

            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add new contact");
            Console.WriteLine("2) Change existing contact");
            Console.WriteLine("3) Delete contact");
            Console.WriteLine("4) Search by number");
            Console.WriteLine("5) Search by name");
            Console.WriteLine("6) Quit");
            Console.WriteLine();

            var choice = Selection();
            return choice;

        }

        static string Selection()
        {
            var value = "0";

            Console.Write("Enter value(1-6): ");
            value = Console.ReadLine();

            return value;
        }

        static void OutputAll(Dictionary<string, Tuple<string, string, string>> contactBook)
        {
            foreach (var par in contactBook)
            {
                if ((par.Key != ""))
                {
                    Console.WriteLine($"{par.Value.Item1} {par.Value.Item2}, {par.Value.Item3}, {par.Key}");
                }
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------\n");
        }


        static void ContactAdd(string contactLastName, string contactName, string contactAddress, string contactPhoneNumber, Dictionary<string, Tuple<string, string, string>> contactBook)
        {
            do
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("1) ADD NEW CONTACT:");

                Console.Write("Last name: ");
                contactLastName = Console.ReadLine();

                Console.Write("Name: ");
                contactName = Console.ReadLine();

                Console.Write("Address: ");
                contactAddress = Console.ReadLine();

                Console.Write("Phone number: ");
                contactPhoneNumber = PhoneNumberConfirmation();

                contactBook[contactPhoneNumber] = new Tuple<string, string, string>(contactLastName, contactName, contactAddress);

            } while (AddAnotherContact());

        }

        static string PhoneNumberConfirmation()
        {
            var phoneNumber = Console.ReadLine();

            Console.Write("Confirm phone number: ");
            var phoneNumberConfirm = Console.ReadLine();

            phoneNumber = PhoneNumberMatcher(phoneNumber, phoneNumberConfirm);

            return phoneNumber;

        }

        static string PhoneNumberMatcher(string number1, string number2)
        {
            if (number1 == number2)
                return number1;
            else
            {
                do
                {
                    Console.WriteLine("Phone number did not match!\n");

                    Console.Write("Please, retype phone number: ");
                    number1 = Console.ReadLine();

                    Console.Write("Confirm phone number: ");
                    number2 = Console.ReadLine();

                } while (number1 != number2);

                return number1;
            }
        }

        static bool AddAnotherContact()
        {
            Console.WriteLine("\nAdd another(Enter = Yes)?");
            var anotherContactCheck = Console.ReadLine();

            if (anotherContactCheck == "")
                return true;
            else
                return false;
        }
    }
}