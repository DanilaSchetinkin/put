using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Data.RemoteData.RemoteDataBase;

namespace Demo.Data.Repository;

 class SQLGroupRepositoryImpl
{
    private readonly RemoteDatabaseContext remoteDatabaseContext;

    public SQLGroupRepositoryImpl(RemoteDatabaseContext remoteDatabaseContext)
    {
        remoteDatabaseContext =  remoteDatabaseContext;
    }


}
