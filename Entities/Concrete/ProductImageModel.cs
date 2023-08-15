// ImageModel.cs

using Core.Entities;

public class ProductImageModel : IEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string ContentType { get; set; }
    public byte[] Data { get; set; }
    public bool IsMain { get; set; }

}
