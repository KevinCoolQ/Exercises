using System;
using System.Linq;
using System.Collections.Generic;

// INNER JOIN

class LinqExercise15
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

		Console.WriteLine("Inner Join between two data sets");

		foreach (var item in itemlist)
		{
			Console.WriteLine("Item Id: {0}, Description: {1}", item.ItemId, item.ItemDes);
		}
		foreach (var item in purchlist)
		{
			Console.WriteLine("Invoice No: {0}, Item Id : {1},  Quantity : {2}", item.InvNo, item.ItemId, item.PurQty);
		}

		var innerJoin = from e in itemlist
						join d in purchlist on e.ItemId equals d.ItemId
						select new
						{
							itid = e.ItemId,
							itdes = e.ItemDes,
							prqty = d.PurQty
						};
		Console.WriteLine("Item ID\t\tItem Name\tPurchase Quantity" + System.Environment.NewLine);
		foreach (var data in innerJoin)
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
-------------------------------------------------------                                                       
1               Biscuit                 458                                                                   
2               Chocolate               650                                                                   
3               Butter                  800                                                                   
3               Butter                  900                                                                   
3               Butter                  900                                                                   
4               Brade                   700                                                                   
4               Brade                   650
 */
