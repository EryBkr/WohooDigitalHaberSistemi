using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WohooDigitalProject.Core.DataAccess
{
   public class SingletonRepository<TContext> where TContext:class,new()
    {
        private static TContext _dB;
        protected SingletonRepository()
        {

        }

        public static TContext CreateDatabase()
        {
            if (_dB==null)
            {
                _dB = new TContext();
            }
            return _dB;
        }
    }
}
