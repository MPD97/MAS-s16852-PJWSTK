using System;
using System.Collections.Generic;

namespace MP01
{
    public class UserAdministratorExtent
    {
        private List<UserAdministrator> extent = new List<UserAdministrator>();
        public void AddUserAdministrator(UserAdministrator userAdministrator)
        {
            extent.Add(userAdministrator);
        }
        public void RemoveWareHouse(UserAdministrator userAdministrator)
        {
            extent.Remove(userAdministrator);
        }
        public void ShowExtent()
        {
            Console.WriteLine($"Extent of class: {typeof(UserAdministrator).Name}");

            foreach (var ex in extent)
            {
                Console.WriteLine(ex);
            }
        }
        public void AddUser()                                                           // Metoda klasowa
        {
            throw new NotImplementedException();
        }
        public void DeleteUser()
        {
            throw new NotImplementedException();                                         // Metoda klasowa
        }
    }
} 
