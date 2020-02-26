using System;
using System.Linq;
using System.Collections.Generic;

// LEFT JOIN

class LinqExercise16
{
    static void Main(string[] args)
    {
        var itemlist = new List<Item>
            {
           new Item { ItemId = 1, ItemDes = "Biscuit  " },
           new Item { ItemId = 2, ItemDes = "Chocolate" },
           new Item { ItemId = 3, ItemDes = "Butter   " },
           new Item { ItemId = 4, ItemDes = "Brade    " },
           new Item { ItemId = 5, ItemDes = "Honey    " }
            };

        var purchlist = new List<Purchase>
            {
           new Purchase { InvNo=100, ItemId = 3,  PurQty = 800 },
           new Purchase { InvNo=101, ItemId = 2,  PurQty = 650 },
           new Purchase { InvNo=102, ItemId = 3,  PurQty = 900 },
           new Purchase { InvNo=103, ItemId = 4,  PurQty = 700 },
           new Purchase { InvNo=104, ItemId = 3,  PurQty = 900 },
           new Purchase { InvNo=105, ItemId = 4,  PurQty = 650 },
           new Purchase { InvNo=106, ItemId = 1,  PurQty = 458 }
            };

        foreach (var item in itemlist)
        {
            Console.WriteLine("Item Id: {0}, Description: {1}", item.ItemId, item.ItemDes);
        }

        foreach (var item in purchlist)
        {
            Console.WriteLine("Invoice No: {0}, Item Id : {1},  Quantity : {2}", item.InvNo, item.ItemId, item.PurQty);
        }

        var leftOuterJoin = from itm in itemlist
                            join prch in purchlist
                            on itm.ItemId equals prch.ItemId
                            into a
                            from b in a.DefaultIfEmpty(new Purchase())
                            select new
                            {
                                itid = itm.ItemId,
                                itdes = itm.ItemDes,
                                prqty = b.PurQty
                            };

        Console.WriteLine("Item ID\t\tItem Name\tPurchase Quantity");
        foreach (var data in leftOuterJoin)
        {
            Console.WriteLine(data.itid + "\t\t" + data.itdes + "\t\t" + data.prqty);
        }
        Console.ReadKey();
    }
}
public class Item
{
    public int ItemId { get; set; }
    public string ItemDes { get; set; }
}

public class Purchase
{
    public int InvNo { get; set; }
    public int ItemId { get; set; }
    public int PurQty { get; set; }
}

/*
Item ID         Item Name       Purchase Quantity                                                             
-------------------------------------------------                                                      
1               Biscuit                 458                                                                   
2               Chocolate               650                                                                   
3               Butter                  800                                                                   
3               Butter                  900                                                                   
3               Butter                  900                                                                   
4               Brade                   700                                                                   
4               Brade                   650                                                                   
5               Honey                   0
 */
