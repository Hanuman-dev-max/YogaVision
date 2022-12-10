namespace YogaVision.Tests.UseInMemoryDatabase
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;
    using YogaVision.Core.Contracts;
    using YogaVision.Infrastructure.Data.Models;
    public class YogaEventApplicationUserServiceTests : BaseServiceTests
    {
        private IYogaEventApplicationUserService Service => this.ServiceProvider.GetRequiredService<IYogaEventApplicationUserService>();


        [Fact]
        public async Task AddAsyncShouldAddCorrectly()
        {

            //Arrange
            await this.CreateYogaEventApplicationUserAsync();

            await this.Service.AddAsync(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

            //Act
            var YogaEventApplicationUsersCount = await this.DbContext.YogaEventApplicationUsers.CountAsync();
            //Assert
            Assert.Equal(2, YogaEventApplicationUsersCount);
        }
        [Fact]
        public async Task CheckUserInEventShouldReturnCorrectlyTrue()
        {
            //Arrange 
            var yogaEventApplicationUser =  await this.CreateYogaEventApplicationUserAsync();
            

            //Act
            var result =  await this.Service.CheckUserInEvent(yogaEventApplicationUser.YogaEventId, yogaEventApplicationUser.ApplicationUserId);
            //Assert
            Assert.Equal(bool.TrueString, result.ToString());

        }
        [Fact]
        public async Task CheckUserInEventShouldReturnCorrectlyFalse()
        {
            //Arrange 
            var yogaEventApplicationUserFirst = await this.CreateYogaEventApplicationUserAsync();
            var yogaEventApplicationUserSecond = await this.CreateYogaEventApplicationUserAsync();


            //Act
            var result = await this.Service.CheckUserInEvent(yogaEventApplicationUserFirst.YogaEventId, yogaEventApplicationUserSecond.ApplicationUserId);
            //Assert
            Assert.Equal(bool.FalseString, result.ToString());

        }
        public async Task DeleteAsyncShouldDeleteCorrectly()
        {
            //Arrange
            var yogaEventApplicationUser = await this.CreateYogaEventApplicationUserAsync();
            await this.Service.DeleteAsync(yogaEventApplicationUser.YogaEventId, yogaEventApplicationUser.ApplicationUserId);
            //Act
            var yogaEventApplicationUsersCount = this.DbContext.YogaEventApplicationUsers.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedYogaEventApplicationUser = await this.DbContext.YogaEventApplicationUsers.FirstOrDefaultAsync(x => x.Id == yogaEventApplicationUser.Id);
            //Assert
            Assert.Equal(0, yogaEventApplicationUsersCount);
            Assert.Null(deletedYogaEventApplicationUser);
        }


        private async Task<YogaEventApplicationUser> CreateYogaEventApplicationUserAsync()
        {

            var yogaEventApplicationUser = new YogaEventApplicationUser
            {
                 ApplicationUserId = Guid.NewGuid().ToString(),
                 YogaEventId = Guid.NewGuid().ToString(),
            };

            await this.DbContext.YogaEventApplicationUsers.AddAsync(yogaEventApplicationUser);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<YogaEventApplicationUser>(yogaEventApplicationUser).State = EntityState.Detached;
            return yogaEventApplicationUser;
        }
    }
}
