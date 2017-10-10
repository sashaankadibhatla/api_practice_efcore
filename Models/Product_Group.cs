using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GroupData.Models{
    
    public class Product_Group{
        [Key]
        public int Id{get;set;}
        public string Name{get;set;}

    }
}