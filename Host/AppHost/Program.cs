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

var apiTasks = builder.AddProject<Projects.Api_Tasks>("apiTasks")
    .WithReference(rabbitMq)
    .WithReference(keycloak)
    .WithReference(postgres)
    .WithReference(postgresTasks);

var factorialTask = builder.AddProject<Projects.Factorial_Tasks>("factorialTask")
    .WithReference(rabbitMq);

var hypotenuseTask = builder.AddProject<Projects.Hypotenuse_Tasks>("hypotenuseTask")
    .WithReference(rabbitMq);

var countPrimesTask = builder.AddProject<Projects.CountPrimes_Tasks>("countPrimesTask")
    .WithReference(rabbitMq);

builder.Build().Run();