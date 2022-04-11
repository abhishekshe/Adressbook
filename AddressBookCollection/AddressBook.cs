﻿using Address_Book_Problem_Collections;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AddressBook
{
    public class AddressBook
    {
        public Dictionary<string, ContactPersonInformation> addressBookMapper = new Dictionary<string, ContactPersonInformation>();
        public Dictionary<string, List<ContactDetails>> cityDetailsDictionary = new Dictionary<string, List<ContactDetails>>();
        public Dictionary<string, List<ContactDetails>> stateDetailsDictionary = new Dictionary<string, List<ContactDetails>>();
        public HashSet<string> cityList = new HashSet<string>();
        public HashSet<string> stateList = new HashSet<string>();
       
        public void AddAdressBook()
        {
            Console.WriteLine("\nEnter Name for the New Address Book");
            string name = Console.ReadLine();
            //checking address book, if name entered is existing
            if (addressBookMapper.ContainsKey(name))
            {
                Console.WriteLine("Address Book Already exist with this name");
            }
            else
            {
                //Adding the name and contact person information class in dictionary
                ContactPersonInformation contactPersonInformation = new ContactPersonInformation();
                addressBookMapper.Add(name, contactPersonInformation);
            }
        }

       
        public void AddContactsInAddressBook()
        {
            Console.WriteLine("\nEnter Name of address book to add new contact");
            string name = Console.ReadLine();
            //checking, if the name is existing in the dictionary
            if (!addressBookMapper.ContainsKey(name))
            {
                Console.WriteLine("No address book found with this name");
                Console.WriteLine("Please Enter Valid Name from following names:");
                //displaying the available dictionary names
                foreach (KeyValuePair<string, ContactPersonInformation> tempPair in addressBookMapper)
                {
                    Console.WriteLine(tempPair.Key);
                }
            }
            else
            {
                //calling the methods to add contact details in dictionary and displaying it
                ContactPersonInformation contactPersonInformation = addressBookMapper[name];
                contactPersonInformation.AddingContactDetails();
                contactPersonInformation.DisplayContactDetails();
            }
        }
       
        public void EditDetailsOfAddressBook()
        {
            Console.WriteLine("\nEnter Name of address book to modify contact details");
            string name = Console.ReadLine();
            //checking if the name exist in dictionary
            if (!addressBookMapper.ContainsKey(name))
            {
                Console.WriteLine("No address book found with this name");
                Console.WriteLine("Please Enter Valid Name from following names:");
                //displaying the names that are available in dictionary
                foreach (KeyValuePair<string, ContactPersonInformation> tempPair in addressBookMapper)
                {
                    Console.WriteLine(tempPair.Key);
                }
            }
            else
            {
                // calling the methods from contact person information to display and edit contact person details in address book 
                ContactPersonInformation contactPersonInformation = addressBookMapper[name];
                contactPersonInformation.EditingContactDetails();
                contactPersonInformation.DisplayContactDetails();
            }
        }
       
        public void DeleteContactsOfAddressBook()
        {
            Console.WriteLine("\nEnter Name of address book to delete contact details");
            string name = Console.ReadLine();
            if (!addressBookMapper.ContainsKey(name))
            {
                Console.WriteLine("No address book found with this name");
                Console.WriteLine("Please Enter Valid Name from following names:");
                foreach (KeyValuePair<string, ContactPersonInformation> tempPair in addressBookMapper)
                {
                    Console.WriteLine(tempPair.Key);
                }
            }
            else
            {
                //Calling method to delete contact details from address book
                ContactPersonInformation contactPersonInformation = addressBookMapper[name];
                contactPersonInformation.DeletingContactDetails();
                contactPersonInformation.DisplayContactDetails();
            }
        }
       
        public void DisplayingAddressBooks()
        {
            Console.WriteLine("***********************************************************");
            foreach (KeyValuePair<string, ContactPersonInformation> dictionaryPair in addressBookMapper)
            {
                Console.WriteLine("the name of address book is " + dictionaryPair.Key);
                ContactPersonInformation contactPersonInformation = dictionaryPair.Value;
                contactPersonInformation.DisplayContactDetails();
            }
        }
       
        public void DeletingAddressBook()
        {
            Console.WriteLine("\nEnter Name of address book to delete ");
            string name = Console.ReadLine();
            if (!addressBookMapper.ContainsKey(name))
            {
                Console.WriteLine("No address book found with this name");
                Console.WriteLine("Please Enter Valid Name from following names:");
                foreach (KeyValuePair<string, ContactPersonInformation> tempPair in addressBookMapper)
                {
                    Console.WriteLine(tempPair.Key);
                }
            }
            else
            {
                //Removes address book from the Dictionary
                addressBookMapper.Remove(name);
            }
        }
        
        public void SearchingByCity()
        {
            Console.WriteLine("Please enter the city");
            string searchCity = Console.ReadLine();

            //foreach loop to print name of address book and pass address book value to contact person information class
            foreach (KeyValuePair<string, ContactPersonInformation> keyValuePair in addressBookMapper)
            {
                Console.WriteLine("Name of the address book: " + keyValuePair.Key);
                ContactPersonInformation contactPersonInformation = keyValuePair.Value;

                contactPersonInformation.SearchingContactDetailsByCity(searchCity);
            }
            Console.WriteLine("Do you want to enter city again, press y for yes");
            string checkInput = Console.ReadLine();
            if (checkInput.ToLower() == "y")
            {
                SearchingByCity();
            }

        }
       
        public void SearchingByState()
        {
            //used to find custom exception, if state do not exist

            Console.WriteLine("Please enter the state");
            string searchState = Console.ReadLine();
            //foreach loop is used to print key for dictionary and pass the values of dictionary to contact person information class
            foreach (KeyValuePair<string, ContactPersonInformation> keyValuePair in addressBookMapper)
            {
                Console.WriteLine("Name of the address book: " + keyValuePair.Key);
                ContactPersonInformation contactPersonInformation = keyValuePair.Value;
                contactPersonInformation.SearchingContactDetailsByState(searchState);
            }
            Console.WriteLine("Do you want to enter state again, press y for yes");
            string checkInput = Console.ReadLine();
            if (checkInput.ToLower() == "y")
            {
                //Details of state are entered again.
                SearchingByState();
            }

        }
       
        public void ViewingCityDictionary()
        {
            foreach (KeyValuePair<string, List<ContactDetails>> cityDetails in cityDetailsDictionary)
            {
                Console.WriteLine(cityDetails.Key + ":");
                //index is used to maintain count of each city
                int index = 0;
                foreach (ContactDetails contactPerson in cityDetails.Value)
                {
                    Console.WriteLine($"First Name : {contactPerson.firstName} || Last Name: {contactPerson.lastName} || Address: {contactPerson.address} || City: {contactPerson.city} || State: {contactPerson.state}|| zip: {contactPerson.zip} || Phone No: {contactPerson.phoneNo} || eMail: {contactPerson.eMail}");
                    index++;
                }
                //displays name of city and count of contact details
                Console.WriteLine($"Total no of contact details in {cityDetails.Key} are {index}");
                Console.WriteLine("");

            }
        }
       
        public void ViewingStateDictionary()
        {
            foreach (KeyValuePair<string, List<ContactDetails>> stateDetails in stateDetailsDictionary)
            {
                Console.WriteLine(stateDetails.Key);
                //index is used to maintain count of each state
                int index = 0;
                foreach (ContactDetails contactPerson in stateDetails.Value)
                {
                    Console.WriteLine($"First Name : {contactPerson.firstName} || Last Name: {contactPerson.lastName} || Address: {contactPerson.address} || City: {contactPerson.city} || State: {contactPerson.state}|| zip: {contactPerson.zip} || Phone No: {contactPerson.phoneNo} || eMail: {contactPerson.eMail}");
                    index++;

                }
                //displays total count for each state
                Console.WriteLine($"Total no of contact details in {stateDetails.Key} are {index}");
                Console.WriteLine("");
            }
        }
       
        public void GettingCityNames()
        {
            //calling each address book
            foreach (KeyValuePair<string, ContactPersonInformation> keyValuePair in addressBookMapper)
            {
                ContactPersonInformation contactPersonInformation = keyValuePair.Value;
               
                foreach (string city in contactPersonInformation.GettingCityList())
                {
                    cityList.Add(city);
                }
            }
        }
       
        public void CreatingCityDictionary()
        {
            //foreach loop is used to iterate over city names in hashset citylist
            foreach (string cityName in cityList)
            {
                //list is defined of contact details for every new city
                List<ContactDetails> cityDetailsList = new List<ContactDetails>();
               
                foreach (KeyValuePair<string, ContactPersonInformation> keyValuePair in addressBookMapper)
                {
                    ContactPersonInformation contactPersonInformation = keyValuePair.Value;
                    cityDetailsList = contactPersonInformation.AddingContactDetailsByCity(cityName, cityDetailsList);
                }
                //after iterating over all address books, city and city details list are added in dictionary
                cityDetailsDictionary.Add(cityName, cityDetailsList);
            }
        }
        
        public void GettingStateNames()
        {
            //calling each address book
            foreach (KeyValuePair<string, ContactPersonInformation> keyValuePair in addressBookMapper)
            {
                ContactPersonInformation contactPersonInformation = keyValuePair.Value;
               
                foreach (string state in contactPersonInformation.GettingStateList())
                {
                    stateList.Add(state);
                }
            }
        }
      
        public void CreatingStateDictionary()
        {
            //foreach loop is used to iterate over state names in hashset citylist
            foreach (string stateName in stateList)
            {
                //list is defined of contact details for every new city
                List<ContactDetails> stateDetailsList = new List<ContactDetails>();
               
                foreach (KeyValuePair<string, ContactPersonInformation> keyValuePair in addressBookMapper)
                {
                    ContactPersonInformation contactPersonInformation = keyValuePair.Value;
                    stateDetailsList = contactPersonInformation.AddingContactDetailsByState(stateName, stateDetailsList);
                }
                //after iterating over all address books, city and city details list are added in dictionary
                stateDetailsDictionary.Add(stateName, stateDetailsList);
            }
        }
    }
}