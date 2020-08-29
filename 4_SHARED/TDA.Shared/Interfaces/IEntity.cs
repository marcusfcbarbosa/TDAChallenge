using System;

namespace TDA.Shared.Interfaces
{
   public interface IEntity
    {
        long Id { get; set; }
        string identifyer { get; set; }
        DateTime CreatedAt { get; set; }
    }
}