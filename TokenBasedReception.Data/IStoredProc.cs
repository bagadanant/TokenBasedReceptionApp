using System;
using System.Collections.Generic;
using System.Data;

namespace TokenBasedReception.Data
{
    public interface IStoredProc
    {
        /// <summary>
        /// Add parameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        void AddParameter(String name, Object value);

        /// <summary>
        /// Add parameter with direction specified
        /// </summary>
        /// <param name="name"></param>
        /// <param name="direction"></param>        
        void AddParameter(String name, ParameterDirection direction);

        /// <summary>
        /// Add parameter with user-defined table type value
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        void AddParameter(String name, Object value, String typeName);

        /// <summary>
        /// proc method returning data
        /// </summary>
        /// <param name="name">object of stroredProc class </param>
        /// <param name="param"></param>
        /// <returns></returns>
        List<T> ExecuteQuery<T>();

        List<T> ExecuteQuery<T>(out Dictionary<string, object> _dic);

        /// <summary>
        /// proc method - not returning data
        /// </summary>
        /// <param name="name">object of stroredProc class</param>
        /// <param name="param"></param>
        /// <returns></returns>
        int ExecuteNonQuery();
    }
}
