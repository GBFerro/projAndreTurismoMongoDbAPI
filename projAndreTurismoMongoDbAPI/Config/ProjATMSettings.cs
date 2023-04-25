namespace projAndreTurismoMongoDbAPI.Config
{
    public class ProjATMSettings : IProjATMSettings
    { 
        public string CustomerCollectionName { get; set; }
        public string AddressCollectionName { get; set; }
        public string CityCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
