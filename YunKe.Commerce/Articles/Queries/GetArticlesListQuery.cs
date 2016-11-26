using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.Infrastructure.Queries;

namespace YunKe.Commerce.Articles.Queries
{
    public class GetArticlesListQuery : ListQueryBase
    {
        public string CategoryCode { get; set; }

        public string CategoryId { get; set; }

    }
}
