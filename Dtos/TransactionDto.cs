using System;

namespace backend.Dtos;

public class TransactionDto
{

  public int Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public double Price { get; set; } = 0;
   public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
}
