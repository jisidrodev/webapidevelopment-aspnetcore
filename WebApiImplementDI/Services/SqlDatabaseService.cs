using System;
using WebApiImplementDI.Services.Interfaces;

namespace WebApiImplementDI.Services;

public class SqlDatabaseService : IDataService
{
    public string GetData()
    {
        return "Data from SQL Database";
    }
}
