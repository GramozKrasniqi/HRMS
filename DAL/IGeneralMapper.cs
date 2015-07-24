using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public interface IGeneralMapper<TEntity, TView>
    {
        void Insert(TEntity t);
        void Update(TEntity t);
        void Delete(TEntity t);
        TView Get(TEntity t);

        /// <summary>
        /// This must return all entities with statueses as active, pasive and not defined
        /// Every other List function must return only active entities
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        List<TView> List(string search);
    }
}
