public class CampingSpot
{
    public int Id { get; set; }
    public required string SpotName { get; set; }
    public int Size { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public int OwnerId { get; set; }
    public int CampingGroundId { get; set; }
}