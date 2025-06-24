using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace backend.Models;

public class Transaction
{

  public int Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public double Price { get; set; } = 0;


     public int CategoryId { get; set; }

    public Category? Category { get; set; }
}
