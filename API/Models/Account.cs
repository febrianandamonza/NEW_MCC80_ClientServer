using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

[Table("tb_m_accounts")]
public class Account : BaseEntity
{
    [Column("password")]
    public string Password { get; set; }
    [Column("otp")]
    public int Otp { get; set; }
    [Column("is_used")]
    public bool IsUsed { get; set; }
    
    [Column("expired_date")]
    public DateTime ExpiredDate { get; set; }

    //Cardinality
    public Employee? Employee { get; set; }
    public ICollection<AccountRole>? AccountRoles { get; set;}
}
