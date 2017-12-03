﻿
using Npgsql;
using System;
using System.Data;

namespace Nice.DataAccess.Npgsql.Provider
{
    /// <summary>
    /// Npgsql数据库操作的帮助类
    /// </summary>
    public class NpgsqlDataProvider : DataProvider
    {
        public NpgsqlDataProvider(string _dbConnString)
        {
            dbConnString = _dbConnString;
        }

        public override IDbConnection GetConnection()
        {
            return new NpgsqlConnection(dbConnString);
        }

        public override IDbCommand GetCommand()
        {
            //IDbConnection conn = new NpgsqlConnection(dbConnString);
            //conn.Open();
            //return conn.CreateCommand();
            return new NpgsqlCommand();
        }

        public override void AttachParameters(IDbCommand command, IDataParameter[] dbps)
        {
            command.Parameters.Clear();
            foreach (IDataParameter p in dbps)
            {
                if (p.Value == null)
                {
                    p.Value = DBNull.Value;
                }
                command.Parameters.Add(p);
            }
        }
        
        public override IDbDataAdapter GetDataAdapter(IDbCommand command)
        {
            return new NpgsqlDataAdapter((NpgsqlCommand)command);
        }

    }
}