namespace Domain.Tasks.Entities.Enums;

[Flags]
public enum TaskState
{
    Unknown = 0,
    Created = 1,
    WaitingToStart = 2,
    Processing = 4,
    Finished = 8,
    Canceled = 16,
    Updatable = Created | WaitingToStart | Processing,
}