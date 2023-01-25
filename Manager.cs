using System;

public class Manager : Staff  {
    public Manager(int id, string[] credentials) : base(id, credentials)
    {
		this.id =id;
		this.credentials =  credentials;
    }

    public void GetConnectedStaff() {
		
	}
	public void EditItem(Item item, float price, string title, string description ) {
		item.Description =description;
		item.Name = title;
		item.Price = price;
		
	}

}
