using System;
using System.Collections.Generic;
using System.Text;

namespace GroupData.Models{
    
    public class Product_Info{
        public int Id{get;set;}
        public int group_Id{get;set;}
        public string name{get;set;}
        public string description{get;set;}

        public int rate{get;set;}

    }
}