﻿
using ESDomain.SeedWork;

namespace ESDomain.AggregateModels.UserDetailsAggregate
{
    public class UserDetail : IAggregateRoot
    {  
        public Int64 userid { get; set; }
        public string username { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string password { get; set; }  
        public string email { get; set; }
        public string mobile { get; set; } 
        public int action { get; set; } 
        public int isactive { get; set; } 
        public Int16 type { get; set; }
        public Int64 businessid { get; set; }
        public string comment { get; set; }

        public Int16 isquiz { get; set; }

    }
} 