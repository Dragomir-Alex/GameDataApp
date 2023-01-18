using GameDataApp.Data;
using GameDataApp.Models;

namespace GameDataApp.DAL
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(GameDataAppContext gameDataAppContext) : base(gameDataAppContext)
        { }
    }
}
