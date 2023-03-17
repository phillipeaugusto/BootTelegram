using System;
using BootTelegram.Domain.Constants;

namespace BootTelegram.Domain.Entities;

public class Entity: EntityBase
{
    public Entity()
    {
        Id = Guid.NewGuid();
        DateCreation = DateTime.Now;
        DateCreation = DateTime.Now;
        Status = ApplicationConstants.StatusActive;
    }

    public Guid Id { get; set; }
    public char Status { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime DateChange { get; set; }

}