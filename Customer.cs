using System;
using System.Globalization;
using System.Net;
using System.Runtime.InteropServices;

public class Customer : User  {
	
	private bool isErasmus;

	private DeliveryInfo[] deliveryInfos;
	private Cart cart;

	private float wallet;
	private Order[] order;
	private Ticket[] ticket;

    public DeliveryInfo[] DeliveryInfos { get => DeliveryInfos; set => DeliveryInfos = value; }

    public Cart Cart { get => cart; set => cart = value; }

	public float Wallet { get => wallet; set => wallet = value;}
    public Order[] Orders { get => order; set => order = value; }
    public Ticket[] Tickets { get => ticket; set => ticket = value; }
    public bool IsErasmus { get => isErasmus; set => isErasmus = value; }


    public Customer(int id,bool isErasmus, string city, string adress,float wallet)
    {
		this.IsErasmus = isErasmus;
		this.Id = id;
		this.Orders = Array.Empty<Order>();
		this.Tickets = Array.Empty<Ticket>();
		this.deliveryInfos = new DeliveryInfo[] { new DeliveryInfo(city,adress) };
		this.Cart = new Cart();
		this.wallet = wallet;


    }

	public void AddItem(Item item, int quantity) {
		OrderQuery orderquery = new OrderQuery(quantity,item);
       	Cart.ItemsQueries = Cart.ItemsQueries.Append(orderquery).ToArray();
		Cart.CalculateTotal();
	}
	public Order PlaceOrder(int id){
		Order Neworder = new Order(id,this.deliveryInfos[0],this.cart,this);
		Orders = Orders.Append(Neworder).ToArray();
		return Neworder;
	}
	public void AddDeliveryInfo(DeliveryInfo newdelivery) {
		DeliveryInfos = this.deliveryInfos.Append<DeliveryInfo>(newdelivery).ToArray();
	}
	public Ticket CreateTicket(int id,string title, string content) {
        Ticket ticket =  new Ticket(id, title, content, this);
		Tickets = this.Tickets.Append<Ticket>(ticket).ToArray();
		return ticket;
	}

    

    public void Pay(Order order) {

		Payment payment = new Payment(order.CalculateTotal(),order);
		payment.CheckPayment(this.wallet);
		if(payment.IsPaid){
			this.cart = new Cart();
		}
		
	}
	public void RemoveItem(int id) {
			this.cart.RemoveItem(id);
	}
}
