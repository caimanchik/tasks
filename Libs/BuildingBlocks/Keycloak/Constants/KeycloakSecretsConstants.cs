namespace BuildingBlocks.Keycloak.Constants;

public static class KeycloakSecretsConstants
{
    public const string Url = "localhost";
    
    public const string ClientId = "admin-cli";
        
    public const string UserName = "root";
    
    public const string Password = "passwd";
    
    public const string GrantType = "password";
        
    public const string AdminRealm = "master";
        
    public const string Realm = "keycloak-auth";

    public const string AuthorizationUri = $"http://{Url}/realms/{Realm}/protocol/openid-connect/auth";
}