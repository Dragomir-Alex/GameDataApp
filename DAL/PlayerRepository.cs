using GameDataApp.Data;
using GameDataApp.Models;

namespace GameDataApp.DAL
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(GameDataAppContext gameDataAppContext) : base(gameDataAppContext)
        { }
    }
}
