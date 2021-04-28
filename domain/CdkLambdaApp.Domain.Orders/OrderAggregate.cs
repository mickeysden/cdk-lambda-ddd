using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CdkLamdaApp.Domain.Orders
{
    public class OrderAggregate
    {
        public OrderAggregate(string orderNumber, IList<OrderLineItem> lineItems)
        {
            this.id = Guid.NewGuid();
            this.orderNumber = orderNumber;
            this.lineItems = lineItems;
        }

        public void AddLineItem(string itemNumber, int qty, double unitPrice)
        {
            lineItems.Add(new OrderLineItem(itemNumber, qty, unitPrice));
        }

        public Guid id { get; private set; }
        public string orderNumber { get; private set; }
        public IList<OrderLineItem> lineItems { get; private set; }
        public override string ToString()
        {
            return "\n" +
            "------{" + "\n" +
            "Order Number: " + orderNumber + "\n" +
            "Line Items :" + "\n" +
            "\t{" + "\n" +
            PrintAllLineItems() + "\n" +
            "\t}" + "\n" +
            "}";
        }

        private string PrintAllLineItems()
        {
            var sb = new StringBuilder();
            foreach (var item in lineItems)
                sb.Append(item.ToString());
            return sb.ToString();
        }
    }

    public class OrderLineItem
    {
        public OrderLineItem(string itemNumber, int qty, double unitPrice)
        {
            this.itemNumber = itemNumber;
            this.qty = qty;
            this.unitPrice = unitPrice;
        }

        public string itemNumber { get; private set; }
        public int qty { get; private set; }
        public double unitPrice { get; private set; }
        public override string ToString()
        {
            return "{" + string.Join("}\n{", this.GetType()
                                .GetProperties()
                                .Select(prop => prop.Name + " : " + prop.GetValue(this).ToString()) + "}");
        }
    }
}