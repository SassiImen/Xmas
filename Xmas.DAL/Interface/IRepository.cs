using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmas.DAL.Interface
{
    public interface IRepository <T, TKey>
        where TKey : struct
        where T: IEntity<TKey>, new()
    {
        IEnumerable<T> GetAll();
        T GetOne(TKey id);
        T Insert(T toInsert);
        bool Update(T toUpdate);
        bool Delete(TKey id);

    }
}
