using System.ComponentModel.DataAnnotations;

namespace Core.BaseModels.Repositories.Models;

public abstract class EntityBase<TKey> : EntityBase
{
    [Key]
    public TKey Id { get; set; }
    
    protected EntityBase(TKey id, DateTime dateOfCreate)
    {
        Id = id;
        DateOfCreate = dateOfCreate;
        DateOfUpdate = null;
    }
}
