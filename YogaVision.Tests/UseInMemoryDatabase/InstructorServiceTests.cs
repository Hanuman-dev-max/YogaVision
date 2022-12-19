namespace YogaVision.Tests.UseInMemoryDatabase
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.City;
    using YogaVision.Core.Models.Instructor;
    using YogaVision.Infrastructure.Data.Models;
    public class InstructorServiceTests : BaseServiceTests
    {
        private IInstructorService Service => this.ServiceProvider.GetRequiredService<IInstructorService>();



        [Fact]
        public async Task AddAsyncShouldAddCorrectly()
        {

            //Arrange
            await this.CreateInstructorAsync();
            var nickname = new NLipsum.Core.Word().ToString();
            var firstName = new NLipsum.Core.Word().ToString();
            var lastName = new NLipsum.Core.Word().ToString();
            var imageUrl = new NLipsum.Core.Word().ToString();
            var imageUrlFirst = new NLipsum.Core.Word().ToString();
            var imageUrlSecond = new NLipsum.Core.Word().ToString();
            var imageUrlThird = new NLipsum.Core.Word().ToString();
            var description = new NLipsum.Core.Paragraph().ToString();
            var facebookLink = new NLipsum.Core.Word().ToString();
            
            await this.Service.AddAsync(firstName, lastName, description, nickname,imageUrl, imageUrlFirst, imageUrlSecond, imageUrlThird, facebookLink);

            //Act
            var instructorsCount = await this.DbContext.Instructors.CountAsync();
            //Assert
            Assert.Equal(2, instructorsCount);
        }

        [Fact]
        public async Task DeleteAsyncShouldDeleteCorrectly()
        {
            //Arrange
            var instructor = await this.CreateInstructorAsync();
            await this.Service.DeleteAsync(instructor.Id);
            //Act
            var instructorsCount = this.DbContext.Instructors.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedInstructor = await this.DbContext.Instructors.FirstOrDefaultAsync(x => x.Id == instructor.Id);
            //Assert
            Assert.Equal(0, instructorsCount);
            Assert.Null(deletedInstructor);
        }
        [Fact]
        public async Task GetByIdShouldReturnCorrectly()
        {
            //Arranege
            var instructor = await this.CreateInstructorAsync();

            //Act
            var actualInstructor = await this.Service.GetByIdAsync<InstructorViewModel>(instructor.Id);
            //Assert
            Assert.Equal(instructor.Nickname, actualInstructor.NickName);

        }
        [Fact]
        public async Task GetAllAsyncShouldReturnCorrectly()
        {
            //Arrange
            var instructor = await this.CreateInstructorAsync();
            //Act
            var ActualInstructors = await this.Service.GetAllAsync<InstructorViewModel>();
            //Assert
            Assert.Equal(1, ActualInstructors.Count());
        }
        [Fact]
        public async Task EditAsyncShouldReturnCorrectly()
        {
            //Arrange
            var instructor = await this.CreateInstructorAsync();

            //Act
            await this.Service.EditAsync(instructor.Id, "TestFirstName","TestLastName", "TestDescription", "TestNickName", "TestImageUrl", "TestImageUrlFirst", "TestImageUrlSecond", "TestImageUrlThird", "TestFacebookLink");
            var actualInstructor = await this.Service.GetByIdAsync<InstructorViewModel>(instructor.Id);

            //Assert
            Assert.Equal("TestFirstName", actualInstructor.FirstName);
            Assert.Equal("TestLastName", actualInstructor.LastName);
            Assert.Equal("TestDescription", actualInstructor.Description);
            Assert.Equal("TestNickName", actualInstructor.NickName);
            Assert.Equal("TestImageUrl", actualInstructor.ImageUrl);
            Assert.Equal("TestImageUrlFirst", actualInstructor.ImageUrlFirst);
            Assert.Equal("TestImageUrlSecond", actualInstructor.ImageUrlSecond);
            Assert.Equal("TestImageUrlThird", actualInstructor.ImageUrlThird);
            Assert.Equal("TestFacebookLink", actualInstructor.FacebookLink);
        }


        private async Task<Instructor> CreateInstructorAsync()
        {
            var Instructor = new Instructor
            {
                 Nickname = new NLipsum.Core.Word().ToString(),
                 FirstName = new NLipsum.Core.Word().ToString(),
                 LastName  = new NLipsum.Core.Word().ToString(),
                 ImageUrl = new NLipsum.Core.Word().ToString(),
                 ImageUrlFirst = new NLipsum.Core.Word().ToString(),
                 ImageUrlSecond = new NLipsum.Core.Word().ToString(),
                 ImageUrlThird = new NLipsum.Core.Word().ToString(),
                 Description = new NLipsum.Core.Paragraph().ToString(),
                  FacebookLink = new NLipsum.Core.Word().ToString(),
            };

            await this.DbContext.Instructors.AddAsync(Instructor);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Instructor>(Instructor).State = EntityState.Detached;
            return Instructor;
        }


    }
}
