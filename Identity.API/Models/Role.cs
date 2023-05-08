using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace Identity.API.Models
{
    [CollectionName("roles")]
    public class Role : MongoIdentityRole<Guid>
    {

    }
}
