using System;
using System.Data.Common;

public class OrderQuery {
	private int quantity;
	private float totalPrice ;
	private Item item;

    public OrderQuery(int quantity, Item item)
    {   
        this.quantity = quantity; 
        Item = item;
        TotalPrice = this.CalculateTotal();

    }

    public int Quantity { get => quantity; set => quantity = value; }
    public float TotalPrice { get => totalPrice; set => totalPrice = value; }
    public Item Item { get => item; set => item = value; }

    
	
	public float CalculateTotal() {
        if(this.item != null){
            
            this.totalPrice = this.item.Price * quantity;
            return(this.item.Price * quantity);
        }else{
            this.totalPrice = 0f;
            return(0f);
        }
		
	}


}
