namespace YogaVision.Tests.UseInMemoryDatabase
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.Tag;
    using YogaVision.Core.Models.YogaEvent;
    using YogaVision.Infrastructure.Data.Models;
    public class YogaEventServiceTests : BaseServiceTests
    {
        private IYogaEventService Service => this.ServiceProvider.GetRequiredService<IYogaEventService>();

        [Fact]
        public async Task AddAsyncShouldAddCorrectly()
        {

            //Arrange
            await this.CreateYogaEventAsync();
            
            await this.Service.AddAsync(1,1, DateTime.Now, new NLipsum.Core.Sentence().ToString(), "2:00", 10); 

            //Act
            var yogaEventsCount = await this.DbContext.YogaEvents.CountAsync();
            //Assert
            Assert.Equal(2, yogaEventsCount);
        }
        [Fact]
        public async Task DeleteAsyncShouldDeleteCorrectly()
        {
            //Arrange
           var yogaEvent =  await this.CreateYogaEventAsync();
            await this.Service.DeleteAsync(yogaEvent.Id);
            //Act
            var yogaEventsCount = this.DbContext.YogaEvents.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedYogaEvent = await this.DbContext.YogaEvents.FirstOrDefaultAsync(x => x.Id == yogaEvent.Id);
            //Assert
            Assert.Equal(0, yogaEventsCount);
            Assert.Null(deletedYogaEvent);
        }
        [Fact]
        public async Task GetByIdShouldReturnCorrectly()
        {
            //Arranege
            var yogaEvent = await this.CreateYogaEventAsync();

           var yogaEvents =  await this.DbContext.YogaEvents.ToListAsync();
            var count = yogaEvents.Count;
            //Act
            var actualYogaEvent = await this.Service.GetByIdAsync<YogaEventTestModel>(yogaEvent.Id);
            
            //Assert
            Assert.Equal(yogaEvent.Description, actualYogaEvent.Description);

        }
        [Fact]
        public async Task GetAllAsyncShouldReturnCorrectly()
        {
            //Arrange
                await this.CreateYogaEventAsync();
                await this.CreateYogaEventAsync();
                await this.CreateYogaEventAsync();


            //Act
            var actualYogaEvents = await this.Service.GetAllAsync<YogaEventTestModel>();
            //Assert
            Assert.Equal(3, actualYogaEvents.Count());
        }

        [Fact]
        public async Task GetByCityIdAsyncShouldReturnCorrectly()
        {
            //Arrange
            await this.CreateYogaEventAsync();
            //Act
            var actualYogaEvents = await this.Service.GetByCityIdAsync<YogaEventTestModel>(1, DateTime.Now.AddDays(-1));
           
            //Assert
            Assert.Equal(1, actualYogaEvents.Count());
       
        }

        [Fact]
        public async Task GetAllByDateAsyncShouldReturnCorrectly()
        {
            //Arrange
            await this.CreateYogaEventAsync();
            //Act
            var actualYogaEventsBeforeGivenDate = await this.Service.GetAllByDateAsync<YogaEventTestModel>(DateTime.Now.AddDays(-1));
            var actualYogaEventsBeforeAfterDate = await this.Service.GetAllByDateAsync<YogaEventTestModel>(DateTime.Now.AddDays(1));
            //Assert
            Assert.Equal(1, actualYogaEventsBeforeGivenDate.Count());
            Assert.Equal(0, actualYogaEventsBeforeAfterDate.Count());
        }
        [Fact]
        public async Task SubstarctSeatShouldReturnCorrectly()
        {
            //Arrange
            var yogaEvent = await this.CreateYogaEventAsync();
            //Act
            await this.Service.SubstarctSeat(yogaEvent.Id);
            var actualYogaEvent = await this.Service.GetByIdAsync<YogaEventTestModel>(yogaEvent.Id);
            //Assert
            Assert.Equal(9, actualYogaEvent.Seats);

        }
        [Fact]
        public async Task AddSeatShouldReturnCorrectly()
        {
            //Arrange
            var yogaEvent = await this.CreateYogaEventAsync();
            //Act
            await this.Service.AddSeat(yogaEvent.Id);
            var actualYogaEvent = await this.Service.GetByIdAsync<YogaEventTestModel>(yogaEvent.Id);
            //Assert
            Assert.Equal(11, actualYogaEvent.Seats);
        }


        private async Task<YogaEvent> CreateYogaEventAsync()
        {
            var studio = new Studio
            {
                Address = new NLipsum.Core.Word().ToString(),
                CityId = 1,
                Name = new NLipsum.Core.Word().ToString(),
                ImageUrl = new NLipsum.Core.Word().ToString(),

            };
            await this.DbContext.Studios.AddAsync(studio);
            await this.DbContext.SaveChangesAsync();


            var yogaEvent = new YogaEvent
            {
                Id = Guid.NewGuid().ToString(),
                DateTime = DateTime.Now,
                Duration = "1:30",
                Description = new NLipsum.Core.Sentence().ToString(),
                Seats = 10,
                InstructorId = 1,
                Studio = studio,
            };

            await this.DbContext.YogaEvents.AddAsync(yogaEvent);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<YogaEvent>(yogaEvent).State = EntityState.Detached;
            return yogaEvent;
        }



    }
}
