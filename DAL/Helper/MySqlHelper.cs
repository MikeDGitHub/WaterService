using DAL.Factory;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Helper
{
    public sealed class MySqlHelper
    {
        private string _connectionStr;
        public MySqlHelper()
        {
            _connectionStr = $"Database=oauth;DataSource=39.104.164.180;UserId=root;Password=123456;CharSet=utf8;port=3306;SslMode=None";
        }
        #region +ExcuteNonQuery 增、删、改同步操作
        /// <summary>
        /// 增、删、改同步操作
        /// 
        ///
        ///  </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="connection">链接字符串</param>
        /// <param name="cmd">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>int</returns>
        public int ExcuteNonQuery<T>(string cmd, DynamicParameters param = null, bool flag = false) where T : class, new()
        {
            int result = 0;
            using (var con = new MySqlFactory().DataBaseConnection(_connectionStr))
            {
                result = con.Execute(cmd, param, null, null, flag ? CommandType.StoredProcedure : CommandType.Text);
            }
            return result;
        }
        #endregion

        public int ExcuteNonQuery(string cmd, DynamicParameters param = null, bool flag = false)
        {
            WriterLog(cmd);
            int result = 0;
            using (var con = new MySqlFactory().DataBaseConnection(_connectionStr))
            {
                result = con.Execute(cmd.ToLower(), param, null, null, flag ? CommandType.StoredProcedure : CommandType.Text);
            }
            return result;
        }
        public int ExcuteNonQueryTransaction(List<string> cmd, List<DynamicParameters> param, List<CommandType> commandType)
        {
            int result = 0;
            using (var con = new MySqlFactory().DataBaseConnection(_connectionStr))
            {
                IDbTransaction transaction = con.BeginTransaction();
                result += cmd.Select((t, i) => con.Execute(t, param[i], transaction, null, commandType[i])).Sum();
                if (result == cmd.Count)
                {
                    transaction.Commit();
                }
                transaction.Rollback();
            }
            return result;
        }

        public int ExcuteNonQueryTransaction(string cmd, DynamicParameters param, bool flag = false)
        {
            int result = 0;
            using (var con = new MySqlFactory().DataBaseConnection(_connectionStr))
            {
                IDbTransaction transaction = con.BeginTransaction();
                result = con.Execute(cmd, param, null, null, flag ? CommandType.StoredProcedure : CommandType.Text);
                if (result != 0)
                {
                    transaction.Commit();
                }
                transaction.Rollback();
            }
            return result;
        }

        #region +ExcuteNonQueryAsync 增、删、改异步操作
        /// <summary>
        /// 增、删、改异步操作
        /// 
        ///
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="connection">链接字符串</param>
        /// <param name="cmd">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>int</returns>
        public async Task<int> ExcuteNonQueryAsync<T>(string cmd, DynamicParameters param = null, bool flag = false) where T : class, new()
        {
            int result = 0;
            using (var con = new MySqlFactory().DataBaseConnection(_connectionStr))
            {
                result = await con.ExecuteAsync(cmd, param, null, null, flag ? CommandType.StoredProcedure : CommandType.Text);
            }
            return result;
        }
        #endregion

        #region +ExecuteScalar 同步查询操作
        /// <summary>
        /// 同步查询操作
        /// 
        ///
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="connection">连接字符串</param>
        /// <param name="cmd">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>object</returns>
        public object ExecuteScalar<T>(string cmd, DynamicParameters param = null, bool flag = false) where T : class, new()
        {
            object result = null;
            using (var con = new MySqlFactory().DataBaseConnection(_connectionStr))
            {
                result = con.ExecuteScalar(cmd, param, null, null, flag ? CommandType.StoredProcedure : CommandType.Text);
            }
            return result;
        }
        public object ExecuteScalar(string cmd, DynamicParameters param = null, bool flag = false)
        {
            WriterLog(cmd);
            object result = null;
            using (var con = new MySqlFactory().DataBaseConnection(_connectionStr))
            {
                result = con.ExecuteScalar(cmd.ToLower(), param, null, null, flag ? CommandType.StoredProcedure : CommandType.Text);
            }
            return result;
        }
        #endregion

        #region +ExecuteScalarAsync 异步查询操作
        /// <summary>
        /// 异步查询操作
        /// 
        ///
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="connection">连接字符串</param>
        /// <param name="cmd">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>object</returns>
        public async Task<object> ExecuteScalarAsync<T>(string cmd, DynamicParameters param = null, bool flag = false) where T : class, new()
        {
            object result = null;
            using (var con = new MySqlFactory().DataBaseConnection(_connectionStr))
            {
                result = con.ExecuteScalarAsync(cmd, param, null, null, flag ? CommandType.StoredProcedure : CommandType.Text);
            }
            return result;
        }
        #endregion

        #region +FindOne  同步查询一条数据
        /// <summary>
        /// 同步查询一条数据
        /// 
        ///
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="connection">连接字符串</param>
        /// <param name="cmd">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>t</returns>
        public T FindOne<T>(string cmd, DynamicParameters param = null, bool flag = false) where T : class, new()
        {
            WriterLog(cmd);
            using (var con = new MySqlFactory().DataBaseConnection(_connectionStr))
            {
                IDataReader dataReader = con.ExecuteReader(cmd.ToLower(), param, null, null, flag ? CommandType.StoredProcedure : CommandType.Text);

                Type type = typeof(T);
                T t = new T();
                while (dataReader.Read())
                {
                    foreach (var item in type.GetProperties())
                    {
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            //属性名与查询出来的列名比较
                            if (item.Name.ToLower() != dataReader.GetName(i).ToLower()) continue;
                            var kvalue = dataReader[item.Name];
                            if (kvalue == DBNull.Value) continue;
                            item.SetValue(t, kvalue, null);
                            break;
                        }
                    }
                }
                return t;
            }
        }
        #endregion

        #region +FindOne  异步查询一条数据
        /// <summary>
        /// 异步查询一条数据
        /// 
        ///
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="connection">连接字符串</param>
        /// <param name="cmd">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>t</returns>
        public async Task<T> FindOneAsync<T>(string cmd, DynamicParameters param = null, bool flag = false) where T : class, new()
        {
            using (var con = new MySqlFactory().DataBaseConnection(_connectionStr))
            {
                IDataReader dataReader = await con.ExecuteReaderAsync(cmd, param, null, null, flag ? CommandType.StoredProcedure : CommandType.Text);

                Type type = typeof(T);
                T t = new T();
                foreach (var item in type.GetProperties())
                {
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        //属性名与查询出来的列名比较
                        if (item.Name.ToLower() != dataReader.GetName(i).ToLower()) continue;
                        var kvalue = dataReader[item.Name];
                        if (kvalue == DBNull.Value) continue;
                        item.SetValue(t, kvalue, null);
                        break;
                    }
                }
                return t;
            }
        }
        #endregion

        #region +FindToList  同步查询数据集合
        /// <summary>
        /// 同步查询数据集合
        /// 
        ///
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="connection">连接字符串</param>
        /// <param name="cmd">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>t</returns>
        public IList<T> FindToList<T>(string cmd, DynamicParameters param = null, bool flag = false) where T : class, new()
        {
            WriterLog(cmd);
            using (var con = new MySqlFactory().DataBaseConnection(_connectionStr))
            {
                IDataReader dataReader = con.ExecuteReader(cmd.ToLower(), param, null, null, flag ? CommandType.StoredProcedure : CommandType.Text);
                Type type = typeof(T);
                List<T> tlist = new List<T>();
                while (dataReader.Read())
                {
                    T t = new T();
                    foreach (var item in type.GetProperties())
                    {
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            //属性名与查询出来的列名比较
                            if (item.Name.ToLower() != dataReader.GetName(i).ToLower()) continue;
                            var kvalue = dataReader[item.Name];
                            if (kvalue == DBNull.Value) continue;
                            item.SetValue(t, kvalue, null);
                            break;
                        }
                    }
                    if (tlist != null) tlist.Add(t);
                }
                return tlist;
            }
        }
        #endregion

        #region +FindToListAsync  异步查询数据集合
        /// <summary>
        /// 异步查询数据集合
        /// 
        ///
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="connection">连接字符串</param>
        /// <param name="cmd">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>t</returns>
        public async Task<IList<T>> FindToListAsync<T>(string cmd, DynamicParameters param = null, bool flag = false) where T : class, new()
        {
            using (var con = new MySqlFactory().DataBaseConnection(_connectionStr))
            {
                IDataReader dataReader = await con.ExecuteReaderAsync(cmd, param, null, null, flag ? CommandType.StoredProcedure : CommandType.Text);

                Type type = typeof(T);
                List<T> tlist = new List<T>();
                while (dataReader.Read())
                {
                    T t = new T();
                    foreach (var item in type.GetProperties())
                    {
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            //属性名与查询出来的列名比较
                            if (item.Name.ToLower() != dataReader.GetName(i).ToLower()) continue;
                            var kvalue = dataReader[item.Name];
                            if (kvalue == DBNull.Value) continue;
                            item.SetValue(t, kvalue, null);
                            break;
                        }
                    }
                    if (tlist != null) tlist.Add(t);
                }
                return tlist;
            }
        }
        #endregion

        #region +FindToList  同步查询数据集合
        /// <summary>
        /// 同步查询数据集合
        ///   
        ///
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="connection">连接字符串</param>
        /// <param name="cmd">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>t</returns>
        public IList<T> FindToListAsPage<T>(string cmd, DynamicParameters param = null, bool flag = false) where T : class, new()
        {
            using (var con = new MySqlFactory().DataBaseConnection(_connectionStr))
            {
                IDataReader dataReader = con.ExecuteReader(cmd, param, null, null, flag ? CommandType.StoredProcedure : CommandType.Text);

                Type type = typeof(T);
                List<T> tlist = new List<T>();
                while (dataReader.Read())
                {
                    T t = new T();
                    foreach (var item in type.GetProperties())
                    {
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            //属性名与查询出来的列名比较
                            if (item.Name.ToLower() != dataReader.GetName(i).ToLower()) continue;
                            var kvalue = dataReader[item.Name];
                            if (kvalue == DBNull.Value) continue;
                            item.SetValue(t, kvalue, null);
                            break;
                        }
                    }
                    if (tlist != null) tlist.Add(t);
                }
                return tlist;
            }
        }
        #endregion

        #region +FindToListByPage  同步分页查询数据集合
        /// <summary>
        /// 同步分页查询数据集合
        /// 
        ///
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="connection">连接字符串</param>
        /// <param name="cmd">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>t</returns>
        public IList<T> FindToListByPage<T>(string cmd, DynamicParameters param = null, bool flag = false) where T : class, new()
        {

            using (var con = new MySqlFactory().DataBaseConnection(_connectionStr))
            {
                IDataReader dataReader = con.ExecuteReader(cmd, param, null, null, flag ? CommandType.StoredProcedure : CommandType.Text);
                Type type = typeof(T);
                List<T> tlist = new List<T>();
                while (dataReader.Read())
                {
                    T t = new T();
                    foreach (var item in type.GetProperties())
                    {
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            //属性名与查询出来的列名比较
                            if (item.Name.ToLower() != dataReader.GetName(i).ToLower()) continue;
                            var kvalue = dataReader[item.Name];
                            if (kvalue == DBNull.Value) continue;
                            item.SetValue(t, kvalue, null);
                            break;
                        }
                    }
                    if (tlist != null) tlist.Add(t);
                }
                return tlist;
            }
        }
        #endregion

        #region +FindToListByPageAsync  异步分页查询数据集合
        /// <summary>
        /// 异步分页查询数据集合
        /// 
        ///
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="connection">连接字符串</param>
        /// <param name="cmd">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>t</returns>
        public async Task<IList<T>> FindToListByPageAsync<T>(string cmd, DynamicParameters param = null, bool flag = false) where T : class, new()
        {
            using (var con = new MySqlFactory().DataBaseConnection(_connectionStr))
            {
                IDataReader dataReader = await con.ExecuteReaderAsync(cmd, param, null, null, flag ? CommandType.StoredProcedure : CommandType.Text);

                Type type = typeof(T);
                List<T> tlist = new List<T>();
                while (dataReader.Read())
                {
                    T t = new T();
                    foreach (var item in type.GetProperties())
                    {
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            //属性名与查询出来的列名比较
                            if (item.Name.ToLower() != dataReader.GetName(i).ToLower()) continue;
                            var kvalue = dataReader[item.Name];
                            if (kvalue == DBNull.Value) continue;
                            item.SetValue(t, kvalue, null);
                            break;
                        }
                    }
                    if (tlist != null) tlist.Add(t);
                }
                return tlist;
            }
        }
        #endregion

        private void WriterLog(string sql)
        {
            //Task.Factory.StartNew(() =>
            //{
            //    FileStream fs = new FileStream(AppContext.BaseDirectory + @"sql.log", FileMode.OpenOrCreate);
            //    StreamWriter sw = new StreamWriter(fs);
            //    sw.WriteLine(string.Format("{0}---->{1}", DateTime.Now, sql));
            //    sw.Close();
            //});
        }
    }
}
