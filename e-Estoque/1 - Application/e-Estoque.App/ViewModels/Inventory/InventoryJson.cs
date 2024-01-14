namespace e_Estoque.App.ViewModels.Inventory
{
    public class InventoryJson
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public Guid IdProduct { get; set; }
        public string NameProduct { get; set; } = string.Empty;

        public InventoryJson()
        {
        }

        public InventoryJson(Guid id, int quantity, Guid idProduct, string nameProduct)
        {
            Id = id;
            Quantity = quantity;
            IdProduct = idProduct;
            NameProduct = nameProduct;
        }
    }
}
