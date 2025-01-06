using Domain.Tasks.Abstracts.Existing;
using Domain.Tasks.Entities.CountPrimes;
using Domain.Tasks.Entities.Enums;
using Domain.Tasks.Entities.Factorial;
using Domain.Tasks.Entities.Fibonacci;
using Domain.Tasks.Entities.GCD;
using Domain.Tasks.Entities.Hypotenuse;
using Domain.Tasks.Entities.Palindrome;
using Domain.Tasks.Entities.SumOfDigits;
using Domain.Tasks.Interfaces.Services;
using Domain.Tasks.MassTransit.Entities;
using Domain.Tasks.MassTransit.Entities.Abstracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Logic.Tasks.Services;

public class TasksActionsConsumer(
    ITaskService taskService,
    ILogger<TasksActionsConsumer> logger) : 
    IConsumer<TaskProcessed<FactorialTaskArtefacts>>, IConsumer<TaskProcessed<HypotenuseTaskArtefacts>>,
    IConsumer<TaskProcessed<CountPrimesTaskArtefacts>>, IConsumer<TaskProcessed<SumOfDigitsTaskArtefacts>>,
    IConsumer<TaskProcessed<PalindromeTaskArtefacts>>, IConsumer<TaskProcessed<FibonacciTaskArtefacts>>,
    IConsumer<TaskProcessed<GCDTaskArtefacts>>
{
    public async Task Consume(ConsumeContext<TaskProcessing> context)
    {
        var task = context.Message;
        var isSuccessUpdate = await taskService.TrySetState(task.Key, TaskState.Processing, default);
        
        if (isSuccessUpdate)
            logger.LogInformation("Обновлено состояние {TaskState} задачи {TaskId}", TaskState.Processing, task.Key);
        else
            logger.LogInformation("Не удалось обновить состояние {TaskState} задачи {TaskId}", 
                TaskState.Processing, task.Key);
    }

    public async Task Consume(ConsumeContext<TaskProcessed<FactorialTaskArtefacts>> context) => 
        await Consume<FactorialTaskArtefacts, int, long>(context.Message);

    public async Task Consume(ConsumeContext<TaskProcessed<HypotenuseTaskArtefacts>> context) =>
        await Consume<HypotenuseTaskArtefacts, HypotenuseTaskCondition, double>(context.Message);
    
    public async Task Consume(ConsumeContext<TaskProcessed<CountPrimesTaskArtefacts>> context) => 
        await Consume<CountPrimesTaskArtefacts, int, int>(context.Message);

    public async Task Consume(ConsumeContext<TaskProcessed<SumOfDigitsTaskArtefacts>> context) => 
        await Consume<SumOfDigitsTaskArtefacts, int, int>(context.Message);

    public async Task Consume(ConsumeContext<TaskProcessed<PalindromeTaskArtefacts>> context) =>
        await Consume<PalindromeTaskArtefacts, string, bool>(context.Message);

    public async Task Consume(ConsumeContext<TaskProcessed<FibonacciTaskArtefacts>> context) => 
        await Consume<FibonacciTaskArtefacts, int, long>(context.Message);

    public async Task Consume(ConsumeContext<TaskProcessed<GCDTaskArtefacts>> context) => 
        await Consume<GCDTaskArtefacts, GCDTaskCondition, int>(context.Message);

    private async Task Consume<TArtefacts, TCondition, TResult>(MassTransitTaskBase<TArtefacts> task)
        where TArtefacts : TaskArtefactsBase<TCondition, TResult>
    {
        var newState = task.TaskArtefacts.Exception is null
            ? TaskState.Finished
            : TaskState.Canceled;
        
        var isSuccessUpdate = await taskService.TryUpdateAsync(task.Key, task.TaskArtefacts, newState, default);
        if (isSuccessUpdate)
            logger.LogInformation("Обновлено состояние {TaskState} и результат {Result} {Exception} задачи {TaskId}", 
                newState, task.TaskArtefacts.Result, task.TaskArtefacts.Exception, task.Key);
        else
            logger.LogInformation("Не удалось обновить состояние {TaskState} и результат {Result} {Exception} задачи {TaskId}", 
                newState, task.TaskArtefacts.Result, task.TaskArtefacts.Exception, task.Key);
    }
}