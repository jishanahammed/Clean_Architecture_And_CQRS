using MediatR;
using Microsoft.EntityFrameworkCore;
using MyApp.Application.Dtos.dto_ItemCategory;
using MyApp.Domain.Entities;
using MyApp.Domain.Interfaces;

namespace MyApp.Application.CQRS.CQ_ItemCategory.Queries
{
    // ✅ Request record
    public record GetCategoryByIdQuery(int Id) : IRequest<ItemCategory_Dto?>;

    // ✅ Handler implementation
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, ItemCategory_Dto?>
    {
        private readonly IEntityRepository<ItemCategory> _repo;

        public GetCategoryByIdQueryHandler(IEntityRepository<ItemCategory> repo)
        {
            _repo = repo;
        }

        public async Task<ItemCategory_Dto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repo
                           .AllIQueryable() // IQueryable<ItemCategory>
                           .Where(f => f.Id == request.Id)
                        .Select(c => new ItemCategory_Dto(c.Id, c.Name)).FirstOrDefaultAsync(cancellationToken);

            return entity; // null if not found
        }
    }
}
