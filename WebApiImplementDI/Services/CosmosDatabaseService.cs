using System;
using WebApiImplementDI.Services.Interfaces;

namespace WebApiImplementDI.Services;

public class CosmosDatabaseService : IDataService
{
    public string GetData()
    {
        return "Data from Cosmos Database";
    }
}
