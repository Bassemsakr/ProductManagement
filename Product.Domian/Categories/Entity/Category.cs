using ProductManagement.Domian.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domian.Categories.Entity
{
    public class Category : Entity<Guid>
    {
        public string Name { get; private set; }
        public int ProductCount { get; private set; }

        private Category() { }

        public Category(Guid id, string name)
        {
            Id = id;
            Name = name;
            ProductCount = 0;
        }

        public void IncrementProductCount() => ProductCount++;
        public void DecrementProductCount() => ProductCount = Math.Max(0, ProductCount - 1);

        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Category name cannot be empty");

            Name = newName;
        }

    }
}
