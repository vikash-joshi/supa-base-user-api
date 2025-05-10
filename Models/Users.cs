// Models/User.cs
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace SupaBaseNewsLetter.Models;

[Table("users")]
public class User : BaseModel
{
    [PrimaryKey("id", false)]   
    public long Id { get; set; }

    [Column("full_name")]
    public string FullName { get; set; }

    [Column("email")]
    public string Email { get; set; }
}
