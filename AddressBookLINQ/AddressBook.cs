using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AddressBook_Linq
{
    public class AddressBook
    {
        public DataTable AddAddressBookDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("FirstName", typeof(string));
            table.Columns.Add("LastName", typeof(string));
            table.Columns.Add("Address", typeof(string));
            table.Columns.Add("City", typeof(string));
            table.Columns.Add("State", typeof(string));
            table.Columns.Add("Zip", typeof(int));
            table.Columns.Add("PhoneNumber", typeof(long));
            table.Columns.Add("Email", typeof(string));

            table.Rows.Add("Suchindra", "Chitnis", "B,14", "Mumbai", "Maharashtra", 400001, 9999999999, "qwerty@gmail.com");
            table.Rows.Add("Adarsh", "Pandith", "Banergattha Road", "Bangalore", "Karnataka", 500060, 8888888888, "uvwxyz@gmail.com");
            table.Rows.Add("Sreerag", "Nair", "Gandhi Road", "Hyderabad", "Telangana", 600576 , 7777777777, "qwert.oiu@gmail.com");
            table.Rows.Add("Aditi", "Shastri", "Link Road", "Chennai", "Tamil Nadu", 789065, 8790465132, "asdfg.lkj@gmail.com");
            table.Rows.Add("Ravi", "Kumar", "SV Road", "Patna", "Bihar", 300897, 9876543210, "zxcvb.nm@gmail.com");

            return table;
        }
        public void DisplayContacts(DataTable addresstable)
        {
            var contacts = addresstable.Rows.Cast<DataRow>();
            foreach (var contact in contacts)
            {
                Console.WriteLine("\n------------------------------------");
                Console.Write("First Name : " + contact.Field<string>("FirstName") + " " + "Last Name : " + contact.Field<string>("LastName") + " " + "Address : " + contact.Field<string>("Address") + " " + "City : " + contact.Field<string>("City") + " " + "State : " + contact.Field<string>("State")
                    + " " + "Zip : " + contact.Field<int>("Zip") + " " + "Phone Number : " + contact.Field<long>("PhoneNumber") + " " + "Email : " + contact.Field<string>("Email") + " ");
            }
        }
        public void EditContact(DataTable table)
        {
            var contacts = table.AsEnumerable().Where(x => x.Field<string>("FirstName") == "Rama");
            foreach (var contact in contacts)
            {
                contact.SetField("LastName", "Das");
                contact.SetField("City", "Mumbai");
                contact.SetField("State", "Maharashtra");
            }

            Console.WriteLine("The Contact is updated succesfully\n");
            DisplayContacts(contacts.CopyToDataTable());
        }
        public void DeleteContact(DataTable table)
        {
            var contacts = table.AsEnumerable().Where(x => x.Field<string>("FirstName") == "Asha");
            foreach (var row in contacts.ToList())
            {
                row.Delete();
            }
            Console.WriteLine("The Contact is deleted succesfully. Now the list contains following records \n");
            DisplayContacts(table);
        }
        public void RetrieveContactBelongingToCityOrState(DataTable table)
        {
            var contacts = table.AsEnumerable().Where(x => x.Field<string>("State") == "Assam");
            foreach (var contact in contacts)
            {
                Console.Write("First Name : " + contact.Field<string>("FirstName") + " " + "Last Name : " + contact.Field<string>("LastName") + " " + "Address : " + contact.Field<string>("Address") + " " + "City : " + contact.Field<string>("City") + " " + "State : " + contact.Field<string>("State")
                     + " " + "Zip : " + contact.Field<int>("Zip") + " " + "Phone Number : " + contact.Field<long>("PhoneNumber") + " " + "Email : " + contact.Field<string>("Email") + " ");
                Console.WriteLine("\n------------------------------------");
            }

        }
        public void GetSizeByCityOrState(DataTable table)
        {
            var contacts = table.Rows.Cast<DataRow>()
                             .GroupBy(x => x["State"].Equals("Assam")).Count();
            Console.WriteLine(" : {0} ", contacts);
        }
        public void SortContacts(DataTable table)
        {
            var contacts = table.Rows.Cast<DataRow>()
                           .OrderBy(x => x.Field<string>("FirstName"));
            DisplayContacts(contacts.CopyToDataTable());
        }
        public void GetCountByType(DataTable table)
        {
            var friendsContacts = table.Rows.Cast<DataRow>()
                                         .Where(x => x["AddressBookType"].Equals("Friends")).Count();
            Console.WriteLine("'Friends' : {0} ", friendsContacts);
            var familyContact = table.Rows.Cast<DataRow>()
                             .Where(x => x["AddressBookType"].Equals("Family")).Count();
            Console.WriteLine("'Family' : {0} ", familyContact);
            var ProfessionalContact = table.Rows.Cast<DataRow>()
                             .Where(x => x["AddressBookType"].Equals("Profession")).Count();
            Console.WriteLine("'Profession' : {0} ", ProfessionalContact);
        }
        public void AddPersonToFriendsAndFamily(DataTable table)
        {
            var contacts = table.Rows.Cast<DataRow>()
                            .Where(x => x["FirstName"].Equals("Rama"));

            Console.WriteLine("\nAdded New Contact in Both Family And Friends");
            DisplayContacts(contacts.CopyToDataTable());
        }
    }
}
