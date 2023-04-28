using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MongoDB.Settings
{
    public interface IMongoDbSettings
    {
        string MarketplacesCollection { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
