﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WohooDigitalProject.Core.Entities;

namespace WohooDigitalProject.News.Entities.Concrete
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
    }
}
