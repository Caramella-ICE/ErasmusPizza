using System;
using System.Drawing;

public class Payment {
	private float amount = 0f;
	private bool isPaid;

	private Order order;

    public Payment(float amount, Order order)
    {
        Amount = amount;
        IsPaid = false;
		Order = order;
    }

    public float Amount { get => amount; set => amount = value; }
    public bool IsPaid { get => isPaid; set => isPaid = value; }
    public Order Order { get => order; set => order = value; }

    public void SendReception() {
		
		this.order.Status = OrderStatus.IN_PREPARATION;
		
	}
	public void ShowInvalidPayment() {
		
	this.order.Status = OrderStatus.CANCELED;
	

	}
	public void CheckPayment(float amount){
		if(this.amount >= amount){
			this.ShowInvalidPayment();
			isPaid = false;
		}else{
			this.SendReception();
			isPaid= true;
		}
	}

}
