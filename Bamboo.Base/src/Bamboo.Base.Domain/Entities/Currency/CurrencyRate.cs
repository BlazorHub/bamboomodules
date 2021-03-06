using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


using Bamboo.Common;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Base.Entities
{
    /// <summary>
    /// res_currency_rate
    /// </summary>
    public class CurrencyRate : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public CurrencyRate(){}
        public CurrencyRate(Guid id)
            :base(id)
        {

        }
        public Guid? TenantId {get; set;}

#if HAS_DB_POSTGRESQL
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "bigserial")]
#endif
        public long Sequence { get; set; }

        public string Name { get; set; }

        public double Rate { get; set; }

        public long CurrencyId { get; set; }

        public bool IsActive { get; set; }

        public DateTimeOffset? Date { get; set; }

        public string Description { get; set; }

    }

}