namespace DomainModel.Models;

public class Client
{
	public int Id { get; set; }
	public string CompanyName { get; set; }
	public string CompanyAddress { get; set; }
	public string CompanyNip { get; set; }
	public string SellerId { get; set; }

	public Client(string name, string address, string nip, string sellerId)
	{
		CompanyName = name;
		CompanyAddress = address;
		CompanyNip = nip;
		SellerId = sellerId;
	}

	public Client() { }

	public override string ToString()
	{
		return CompanyName;
	}
}
