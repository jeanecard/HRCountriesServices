using HRCountriesServicesSolution.Models;
using System.Collections.Generic;

namespace HRCountriesServicesSolution.Business
{
    /// <summary>
    /// Fill up a T object with Error data for Rest Response.
    /// No unit test as implementation is trivial
    /// </summary>
    /// <typeparam name="T">a IErrorDescriptionAbility and newable object</typeparam>
    public class ServiceErrorGenerator<T> where T : IErrorDescriptionAbility, new()
    {
        /// <summary>
        /// Get error response object as a list.
        /// </summary>
        /// <param name="message">Content of the error message</param>
        /// <returns>Error response object as a list</returns>
        public IEnumerable<T> GenerateErrors(string message)
        {
            T[] errors = new T[1];
            errors[0] = GenerateError(message);
            return errors;
        }

        /// <summary>
        /// Get error response object with message given.
        /// </summary>
        /// <param name="message">Content of the error message</param>
        /// <returns>Error response object</returns>
        public T GenerateError(string message)
        {
            T error = new T();
            error.errorDescription = message;
            return error;
        }
    }
}
