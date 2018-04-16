using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;

public class DataBaseHelper {

    private northwindEntities dataBase;

    public List<Category> CategoryList {
        get {
            return dataBase.Categories.ToList<Category>();
        }
    }

    public DataBaseHelper() {
        dataBase = new northwindEntities();
    }

    public void InsertNewItem(OrderedDictionary newValues) {
        Category category = new Category();
        LoadNewValues(category, newValues);
        dataBase.Categories.Add(category);
        dataBase.SaveChanges();
    }
    public void UpdateItem(OrderedDictionary keys, OrderedDictionary newValues) {
        int id = Convert.ToInt32(keys["CategoryID"]);
        Category category = dataBase.Categories.Where(x => x.CategoryID == id).FirstOrDefault<Category>();
        LoadNewValues(category, newValues);
        dataBase.SaveChanges();
    }
    public void DeleteItem(OrderedDictionary keys, OrderedDictionary values) {
        int id = Convert.ToInt32(keys["CategoryID"]);
        Category category = dataBase.Categories.Where(x => x.CategoryID == id).FirstOrDefault<Category>();
        dataBase.Categories.Remove(category);
        dataBase.SaveChanges();
    }
    protected void LoadNewValues(Category item, OrderedDictionary values) {
        item.CategoryName = values["CategoryName"].ToString();
        item.Description = values["Description"].ToString();
    }
}