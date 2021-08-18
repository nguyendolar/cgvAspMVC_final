﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseIO
{
    public  class RoomDao
    {
        MyDB mydb = new MyDB();
        public List<room> getRoom()
        {
            return mydb.rooms.ToList();
        }
        public List<schedule> getSchedule()
        {
            return mydb.schedules.ToList();
        }
        public room getName(int id)
        {
            return mydb.rooms.Where(r => r.id == id).FirstOrDefault();
        }
        public List<room> getAll()
        {
            return mydb.rooms.ToList();
        }
        public void Add(string name)
        {
            string SQL = "INSERT INTO room(room_name) VALUES('" + name + "')";
            mydb.Database.ExecuteSqlCommand(SQL);

        }
        public void Update(string name, string id)
        {
            string SQL = "UPDATE room SET room_name = '" + name + "' WHERE id = '" + id + "'";
            mydb.Database.ExecuteSqlCommand(SQL);
        }
        public void Delete(string id)
        {
            string SQL = "DELETE FROM room WHERE id = '" + id + "'";
            mydb.Database.ExecuteSqlCommand(SQL);
        }
    }
}
