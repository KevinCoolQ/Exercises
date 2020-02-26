using System;
using System.Linq;
using System.Collections.Generic;

class LinqExercise19
{
    static void Main(string[] args)
    {
        Console.WriteLine("Arrange distinct elements in the list in ascending order");

        var itemlist = (from c in Item.GetItemMast()
                        select c.ItemDes)
                   .Distinct()
                   .OrderBy(x => x);

        foreach (var item in itemlist)
            Console.WriteLine(item);

        Console.ReadKey();
    }
}
class Item
{
    public int ItemId { get; set; }
    public string ItemDes { get; set; }

    public static List<Item> GetItemMast()
    {
        List<Item> itemlist = new List<Item>();
        itemlist.Add(new Item() { ItemId = 1, ItemDes = "Biscuit  " });
        itemlist.Add(new Item() { ItemId = 2, ItemDes = "Honey    " });
        itemlist.Add(new Item() { ItemId = 3, ItemDes = "Butter   " });
        itemlist.Add(new Item() { ItemId = 4, ItemDes = "Brade    " });
        itemlist.Add(new Item() { ItemId = 5, ItemDes = "Honey    " });
        itemlist.Add(new Item() { ItemId = 6, ItemDes = "Biscuit  " });
        return itemlist;
    }
}

/*
Biscuit                                                                                                       
Brade                                                                                                       
Butter                                                                                                       
Honey
*/
