﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseIO
{

    public class PostDao
    {
        MyDB mydb = new MyDB();

        public post getDetailPromotion(string id)
        {
            int promotionId = Int32.Parse(id);
            return mydb.posts.Where(p => p.id == promotionId).FirstOrDefault();
        }
        public room getName(int id)
        {
            return mydb.rooms.Where(r => r.id == id).FirstOrDefault();
        }
        public List<post> getAll()
        {
            return mydb.posts.ToList();
        }
        public void Add(string title, string idcate, string image, string description)
        {
            string SQL = "INSERT INTO post(title, description, image, id_cpost) VALUES('" + title + "','" + description + "','" + image + "','" + idcate + "')";
            mydb.Database.ExecuteSqlCommand(SQL);

        }
        public void Update(string title, string idcate, string image, string description, string id)
        {
            string SQL = "UPDATE post SET title = '" + title + "',description = '" + description + "',image = '" + image + "',id_cpost = '" + idcate + "' WHERE id = '" + id + "'";
            mydb.Database.ExecuteSqlCommand(SQL);
        }
        public void Delete(string id)
        {
            string SQL = "DELETE FROM post WHERE id = '" + id + "'";
            mydb.Database.ExecuteSqlCommand(SQL);
        }
    }
}
