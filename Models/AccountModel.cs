using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plateful.Models;


public class AccountModel
{
    public string Username
    {
        get;
    }
    public string Password
    {
        get;
    }

    public string Email
    {
        get;
    }

    public AccountModel(string username, string password, string email)
    {
        Username = username;
        Password = password;
        Email = email;
    }
}