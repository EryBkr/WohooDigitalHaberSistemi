using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WohooDigitalProject.Core.Entities;

namespace WohooDigitalProject.News.Entities.Concrete
{
    public class Haber: IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int OrderNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
