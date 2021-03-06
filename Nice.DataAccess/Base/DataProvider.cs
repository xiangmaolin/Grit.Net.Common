using System.Collections.Generic;
using System.Data;

namespace Nice.DataAccess
{
    public abstract class DataProvider
    {
        protected string dbConnString;
        public abstract IDbConnection GetConnection();
        public abstract IDbCommand GetCommand();
        public abstract void AttachParameters(IDbCommand command, IList<IDataParameter> dbps);
        public abstract IDbDataAdapter GetDataAdapter(IDbCommand command);
        public abstract IDataParameter CreateParameter(string parameterName, object value);
        public abstract char GetParameterPrefix();
    }
}
