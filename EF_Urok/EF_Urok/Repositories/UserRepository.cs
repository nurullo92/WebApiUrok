using EF_Urok.Data;
using System;


public class UserRepository
{
    private readonly AppDbContext db;

    public UserRepository(AppDbContext db)
    {
        this.db = db;
    }

    public User GetById(int id)
    {
        return db.Users.Find(id);
    }

    public List<User> GetAll()
    {
        return db.Users.ToList();
    }

    public void Add(User user)
    {
        db.Users.Add(user);
        db.SaveChanges();
    }

    public void Delete(int id)
    {
        var user = db.Users.Find(id);
        if (user == null) return;

        db.Users.Remove(user);
        db.SaveChanges();
    }

    public void Update(User user)
    {
        var existing = db.Users.Find(user.Id);
        if (existing == null) return;

        existing.Name = user.Name;
        existing.Email = user.Email;

        db.SaveChanges();
    }
}