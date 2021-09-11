using System;
using System.Data;

namespace AddressBookLINQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Address Book Using LINQ");
            AddressBook addressBookTable = new AddressBook();
            DataTable dataTable = addressBookTable.AddAddressBookDataTable();

            addressBookTable.DisplayContacts(dataTable);
            addressBookTable.EditContact(dataTable);
            addressBookTable.DeleteContact(dataTable);
            addressBookTable.RetrieveContactBelongingToCityOrState(dataTable);
            addressBookTable.GetSizeByCityOrState(dataTable);
            addressBookTable.SortContacts(dataTable);
            addressBookTable.GetCountByType(dataTable);
            addressBookTable.AddPersonToFriendsAndFamily(dataTable);
        }
    }
}
