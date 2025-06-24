namespace backend.Dtos;

public class CreateTransactionDto
{
    public string Title { get; set; } = string.Empty;
    public double Price { get; set; }
    public int CategoryId { get; set; }
}
