using Infrastructure.Persistence.Entities;
using System.Linq.Expressions;

namespace Domain.RepositoryPattern
{

    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public List<TEntity> items;
        private DateTime dateCreatedOn;
        private DateTime lastUpdatedOn;

        public BaseRepository()
        {
            this.items = new List<TEntity>();
            this.dateCreatedOn = DateTime.Now;
        }

        public void Add(TEntity item)
        {
            items.Add(item);    
            lastUpdatedOn = DateTime.Now;
        }

        public void Delete(Guid id)
        {
            items.Remove(GetById(id));
            lastUpdatedOn = DateTime.Now;
        }

        public List<TEntity> GetAll()
        {
            return items;
        }

        public TEntity GetById(Guid id)
        {
            return items.Where(x => x.Id == id).FirstOrDefault();
            
        }

        public void Update(TEntity item)
        {
           for(int i = 0; i < items.Count; i++)
            {
                if(items[i].Id == item.Id)
                {
                    items[i] = item;
                    break;
                }
            }

            lastUpdatedOn = DateTime.Now;
        }

        public DateTime DateCreatedOn()
        {
            return this.dateCreatedOn;
        }

        public DateTime LastUpdateOn()
        {
            return this.lastUpdatedOn;
        }
    }
}
