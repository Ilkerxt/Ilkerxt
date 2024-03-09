using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DAL
{
    public class ClothingRepository
    {
        public List<ClothingItem> GetAllClothingItems()
        {
            using (var context = new ClothingStoreContext())
            {
                return context.ClothingItems.ToList();
            }
        }
        public void AddClothingItem(ClothingItem item)
        {
            using (var context = new ClothingStoreContext())
            {
                context.ClothingItems.Add(item);
                context.SaveChanges();
            }
        }

        public void RemoveClothingItem(int id)
        {
            using (var context = new ClothingStoreContext())
            {
                var item = context.ClothingItems.FirstOrDefault(c => c.Id == id);
                if (item != null)
                {
                    context.ClothingItems.Remove(item);
                    context.SaveChanges();
                }
            }
        }
    }
}
