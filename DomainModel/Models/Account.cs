namespace DomainModel.Models;
public class Account
{
    public int Id { get; set; }
    public string? Login {  get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? BusinessName { get; set; }
    public string? StreetAdress { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? ContactName { get; set; }
    public string? PhoneNumber { get; set; }


    public Account(int id, string businessName, string streetAddress, string city,
        string state, string zipCode, string contactName, string email, string phone) 
    {
        Id = id;
        BusinessName = businessName;
        StreetAdress = streetAddress;
        City = city;
        State = state;
        ZipCode = zipCode;
        ContactName = contactName;
        Email = email;
        PhoneNumber = phone;
    }
    public Account(string login, string password, string contactName, string email)
    {
        Login = login;
        Password = password;
        Email = email;
        ContactName = contactName;
    }
    public Account(int id, string login, string password, string contactName, string email)
    {
        Id = id;
        Login = login;
        Password = password;
        Email = email;
        ContactName = contactName;
    }

    public Account() { }


}
