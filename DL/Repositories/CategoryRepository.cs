﻿using Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DL.Repositories
{
    public class CategoryRepository : IRepository<Category>

    {
        public List<Category> categoryList;
        public CategoryDataManager categoryDataManager;

        public CategoryRepository()
        {
            categoryDataManager = new CategoryDataManager();
            categoryList = GetAll();
        }

        public void Create(Category category)
        {
            categoryList.Add(category);
            saveChanges();
        }

        public void Update(string currentName, string newName)
        {
            foreach (var category in categoryList.Where(c => c.Name == currentName))
            {
                category.Name = newName;
            }

            saveChanges();
        }

        public void Delete(string categoryName)
        {
            categoryList.RemoveAll((c) => c.Name == categoryName);
            saveChanges();
        }

        public List<Category> GetAll()
        {
            return categoryDataManager.Deserialize();
        }

        public void saveChanges()
        {
            categoryDataManager.Serialize(categoryList);
        }
    }
}