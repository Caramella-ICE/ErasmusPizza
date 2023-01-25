using System;

public class Staff : User  {
	protected string[] credentials;

	static string getEnv(string value){
    return Environment.GetEnvironmentVariable(value);
    }

	public void ConfirmOrder(Order order) {
		this.orders.Append(order);
		order.Status = OrderStatus.SENT;
		order.Status = OrderStatus.DELIVERED;
		var t = Task.Run(async delegate
				{
					await Task.Delay((int)Convert.ToInt32(getEnv("WAITING"), System.Globalization.CultureInfo.GetCultureInfo("en-US")));
					return 42;
				});
		t.Wait();
		order.Status = OrderStatus.CLOSED;
		
			
	}
	public void CheckTicket(Ticket ticket) {
		ticket.Status = TicketStatus.OPENED;
		tickets = tickets.Append(ticket).ToArray();
	 	ticket.Status = TicketStatus.UNDER_REVIEW;
		var t = Task.Run(async delegate
				{
					await Task.Delay((int)Convert.ToInt32(getEnv("WAITING"), System.Globalization.CultureInfo.GetCultureInfo("en-US")));
					return 42;
				});
		t.Wait();
		CloseTicket(ticket);
	}

	public void CloseTicket(Ticket ticket){
		ticket.Status = TicketStatus.CLOSED;		
	}
	
	public void CancelOrder(Order order) {
		order.Status = OrderStatus.CANCELED;
	}
	public void CheckOrder(Order order){
		switch(order.Status){
			case OrderStatus.IN_PREPARATION:
				ConfirmOrder(order);
				break;
			case OrderStatus.CANCELED:
				order.Status = OrderStatus.CLOSED;
				break;	
		}
	}

	private Order[] orders;
	private Ticket[] tickets;

    public Staff(int id,string[] credentials)
    {
		this.id = id;
        this.credentials = credentials;
        this.orders = Array.Empty<Order>();
		this.tickets = Array.Empty<Ticket>();
    }
}
