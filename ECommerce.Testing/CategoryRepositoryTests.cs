using ECommerce.Domain.Models;
using ECommerce.Infrastructure.Data;
using ECommerce.Infrastructure.Implementation;
using ECommerce.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Testing
{
    public class CategoryRepositoryTests
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ApplicationDbContext _context;

        public CategoryRepositoryTests()
        {
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test") // connection string is ignored
                .Options;

            _context = new ApplicationDbContext(dbOptions);

            _categoryRepository = new CategoryRepository(_context);
        }

        [Fact]
        public async Task Test_Add_Category_Async()
        {
            // Arrange
            var category = new Category
            {
                Name = "Test Category",
                CreatedAt = DateTime.Now,
                Description = "Test Description"
            };

            // Act
            await _categoryRepository.AddAsync(category);

            // Assert
            var result = await _context.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Test_Get_Category_By_Id_Async()
        {
            // Arrange
            var category = new Category
            {
                Name = "Test Category",
                CreatedAt = DateTime.Now,
                Description = "Test Description"
            };

            await _categoryRepository.AddAsync(category);

            // Act
            var result = await _categoryRepository.GetByIdAsync(category.Id);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Test_Get_Categories_Async()
        {
            // Arrange
            var category = new Category
            {
                Name = "Test Category",
                CreatedAt = DateTime.Now,
                Description = "Test Description"
            };

            await _categoryRepository.AddAsync(category);

            // Act
            var result = await _categoryRepository.GetAsNoTracking().ToListAsync();

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task Test_Update_Category_Async()
        {
            // Arrange
            var category = new Category
            {
                Name = "Test Category",
                CreatedAt = DateTime.Now,
                Description = "Test Description"
            };

            await _categoryRepository.AddAsync(category);

            // Act
            category.Name = "Updated Test Category";
            await _categoryRepository.UpdateAsync(category);

            // Assert
            var result = await _context.Categories.FirstOrDefaultAsync(c => c.Name == "Not Updated Test Category");
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Test_Delete_Category_Async()
        {
            // Arrange
            var category = new Category
            {
                Name = "Test Category",
                CreatedAt = DateTime.Now,
                Description = "Test Description"
            };

            await _categoryRepository.AddAsync(category);

            // Act
            await _categoryRepository.DeleteAsync(category);

            // Assert
            var result = await _context.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
            Assert.Null(result);
        }
    }
}