using AutoMapper;
using CleanArchitecture.DotNet6.Application.Contracts.Persistence;
using CleanArchitecture.DotNet6.Application.Features.Categories.Commands.CreateCateogry;
using CleanArchitecture.DotNet6.Application.Profiles;
using CleanArchitecture.DotNet6.Application.UnitTests.Mocks;
using CleanArchitecture.DotNet6.Domain.Entities;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.DotNet6.Application.UnitTests.Categories.Commands
{
    public class CreateCategoryTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

        public CreateCategoryTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            MapperConfiguration? configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCategory_AddedToCategoriesRepo()
        {
            CreateCategoryCommandHandler? handler = new CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);

            await handler.Handle(new CreateCategoryCommand() { Name = "Test" }, CancellationToken.None);

            System.Collections.Generic.IReadOnlyList<Category>? allCategories = await _mockCategoryRepository.Object.ListAllAsync();
            allCategories.Count.ShouldBe(5);
        }
    }
}
