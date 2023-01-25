using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

public class Cart {
	private float total = 0f;
	private bool isDeliverable;
	private OrderQuery[] itemsQueries;

	

    public OrderQuery[] ItemsQueries { get => itemsQueries; set => itemsQueries = value; }
    public float Total { get => total; set => total = value; }
    public bool IsDeliverable { get => isDeliverable; set => isDeliverable = value; }

    public Cart()
    {
		IsDeliverable = true;
		itemsQueries = Array.Empty<OrderQuery>();
		Total = this.CalculateTotal();

    }

	public float CalculateTotal() {
		float total = 0f;
		if(ItemsQueries?.Length != null){
			foreach(OrderQuery itemquery in ItemsQueries){
			total += itemquery.TotalPrice;
		}
		}
		this.Total = total;
		return total;
	}

	public void ChangeQuantity(int id,  int quantity) {
		if (quantity ==0){
			this.RemoveItem(id);
		}else{
			OrderQuery itemquery = itemsQueries.First(itemquery => itemquery.Item.Id == id);
			itemquery.Quantity = quantity;
			itemquery.CalculateTotal();
			this.CalculateTotal();
		}
	}
	public void RemoveItem(int id) {
		if(Array.Exists(this.itemsQueries,  itemquery => itemquery.Item?.Id == id )){
			itemsQueries = itemsQueries.Where(itemquery => itemquery.Item.Id != id).ToArray();
		}else{
			Console.WriteLine("ItemCart with id: "+id+" is not in the cart !");
		}
		this.CalculateTotal();
	}
}
