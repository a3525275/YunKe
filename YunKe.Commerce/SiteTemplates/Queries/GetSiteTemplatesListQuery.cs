using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.Infrastructure.Queries;

namespace YunKe.Commerce.SiteTemplates.Queries
{
    public class GetSiteTemplatesListQuery : ListQueryBase
    {
        public string Color { get; set; }

        public string[] Industries { get; set; }
    }
}
