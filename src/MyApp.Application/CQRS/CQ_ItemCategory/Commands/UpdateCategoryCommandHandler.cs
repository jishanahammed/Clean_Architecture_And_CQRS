using MediatR;
using MyApp.Domain.Entities;
using MyApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MyApp.Application.CQRS.CQ_ItemCategory.Commands
{
    public record UpdateAddCategoryCommand(int Id, string Name) : IRequest<int>;
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateAddCategoryCommand, int>
    {
        private readonly IEntityRepository<ItemCategory> _repo;

        public UpdateCategoryCommandHandler(IEntityRepository<ItemCategory> repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(UpdateAddCategoryCommand request, CancellationToken cancellationToken)
        {
            var existing = _repo.AllIQueryable().FirstOrDefault(f => f.Name.Trim() == request.Name.Trim() && f.Id != request.Id);
            if (existing != null)
                return 1;

            var entity = await _repo.GetByIdAsync(request.Id);
            if (entity == null) return 0;

            entity.Name = request.Name;
            await _repo.UpdateAsync(entity);
            return 2;
        }
    }
}
