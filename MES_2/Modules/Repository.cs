//  ===============================
//  AUTHOR             : Honza-Jan Tichý
//  CREATE DATE     : 2017-02-22
//  ===============================
//  Namespace        : MES_2.BL
//  Class                   : Repository.cs
//  Description         :
//  ===============================
//  Version               :
//  Revision History : 2017-02-22
//  Change History: 
// 
// ==================================

namespace MES_2.Modules
{
//    public class Repository <T> : IRepository<T,Y> where T : BaseModule
//    {
//        public T Retrieve(int p_id)
//        {
//            return null;
//        }
//
//        public IEnumerable<T> Retrieve()
//        {
//            yield break;
//        }
//
//        public void Add()
//        {
//        }
//
//        public void Add(T p_entity)
//        {
//        }
//
//        public void Delete(T p_entity)
//        {
//        }
//
//        public void Edit(T p_entity)
//        {
//        }
//
//        public bool Save(T p_entity)
//        {
//            return false;
//        }
//
//        public class Repository<T> : IRepository<T> where T : EntityBase
//        {
//            private readonly ApplicationDbContext _dbContext;
//
//            public Repository(ApplicationDbContext dbContext)
//            {
//                _dbContext = dbContext;
//            }
//
//            public virtual T GetById(int id)
//            {
//                return _dbContext.Set<T>().Find(id);
//            }
//
//            public virtual IEnumerable<T> List()
//            {
//                return _dbContext.Set<T>().AsEnumerable();
//            }
//
//            public virtual IEnumerable<T> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
//            {
//                return _dbContext.Set<T>()
//                       .Where(predicate)
//                       .AsEnumerable();
//            }
//
//            public void Insert(T entity)
//            {
//                _dbContext.Set<T>().Add(entity);
//                _dbContext.SaveChanges();
//            }
//
//            public void Update(T entity)
//            {
//                _dbContext.Entry(entity).State = EntityState.Modified;
//                _dbContext.SaveChanges();
//            }
//
//            public void Delete(T entity)
//            {
//                _dbContext.Set<T>().Remove(entity);
//                _dbContext.SaveChanges();
//            }
//        }
//    }
}