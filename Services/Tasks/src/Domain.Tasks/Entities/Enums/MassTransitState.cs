namespace Domain.Tasks.Entities.Enums;

[Flags]
public enum MassTransitState
{
    Created = 0,
    Processing = 1,
    Processed = 2,
}