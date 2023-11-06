using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguroVeiculo.Seedwork.Domain
{
    public class GuidEntity : Entity<Guid>
    {
        private Guid _id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id
        {
            get { return _id; }
            set
            {
                if (!this.IsTransient())
                {
                    throw new InvalidOperationException();
                }

                _id = value;
            }
        }


        public override bool IsTransient()
        {
            return this.Id.Equals(Guid.Empty);
        }
    }
}