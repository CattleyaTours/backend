using System.ComponentModel.DataAnnotations.Schema;

[NotMapped]
public class JWTSettings
{
    public string SecretKey { get; set; }
}