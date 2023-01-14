using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace ProductStore.WebAPI.Models
{
    public class ProductEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string ProductName { get; set; } = null;
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
