using Microsoft.EntityFrameworkCore;

using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace SeguroVeiculo.Seedwork.Domain
{
    public abstract class Entity<TId> : IEntity<TId>, IValidatableObject
        where TId : struct
    {
        public abstract TId Id { get; set; }
        public abstract bool IsTransient();

        [Comment("Data/Hora da criação.")]
        public DateTime CreateDate { get; set; }

        [Comment("Data/Hora da última atualização.")]
        public DateTime UpdateDate { get; set; }


        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Enumerable.Empty<ValidationResult>();
        }
    }
}
