using System;

public class Order {
	private DateTime date;
	private OrderStatus status = OrderStatus.UNPAID;
	private int id;

	private Customer customer;


	private DeliveryInfo deliveryInfo;

	private Cart cart;

    static string getEnv(string value){
    return Environment.GetEnvironmentVariable(value);
    }
	public float CalculateTotal() {
        float reduction = 1f;
        if (this.customer.IsErasmus){
            reduction = (float)Convert.ToDecimal(getEnv("ERASMUS_REDUCTION"), System.Globalization.CultureInfo.GetCultureInfo("en-US"));
        }
		return this.cart.Total *reduction*(float)Convert.ToDecimal(getEnv("TAX_REDUCTION"), System.Globalization.CultureInfo.GetCultureInfo("en-US"));
	}
	public void SendConfirmation() {
		throw new System.NotImplementedException("Not implemented");
	}

	

    public Order( int id, DeliveryInfo deliveryInfo,Cart cart, Customer customer)
    {
        Status = OrderStatus.UNPAID;
        Id = id;
        DeliveryInfo = deliveryInfo;
        Cart = cart;
        Customer = customer;
        Date = DateTime.Today;

    }

    public DateTime Date { get => date; set => date = value; }
    public OrderStatus Status { get => status; set => status = value; }
    public int Id { get => id; set => id = value; }
    public DeliveryInfo DeliveryInfo { get => deliveryInfo; set => deliveryInfo = value; }
    public Cart Cart { get => cart; set => cart = value; }
    public Customer Customer { get => customer; set => customer = value; }
}
