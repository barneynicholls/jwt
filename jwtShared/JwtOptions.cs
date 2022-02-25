namespace jwtShared;

public class JwtOptions
{
    public const string SectionName = "JwtConfiguration";
    public string IssuerSigningKey { get; set; }
    public string ValidIssuer { get; set; }
    public string ValidAudience { get; set; }
}