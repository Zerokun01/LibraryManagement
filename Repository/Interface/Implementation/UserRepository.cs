using System;
using LibraryManagement.Entities;
using LibraryManagement.UserRepository.Interface;

namespace LibraryManagement.Repository.Implementation;

public class UserRepository : IUserRepository
{
    private List<User> Users = [];
    public User AddUser(User? user)
    {
        if (user == null)
        {
            throw new Exception("No user found");
        }
        Users.Add(user);
        return user;
    }

    public void DeleteUser(Guid? userid)
    {
        if (userid.ToString() == null)
        {
            throw new Exception("No user found");
        }

        var deleteUser = Users.Remove(Users.First(u => u.UserId == userid));
        
    }

    public User? GetUser(Guid userId)
    {
        if (userId.ToString() == null)
        {
            throw new Exception("No id  provided");
        }
        var user = Users.Find(u => u.UserId == userId);
        return user;
    }

    public User UpdateUser(Guid userid, User updatedUser)
    {
        if (string.IsNullOrEmpty(userid.ToString()) || updatedUser == null)
        {
            throw new Exception("No user id or null updated for user");
        }
        var user = GetUser(userid);
        var index = Users.FindIndex(u => u.UserId == userid);
        
        if (user == null || index < 0)
        {
            throw new Exception("User not found");
        }   

        user = updatedUser;
        Users[index] = user;
        return user;
    }
}
