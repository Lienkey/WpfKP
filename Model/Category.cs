using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfKP.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Discription { get; set; }

        public Category() { }

        public Category(int categoryId, string categoryName, string discription)
        {
            this.CategoryId = categoryId;
            this.CategoryName = categoryName;
            this.Discription = discription;
        }

        public Category ShallowCopy()
        {
            return (Category)this.MemberwiseClone();
        }

    }
}
