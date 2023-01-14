namespace ProductStore.WebAPI.Models
{
    public class ProductStoreDatabaseSetting
    {
        public string ConnectionString { get; set; } = null;
        public string DatabaseName { get; set; } = null;
        public string ProductCollectionName { get; set; } = null;
    }
}
