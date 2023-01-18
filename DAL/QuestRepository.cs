using GameDataApp.Data;
using GameDataApp.Models;

namespace GameDataApp.DAL
{
    public class QuestRepository : GenericRepository<Quest>, IQuestRepository
    {
        public QuestRepository(GameDataAppContext gameDataAppContext) : base(gameDataAppContext)
        { }
    }
}
