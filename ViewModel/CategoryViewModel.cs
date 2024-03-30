using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfKP.Model;

namespace WpfKP.ViewModel
{
    public class CategoryViewModel
    {
        public ObservableCollection<Category> ListCategory { get; set; } = new ObservableCollection<Category>();

        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ListCategory)
            {
                if (max < r.CategoryId)
                {
                    max = r.CategoryId;
                };
            }
            return max;
        }

        public CategoryViewModel() 
        {
            this.ListCategory.Add(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Ручной инструмент",
                    Discription = "Техническое устройство, которое предназначено для ручного применения и не приспособлено для автоматической работы."
                });
            
            this.ListCategory.Add(
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Электроинструмент",
                    Discription = "Инструмент, который приводится в действие с помощью электрического источника питания."
                });

            this.ListCategory.Add(
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Бензоинструмент",
                    Discription = "Группа инструментов, которые предусматривают наличие горюче-смазочных материалов, соответствующих типам двигателя."
                });

            this.ListCategory.Add(
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Пневмоинструмент",
                    Discription = "Устройства, работающие на сжатом воздухе ручного промышленного типа использования."
                });
        }
    }
}
