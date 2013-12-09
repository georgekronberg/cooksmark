using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace cooksmark.Core.DataAccess
{
    public interface IRepository
    {
        /// <summary>
        /// Gets the entity with the provided id, or throws an exception if the entity is not found.
        /// </summary>
        /// <typeparam name="T">The type of the entity to get.</typeparam>
        /// <typeparam name="TKey">The type of the <paramref name="id"/> of the entity to get.</typeparam>
        /// <param name="id">The id of the entity to get.</param>
        /// <returns>The entity of type <typeparamref name="T"/> with the provided <paramref name="id"/>.</returns>
        /// <exception cref="ObjectNotFoundException">Thrown if an entity with the provided <paramref name="id"/> can not be found.</exception>
        /// <remarks>See <a href="http://blogs.kobo.corp/arch/2013/03/20/semantics-of-get-vs-find/">Semantics of Get vs. Find</a>.</remarks>
        T Get<T, TKey>(TKey id)

            where T : class, IEntity<TKey>;

        /// <summary>
        /// Finds the entity with the provided id.
        /// </summary>
        /// <typeparam name="T">The type of the entity to find.</typeparam>
        /// <typeparam name="TKey">The type of the <paramref name="id"/> of the entity to find.</typeparam>
        /// <param name="id">The id of the entity to find.</param>
        /// <returns>The entity of type <typeparamref name="T"/> with the provided <paramref name="id"/>, or <code>default(<typeparamref name="T"/>)</code> if the entity is not found.</returns>
        /// <remarks>See <a href="http://blogs.kobo.corp/arch/2013/03/20/semantics-of-get-vs-find/">Semantics of Get vs. Find</a>.</remarks>
        T Find<T, TKey>(TKey id)

            where T : class, IEntity<TKey>;

        T Save<T, TKey>(T entity)

            where T : class, IEntity<TKey>;

        void Delete<T, TKey>(TKey id)

            where T : class, IEntity<TKey>;

        void Delete<T, TKey>(T entity)

            where T : class, IEntity<TKey>;
    }
}
