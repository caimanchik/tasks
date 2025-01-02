namespace Api.Tasks.ApiModels.Enums;

internal enum TaskStateDto
{
    Unknown = 0,
    Created = 1,
    WaitingToStart = 2,
    Processing = 4,
    Finished = 8,
    Canceled = 16,
}