using GameDataApp.Data;
using GameDataApp.Models;

namespace GameDataApp.DAL
{
    public class InventoryRepository : GenericRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(GameDataAppContext gameDataAppContext) : base(gameDataAppContext)
        { }
    }
}
