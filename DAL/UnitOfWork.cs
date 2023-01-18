using GameDataApp.Data;
using GameDataApp.Models;

namespace GameDataApp.DAL
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly GameDataAppContext _gameDataAppContext;
        private IInventoryRepository _inventoryRepository;
        private IItemRepository _itemRepository;
        private IPlayerRepository _playerRepository;
        private IQuestRepository _questRepository;

        private bool _disposed = false;

        public UnitOfWork(GameDataAppContext GameDataAppContext)
        {
            _gameDataAppContext = GameDataAppContext;
        }

        public IInventoryRepository InventoryRepository
        {
            get
            {
                if (_inventoryRepository == null)
                {
                    _inventoryRepository = new InventoryRepository(_gameDataAppContext);
                }

                return _inventoryRepository;
            }
        }

        public IItemRepository ItemRepository
        {
            get
            {
                if (_itemRepository == null)
                {
                    _itemRepository = new ItemRepository(_gameDataAppContext);
                }

                return _itemRepository;
            }
        }

        public IPlayerRepository PlayerRepository
        {
            get
            {
                if (_playerRepository == null)
                {
                    _playerRepository = new PlayerRepository(_gameDataAppContext);
                }

                return _playerRepository;
            }
        }

        public IQuestRepository QuestRepository
        {
            get
            {
                if (_questRepository == null)
                {
                    _questRepository = new QuestRepository(_gameDataAppContext);
                }

                return _questRepository;
            }
        }

        public async Task Save()
        {
            await _gameDataAppContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _gameDataAppContext.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}