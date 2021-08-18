﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseIO
{
    public class HomeDao
    {
        MyDB mydb = new MyDB();

        public List<film> getFilmComingSoon()
        {
            return mydb.Database.SqlQuery<film>("SELECT * FROM films WHERE id NOT IN (SELECT film_id FROM schedules)").ToList();
        }
        public List<film> getFilmNowShowing()
        {
            return mydb.Database.SqlQuery<film>("SELECT a.* FROM films as a,schedules as b WHERE b.film_id = a.id AND b.dateschedule = GETDATE()").ToList();
        }
        public List<post> getPromotion()
        {
            return mydb.posts.Where(p => p.id_cpost == 1).ToList();
        }
    }
}
