using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.Commerce.SiteTemplates.Domain;
using YunKe.Commerce.SiteTemplates.Queries;
using YunKe.Commerce.SiteTemplates.Dtos;
using YunKe.Infrastructure;
using YunKe.Infrastructure.Queries;
using YunKe.Infrastructure.Service;

namespace YunKe.Commerce.SiteTemplates.QueryHandlers
{
    public class SiteTemplateQueryHandler :
        IQueryHandler<GetSiteTemplatesListQuery, PagedResult<SiteTemplateOverviewDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<SiteTemplate> _repo;

        public SiteTemplateQueryHandler(IRepository<SiteTemplate> repo,
            IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public PagedResult<SiteTemplateOverviewDto> Handle(GetSiteTemplatesListQuery query)
        {
            return _repo.GetPagedData(query, s => _mapper.Map<IEnumerable<SiteTemplateOverviewDto>>(s));
        }
    }
}
