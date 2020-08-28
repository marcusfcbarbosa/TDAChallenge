using System;
using FluentValidator;
using TDA.Shared.Interfaces;

namespace TDA.Shared.Entities
{
    public abstract class Entity : Notifiable, IEntity
    {
        public Entity()
        {
            this.CreatedAt = DateTime.Now;
        }
        public int Id { get; set; }
        public string identifyer { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}