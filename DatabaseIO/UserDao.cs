﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseIO
{
    public class UserDao
    {
        MyDB mydb = new MyDB();
        
        public usercgv getInformation(string email)
        {
            return mydb.usercgvs.Where(u => u.email == email).FirstOrDefault();
        }
        public usercgv getUpdateProfile(string email, string password)
        {
            return mydb.usercgvs.Where(u => u.email == email && u.password == password).FirstOrDefault();
        }
        public void updatePassword(string email, string password,string passwordNew)
        {
            usercgv u = getUpdateProfile(email, password);
            u.password = passwordNew;
            mydb.SaveChanges();
        }
        public void activeAccount(string email)
        {
            usercgv u = getInformation(email);
            u.is_active = 1;
            mydb.SaveChanges();
        }
        public void updateProfile(string email, usercgv user)
        {
            usercgv usercgv = getInformation(email);
            usercgv.phonenumber = user.phonenumber;
            usercgv.username = user.username;
            mydb.SaveChanges();
        }
        public List<usercgv> getAll()
        {
            return mydb.usercgvs.ToList();
        }
        public void Add(string email, string password, string phonenumber, string role_id, string username)
        {
            string SQL = "INSERT INTO usercgv(email,is_active,password,phonenumber,role_id,username) VALUES('" + email + "',0,'" + password + "','" + phonenumber + "','" + role_id + "','" + username + "')";
            mydb.Database.ExecuteSqlCommand(SQL);

        }
        public void Update(string email, string password, string phonenumber, string role_id, string username, string id)
        {
            string SQL = "UPDATE usercgv SET email = '" + email + "',password = '" + password + "', phonenumber = '" + phonenumber + "', role_id = '" + role_id + "', username = '" + username + "' WHERE id = '" + id + "'";
            mydb.Database.ExecuteSqlCommand(SQL);
        }
        public void Delete(int id)
        {
            string SQL = "DELETE FROM usercgv WHERE id = '" + id + "'";
            mydb.Database.ExecuteSqlCommand(SQL);
        }
        public void ChangStatus(int id)
        {
            var user = mydb.usercgvs.Where((u) => u.id == id).FirstOrDefault();
            user.is_active = user.is_active == 1 ? user.is_active = 0 : user.is_active = 1;
            mydb.SaveChanges();


        }
    }
}
