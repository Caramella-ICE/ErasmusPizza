

using System.Runtime.Intrinsics.X86;

Console.WriteLine("Hello, World!");
Environment.SetEnvironmentVariable("TAX_REDUCTION","1.15");
Environment.SetEnvironmentVariable("ERASMUS_REDUCTION","0.75");
Environment.SetEnvironmentVariable("WAITING","4000");




//Declaring regular users
Customer regularCustomer = new Customer(1,true,"Szczecin","Ulica Chopana 61 Szczecin",50f);
Staff regularStaff = new Staff(2,new string[]{"admin","password"});
Manager regularManager = new Manager(3,new string[]{"admin","password"});

//placing order
PlacingOrder();
//Sending ticket
//SendingTicket();
//Checking staff and editing item
//EditingItems();


    

void PlacingOrder(){
    regularCustomer.AddItem(new Item(68958,"Pizza Napolitane","Pizza with not a lot of ingredients",8f),1);
    regularCustomer.AddItem(new Item(68988,"Classic Calzone","Calzone peperoni extra tomato sauce",7f),3);
    regularCustomer.Cart.ChangeQuantity(68958,2);
    Order regularOrder = regularCustomer.PlaceOrder(52);

    Console.Write("Please pay Order N° "+regularOrder.Id+" With:\nCustomer: "+regularOrder.Customer.Id+"\nDate: "+regularOrder.Date+"\nDelivered to: "+regularOrder.DeliveryInfo.Adress+" With Cart: \n");
	foreach(OrderQuery itemquery in regularOrder.Cart.ItemsQueries){
			Console.Write("\n"+itemquery.Item.Id+" | "+itemquery.Item.Description+" x"+itemquery.Quantity+" "+itemquery.TotalPrice+"$");
		}
	Console.WriteLine("\nThe bill is "+ regularOrder.CalculateTotal()+"$.");

    regularCustomer.Pay(regularOrder);

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Thank you, Your order is " + regularOrder.Status );
    Console.ForegroundColor = ConsoleColor.Blue;
	
	Console.WriteLine("Preparation Complete, Your order is SENT");
	Console.WriteLine("Your order arrived, Your order is DELIVERED\nOrder will close shortly..");
	
    regularStaff.CheckOrder(regularOrder);

    Console.WriteLine("Your order is " + regularOrder.Status );
    Console.ResetColor();
}
void SendingTicket(){
    Ticket regularTicket = regularCustomer.CreateTicket(2,"Pizza cold","\n'Hello\nMy Pizzas arrived cold after 2hours of delivery, please send refund as soon as possible.\n Thank you.\n Order n°52'\n");
    
    Console.Write("Ticket sent From customer: "+regularCustomer.Id+".\nTitle: "+regularTicket.Title);
	Console.Write("\nContent: "+regularTicket.Content);
    Console.ForegroundColor = ConsoleColor.Blue;
	Console.WriteLine("Your ticket is OPENED");
    Console.WriteLine("Your ticket is UNDER_REVIEW"+"\nPlease Wait ..");

    regularStaff.CheckTicket(regularTicket);

    Console.WriteLine("Your ticket is "+regularTicket.Status);
    Console.ResetColor();
}

void EditingItems(){
    regularManager.GetConnectedStaff();
    Console.WriteLine("Staff N°2 is connected.");
    Item regularItem =new Item(68988,"Classic Calzone","Calzone peperoni extra tomato sauce",7f);
    regularManager.EditItem(regularItem,
                            9f,
                            "Classic Calzone",
                            "Calzone extra tomato sauce with Cheese"
                            );
    Console.WriteLine("Item N°"+regularItem.Id+" has been updated as the following:\n"+"Name: "+regularItem.Name+"\nDescription; "+regularItem.Description+"\nPrice: "+regularItem.Price);
}

