using System;

public class Ticket {
	private TicketStatus status = TicketStatus.UNSENT;
	private int id;
	private string title;
	private string content;

	private Customer reclaimer;

    public Ticket( int id, string title, string content, Customer reclaimer)
    {
        this.Status = TicketStatus.UNSENT;
        this.Id = id;
        this.Title = title;
        this.Content = content;
        this.Reclaimer = reclaimer;
    }

    public TicketStatus Status { get => status; set => status = value; }
    public int Id { get => id; set => id = value; }
    public string Title { get => title; set => title = value; }
    public string Content { get => content; set => content = value; }
    public Customer Reclaimer { get => reclaimer; set => reclaimer = value; }
}
