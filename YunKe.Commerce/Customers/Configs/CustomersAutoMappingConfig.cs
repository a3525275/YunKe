using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YunKe.Commerce.Customers.Domain;
using YunKe.Commerce.Customers.Dtos;

namespace YunKe.Commerce.Customers.Configs
{
    public class CustomersAutoMappingConfig: Profile
    {
        public CustomersAutoMappingConfig()
        {
        }

        protected override void Configure()
        {
            //CreateMap<Customer, CustomersOverviewDto>()
            //    .ForMember(it => it.CompanyName, m => m.ResolveUsing(s => s.Code))
            //    .ForMember(it => it.CategoryName, m => m.ResolveUsing(s => s.ArticleCategory.Name))
            //    .ForMember(it => it.CommentsAmount, m => m.ResolveUsing(s => s.Comments.Count));
        }
    }
}
