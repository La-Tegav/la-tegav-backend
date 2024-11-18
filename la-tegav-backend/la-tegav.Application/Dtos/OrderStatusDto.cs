namespace la_tegav.Application.Dtos;

public class OrderStatusDto
{
    public int TotalPending { get; set; }
    public int TotalSent { get; set; }
    public int TotalCompleted { get; set; }
    public int TotalCanceled { get; set; }
}
