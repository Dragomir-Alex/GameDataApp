namespace GameDataApp.DAL
{
    public interface IUnitOfWork
    {
        public IInventoryRepository InventoryRepository { get; }
        public IItemRepository ItemRepository { get; }
        public IPlayerRepository PlayerRepository { get; }
        public IQuestRepository QuestRepository { get; }

        public Task Save();
    }
}
