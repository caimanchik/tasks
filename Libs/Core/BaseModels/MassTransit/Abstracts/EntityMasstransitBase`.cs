namespace Core.BaseModels.MassTransit.Abstracts;

public abstract class MasstransitEntityBase<TKey>
{
    public required TKey Key { get; set; }
}