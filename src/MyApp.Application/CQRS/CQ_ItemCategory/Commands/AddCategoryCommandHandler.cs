using MediatR;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using MyApp.Domain.Interfaces;

namespace MyApp.Application.CQRS.CQ_ItemCategory.Commands
{
    public record AddCategoryCommand(string Name) : IRequest<int>;

    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, int>
    {
        private readonly IEntityRepository<ItemCategory> _repo;

        public AddCategoryCommandHandler(IEntityRepository<ItemCategory> repo)
        {
            _repo = repo;
        }
        public async Task<int> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var existing = _repo.AllIQueryable().FirstOrDefault(f => f.Name.Trim() == request.Name.Trim());
            if (existing != null)
                return 1; // duplicate

            var category = new ItemCategory
            {
                Name = request.Name,

            };
            await _repo.AddAsync(category);
            return 2;
        }
    }
}
