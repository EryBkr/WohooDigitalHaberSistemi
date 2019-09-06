﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WohooDigitalProject.Core.Bussiness;
using WohooDigitalProject.News.Entities.ComplexTypes;
using WohooDigitalProject.News.Entities.Concrete;

namespace WohooDigitalProject.News.Bussiness.Abstract
{
    public interface IUserService:IGenericManager<User>
    {
        UserAndRole GetByUserNameAndPassword(string userName,string password);
    }
}
