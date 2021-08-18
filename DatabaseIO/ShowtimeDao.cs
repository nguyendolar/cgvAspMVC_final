﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseIO
{
    public class ShowtimeDao
    {
        MyDB mydb = new MyDB();
        public List<showtime> getShowtime(string id)
        {
            int scheduleId = Int32.Parse(id);
            return mydb.showtimes.Where(s => s.schedule_id == scheduleId).ToList();
        }
        public showtime getName(int id)
        {
            return mydb.showtimes.Where(s => s.id == id).FirstOrDefault();
        }
        public List<showtime> getAll()
        {
            return mydb.showtimes.ToList();
        }
        public void Add(string scheid, string start, string end)
        {
            string SQL = "INSERT INTO showtimes(schedule_id,start_time,end_time) VALUES('" + scheid + "','" + start + "','" + end + "')";
            mydb.Database.ExecuteSqlCommand(SQL);

        }
        public void Update(string start, string end, string id)
        {
            string SQL = "UPDATE showtimes SET start_time = '" + start + "', end_time = '" + end + "' WHERE id = '" + id + "'";
            mydb.Database.ExecuteSqlCommand(SQL);
        }
        public void Delete(string id)
        {
            string SQL = "DELETE FROM showtimes WHERE id = '" + id + "'";
            mydb.Database.ExecuteSqlCommand(SQL);
        }
    }
}
