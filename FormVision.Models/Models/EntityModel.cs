using System;
using System.Collections.Generic;

namespace FormVision.Models.Models
{
    public abstract class EntityModel:IEntityModel
    {
        public Guid Id { get; set; }

        protected EntityModel()
        {
            Id = Guid.Empty;
        }
    }

    public interface IEntityModel
    {
        Guid Id { get; set; }
    }
}