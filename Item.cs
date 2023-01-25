using System;

public class Item {
	private int id;
	private string name;
	private string description;
	private bool isAvaiable;
	private float price;


    public Item(int id, string name, string description, float price)
    {
        this.Id = id;
        this.Name = name;
        this.Description = description;
        this.Price = price;
    }

    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public string Description { get => description; set => description = value; }
    public bool IsAvaiable { get => isAvaiable; set => isAvaiable = value; }
    public float Price { get => price; set => price = value; }
}
