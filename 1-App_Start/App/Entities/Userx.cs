﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities
{


    public class Userx
    {
        public int UserxID { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }

    }


}



/*
 
 
 
  //[Table("Userxes")]
    public class Userx
    {

        //[Key] 
        public int UserxID { get; set; }

        //[Column("Name", TypeName = "varchar(50)")]
        public string Name { get; set; }

    }
 
 
 
 
 */