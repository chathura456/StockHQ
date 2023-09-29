using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorHQ.Models
{
    public class Item
    {
        public int StockID { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }

        public string Transaction { get; set; }

        // Constructor
        public Item() { }

        public Item(int stockID, string itemName, int quantity, DateTime dateAdded, string transaction)
        {
            StockID = stockID;
            ItemName = itemName;
            Quantity = quantity;
            DateAdded = dateAdded;
            Transaction = transaction;
        }

    }

}
