using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace Identity.API.Models
{
    [CollectionName("users")]
    public class User : MongoIdentityUser<Guid>
    {

        public string? FullName { get; set; }

    }
}
