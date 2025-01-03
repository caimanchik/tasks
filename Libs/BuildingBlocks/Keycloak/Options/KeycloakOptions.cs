namespace BuildingBlocks.Keycloak.Options;

public class KeycloakOptions
{
    public string Url { get; set; } = "localhost";
    
    public string Realm { get; set; } = "tasks";

    public string AuthorizationUri => $"http://{Url}:10001/realms/{Realm}/protocol/openid-connect/auth";
}