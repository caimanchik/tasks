namespace Core.BaseModels.Repositories.Models;

public abstract class EntityBase
{
    public DateTime DateOfCreate { get; set; }
    
    public DateTime? DateOfUpdate { get; set; }
}