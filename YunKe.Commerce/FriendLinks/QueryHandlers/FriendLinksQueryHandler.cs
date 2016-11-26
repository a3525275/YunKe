using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.AdminPanelCore.Entity;
using YunKe.AdminPanelCore.Models;
using YunKe.Commerce.FriendLinks.Queries;
using YunKe.Infrastructure;
using YunKe.Infrastructure.Queries;
using YunKe.Infrastructure.Service;

namespace YunKe.Commerce.FriendLinks.QueryHandlers
{
    public class FriendLinksQueryHandler :
        IQueryHandler<Queries.GetFriendLinksQuery, PagedResult<FriendLinkDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<FriendLink> _repo;

        public FriendLinksQueryHandler(IRepository<FriendLink> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public PagedResult<FriendLinkDto> Handle(GetFriendLinksQuery query)
        {
            var pagedData = _repo.GetPagedData(query, list =>
                        _mapper.Map<IEnumerable<FriendLinkDto>>(list));

            return pagedData;
        }
    }
}
