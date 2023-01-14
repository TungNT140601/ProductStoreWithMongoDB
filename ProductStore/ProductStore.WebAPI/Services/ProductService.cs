using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductStore.WebAPI.Models;

namespace ProductStore.WebAPI.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<ProductEntity> _productCollection;

        public ProductService(IOptions<ProductStoreDatabaseSetting> productStoreDatabaseSetting)
        {
            var mongoClient = new MongoClient(productStoreDatabaseSetting.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(productStoreDatabaseSetting.Value.DatabaseName);

            _productCollection = mongoDatabase.GetCollection<ProductEntity>(productStoreDatabaseSetting.Value.ProductCollectionName);
        }

        public async Task<List<ProductEntity>> GetProductsAsync() => await _productCollection.Find(_ => true).ToListAsync();

        public async Task<ProductEntity?> GetProductAsync(string id) => await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task Create(ProductEntity product) => await _productCollection.InsertOneAsync(product);

        public async Task Update(string id,ProductEntity product) => await _productCollection.ReplaceOneAsync(x => x.Id == id, product);

        public async Task Delete(string id) => await _productCollection.DeleteOneAsync(x => x.Id == id);
    }
}
