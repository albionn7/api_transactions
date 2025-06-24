using System;

namespace backend.Dtos;

public class UpdateTransactionDto
{
  public string Title { get; set; } = string.Empty;
    public double Price { get; set; }
    public int CategoryId { get; set; }
}
