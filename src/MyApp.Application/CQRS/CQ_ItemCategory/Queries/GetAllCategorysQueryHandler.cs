using MediatR;
using Microsoft.EntityFrameworkCore;
using MyApp.Application.Dtos.dto_ItemCategory;
using MyApp.Domain.Entities;
using MyApp.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Application.CQRS.CQ_ItemCategory.Queries
{
    public record GetAllCategorysQuery() : IRequest<List<ItemCategory_Dto>>;

    public class GetAllCategorysQueryHandler : IRequestHandler<GetAllCategorysQuery, List<ItemCategory_Dto>>
    {
        private readonly IEntityRepository<ItemCategory> _repo;

        public GetAllCategorysQueryHandler(IEntityRepository<ItemCategory> repo)
        {
            _repo = repo;
        }

        public async Task<List<ItemCategory_Dto>> Handle(GetAllCategorysQuery request, CancellationToken cancellationToken)
        {
            var items = await _repo
                .AllIQueryable()
                .Select(c => new ItemCategory_Dto(c.Id, c.Name))
                .ToListAsync(cancellationToken);

            return items;
        }
    }
}
