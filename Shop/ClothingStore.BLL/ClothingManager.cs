using ClothingStore.DAL;

namespace ClothingStore.BLL
{
    public class ClothingManager
    {
        private readonly ClothingRepository _repository;

        public ClothingManager()
        {
            _repository = new ClothingRepository();
        }

        public void AddNewItem(string name, string category, decimal price)
        {
            var newItem = new ClothingItem
            {
                Name = name,
                Category = category,
                Price = price
            };

            _repository.AddClothingItem(newItem);
        }

        public void RemoveItem(int id)
        {
            _repository.RemoveClothingItem(id);
        }
    }
}
