using EF_Urok.Model;
using System;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }
    public string Role { get; set; }

    public List<Borrowin> Borowins { get; set; } = new ();


}