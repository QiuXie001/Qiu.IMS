using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Qiu.IMS.Dtos
{
    public class UserDto : EntityDto<Guid>
    {
        public Guid? TenantId { get; private set; }

        public string UserName { get; private set; }

    }
}
