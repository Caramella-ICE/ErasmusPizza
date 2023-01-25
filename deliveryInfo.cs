using System;
using System.Security.Authentication;

public class DeliveryInfo {
	private String city;
	private string adress;

    public DeliveryInfo(String city, String adress)
    {
		this.City =city;
		this.Adress= adress;
    }

    public string City { get => city; set => city = value; }
    public string Adress { get => adress; set => adress = value; }
}
