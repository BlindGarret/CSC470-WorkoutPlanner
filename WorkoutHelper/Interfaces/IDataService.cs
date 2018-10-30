using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WorkoutHelper.Interfaces
{
    /// <summary>
    /// Data access service interface.
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// Insert a data <see cref="TObj"/> into storage
        /// </summary>
        /// <typeparam name="TObj">Type of Object to insert</typeparam>
        /// <param name="obj">Object to insert</param>
        /// <returns>Asynchronous Task<see cref="Task"/></returns>
        Task Insert<TObj>(TObj obj);

        /// <summary>
        /// Inserts a set of data <see cref="TObj"/>s into storage
        /// </summary>
        /// <typeparam name="TObj">Type of Object to insert</typeparam>
        /// <param name="objs">Collection of objects to insert</param>
        /// <returns>Asynchronous Task<see cref="Task"/></returns>
        Task InsertSet<TObj>(IEnumerable<TObj> objs);

        /// <summary>
        /// Updates an already created <see cref="TObj"/> in storage
        /// </summary>
        /// <typeparam name="TObj">Type of Object to insert</typeparam>
        /// <param name="obj">Object to update</param>
        /// <returns>Asynchronous Task<see cref="Task"/></returns>
        Task Update<TObj>(TObj obj);

        /// <summary>
        /// Updates a set of already created <see cref="TObj"/>s in storage 
        /// </summary>
        /// <typeparam name="TObj">Type of Object to insert</typeparam>
        /// <param name="objs">Objects to update</param>
        /// <returns>Asynchronous Task<see cref="Task"/></returns>
        Task UpdateSet<TObj>(IEnumerable<TObj> objs);

        /// <summary>
        /// Gets a set of <see cref="TObj"/> from storage
        /// </summary>
        /// <typeparam name="TObj">Type of Object to insert</typeparam>
        /// <typeparam name="TOrderable">Type of the parameter to sort by</typeparam>
        /// <param name="filter">Optional expression for filtering the storage output</param>
        /// <param name="orderBy">Optional expression for ordering the storage output</param>
        /// <returns>Set of <see cref="TObj"/> from storage</returns>
        Task<IEnumerable<TObj>> Get<TObj, TOrderable>(Expression<Func<bool>> filter = null, Expression<Func<TObj, TOrderable>> orderBy = null);

        /// <summary>
        /// Gets a set of <see cref="TObj"/> from storage
        /// </summary>
        /// <typeparam name="TObj">Type of Object to insert</typeparam>
        /// <param name="filter">Optional expression for filtering the storage output</param>
        /// <returns>Set of <see cref="TObj"/> from storage</returns>
        Task<IEnumerable<TObj>> Get<TObj>(Expression<Func<bool>> filter = null);

        /// <summary>
        /// Gets a single <see cref="TObj"/> from storage, throwing an exception if it does not exist.
        /// </summary>
        /// <typeparam name="TObj">Type of Object to insert</typeparam>
        /// <param name="filter">Optional expression for filtering the storage output</param>
        /// <returns>An instance of <see cref="TObj"/></returns>
        Task<TObj> First<TObj>(Expression<Func<bool>> filter = null);

        /// <summary>
        /// Gets a single <see cref="TObj"/> from storage, returning <see cref="TObj"/>'s default value if it doesn't exist..
        /// </summary>
        /// <typeparam name="TObj">Type of Object to insert</typeparam>
        /// <param name="filter">Optional expression for filtering the storage output</param>
        /// <returns>An instance of <see cref="TObj"/></returns>
        Task<TObj> FirstOrDefault<TObj>(Expression<Func<bool>> filter = null);

        /// <summary>
        /// Gets a count of <see cref="TObj"/> in storage, with optional predicate.
        /// </summary>
        /// <typeparam name="TObj">Type of Object to insert</typeparam>
        /// <param name="predicate">Predicate for counting as an expression</param>
        /// <returns>Count of <see cref="TObj"/></returns>
        Task<int> Count<TObj>(Expression<Func<bool>> predicate = null);
        
        /// <summary>
        /// Gets a count of <see cref="TObj"/> in storage, with optional predicate.
        /// </summary>
        /// <typeparam name="TObj">Type of Object to insert</typeparam>
        /// <param name="predicate">Predicate for counting as an expression</param>
        /// <returns>Count of <see cref="TObj"/></returns>
        Task<int> Delete<TObj>(Expression<Func<bool>> predicate = null);

        /// <summary>
        /// Runs an action in a transaction, setting up a save point and rolling back if an exception occurs.
        /// </summary>
        /// <param name="lambda">Action to run in a transaction.</param>
        /// <returns>Asynchronous Task<see cref="Task"/></returns>
        Task RunInTransaction(Action lambda);
    }
}