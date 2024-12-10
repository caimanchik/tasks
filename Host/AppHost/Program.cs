var builder = DistributedApplication.CreateBuilder(args);

var userNameDefault = builder.AddParameter("username", secret: true);
var passwordDefault = builder.AddParameter("password", secret: true);

var rabbitMq = builder.AddRabbitMQ("rabbitMq", userNameDefault, passwordDefault)
    .WithManagementPlugin()
    .WithDataVolume();

var keycloak = builder.AddKeycloak("keycloak", port: 10001, userNameDefault, passwordDefault)
    .WithDataVolume();

var postgres = builder.AddPostgres("postgres", userNameDefault, passwordDefault)
    .WithDataVolume();

var postgresTasks = postgres.AddDatabase("postgresTasks", "tasks");

builder.Build().Run();