﻿namespace Udemy.RepositoryDesignPattern.Models;

public class AccountCreateModel
{
    public decimal Balance { get; set; }
    public int AccountNumber { get; set; }
    public int AppUserId { get; set; }
}
