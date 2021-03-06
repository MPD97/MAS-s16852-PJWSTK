﻿using MP03.Functional;
using System;
using System.IO;

namespace MP03
{
    public class User : ObjectPlusPlus                                       // Klasa abstrakcyjna
    {
        protected internal User() : base()
        {

        }
        public User(Association<User, UserAdministrator> roleNameAdministrator, Association<User, NormalUser> roleNameNormalUser) : base()
        {
            NormalUser user = GetNormalUser(roleNameNormalUser);
            if (user != null)
            {
                RemoveNormalUser(user, roleNameNormalUser);
            }

            AddAdministrator(user, roleNameAdministrator);
        }

        public User(Association<User,NormalUser> roleNameNormalUser, Association<User, UserAdministrator> roleNameAdministrator) : base()
        {
            UserAdministrator admin = GetAdministrator(roleNameAdministrator);
            if (admin != null)
            {
                RemoveAdministrator(admin, roleNameAdministrator);
            }

            AddNormalUser(admin, roleNameNormalUser);
        }
        public void ChangeClassTo<T>(T destination, Association<User, UserAdministrator> roleNameAdministrator, Association<User, NormalUser> roleNameNormalUser) where T : User
        {
            if (destination.GetType() == this.GetType())
            {
                throw new Exception("Nie mozna zmienic klasy na ta samą klase");
            }

            if (destination is UserAdministrator)
            {
                NormalUser user = GetNormalUser(roleNameNormalUser);
                if (user != null)
                {
                    RemoveNormalUser(user, roleNameNormalUser);
                }

                AddAdministrator(user, roleNameAdministrator);
            }
            else if (destination is NormalUser)
            {
                UserAdministrator admin = GetAdministrator(roleNameAdministrator);
                if (admin != null)
                {
                    RemoveAdministrator(admin, roleNameAdministrator);
                }

                AddNormalUser(admin, roleNameNormalUser);
            }
            else
            {
                throw new NotImplementedException($"Zmiana klasy nie została zaimplementowana dla typu: {destination.GetType().Name}");
            }
        }

        private void AddAdministrator(NormalUser user, IAssociation roleName)
        {
            if (roleName == null)
            {
                throw new Exception("Asocjacja nie moze byc null.");
            }

            AddPart(roleName, new UserAdministrator(user));
        }
        private void AddNormalUser(UserAdministrator admin, IAssociation roleName)
        {
            if (roleName == null)
            {
                throw new Exception("Asocjacja nie moze byc null.");
            }

            AddPart(roleName, new NormalUser(admin));
        }

        private void RemoveAdministrator(UserAdministrator user, IAssociation roleName)
        {
            if (roleName == null)
            {
                throw new Exception("Asocjacja nie moze byc null.");
            }
            RemovePart(roleName, user);
        }
        private void RemoveNormalUser(NormalUser user, IAssociation roleName)
        {
            if (roleName == null)
            {
                throw new Exception("Asocjacja nie moze byc null.");
            }
            RemovePart(roleName, user);
        }

        public UserAdministrator GetAdministrator(IAssociation roleName)
        {
            if (roleName == null)
            {
                throw new Exception("Asocjacja nie moze byc null.");
            }

            try
            {
                ObjectPlusPlus[] obj = GetLinks(roleName);
                if (obj.Length != 1 || obj[0] is UserAdministrator == false)
                {
                    return null;
                }

                return (obj[0] as UserAdministrator);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public NormalUser GetNormalUser(IAssociation roleName)
        {
            if (roleName == null)
            {
                throw new Exception("Asocjacja nie moze byc null.");
            }

            try
            {
                ObjectPlusPlus[] obj = GetLinks(roleName);
                if (obj.Length != 1 || obj[0] is NormalUser == false)
                {
                    return null;
                }

                return (obj[0] as NormalUser);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public string HasIsUserLogged(Association<User,UserAdministrator> roleName, User user)
        {
            if (roleName == null)
            {
                throw new Exception("Asocjacja nie moze byc null.");
            }

            try
            {
                ObjectPlusPlus[] obj = GetLinks(roleName);
                if (obj.Length != 1 || obj[0] is UserAdministrator == false)
                {
                    throw new Exception("Obiekt nie jest UserAdministrator.");
                }

                return (obj[0] as UserAdministrator).IsUserLogged(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Obiekt nie jest UserAdministrator.");
            }
        }
      

        public virtual void GetUserInfo(StreamWriter streamWriter) { }       // Metoda abstrakcyjna
    }
}
