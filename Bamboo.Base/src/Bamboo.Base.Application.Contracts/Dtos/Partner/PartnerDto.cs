using System;
using Newtonsoft.Json;

using Bamboo.Common;
using Volo.Abp.Application.Dtos;

namespace Bamboo.Base.Shared
{
    public class PartnerExtraData 
    {

    }

    public class CreatePartnerDto
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class PartnerDto : CreatePartnerDto, IEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}