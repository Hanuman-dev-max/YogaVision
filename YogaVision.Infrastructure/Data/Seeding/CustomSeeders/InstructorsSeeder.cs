namespace YogaVision.Infrastructure.Data.Seeding.CustomSeeders
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using YogaVision.Data;
    using YogaVision.Infrastructure.Data.Models;
    
    public class InstructorsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Instructors.Any())
            {
                return;
            }

            var instructors = new Instructor[]
                {
                    new Instructor // Id = 1
                    {
                        Nickname = "Рада",
                         FirstName = "Нели",
                         LastName = "Досева",
                         Description = "Запознанство ми с йога започва през 2013г. През годините тя бе вдъхнала в мен сила и дух.\r\nОт 2018г започнах да се занимавам с йога по Айенгар.\r\nТочна, красива, изисква подравняване на тялото, което развива ума, работи върху гъвкавостта и силата едновременно. С благодарност осъзнавам, че тази йога е едно ценно богатство и всяко усилие да напредваш в нея си заслужава.",
                          ImageUrl = "https://res.cloudinary.com/dig1baxyv/image/upload/v1668947702/YogaVision/Rada_t0vvld.jpg",
                           ImageUrlFirst = "https://res.cloudinary.com/dig1baxyv/image/upload/v1668947702/YogaVision/Rada_t0vvld.jpg",
                            ImageUrlSecond = "https://res.cloudinary.com/dig1baxyv/image/upload/v1668947702/YogaVision/Rada_t0vvld.jpg",
                             ImageUrlThird = "https://res.cloudinary.com/dig1baxyv/image/upload/v1668947702/YogaVision/Rada_t0vvld.jpg",

                          FacebookLink ="https://www.facebook.com/neli.doseva.56",
                    },
                    new Instructor // Id = 2
                    {
                        Nickname = "Вивека",
                         FirstName = "Ралица",
                         LastName = "Василева",
                         Description = "Запознанство ми с йога започва през 2013г. През годините тя бе вдъхнала в мен сила и дух.\r\nОт 2018г започнах да се занимавам с йога по Айенгар.\r\nТочна, красива, изисква подравняване на тялото, което развива ума, работи върху гъвкавостта и силата едновременно. С благодарност осъзнавам, че тази йога е едно ценно богатство и всяко усилие да напредваш в нея си заслужава.",
                          ImageUrl = "https://res.cloudinary.com/dig1baxyv/image/upload/v1668947498/YogaVision/Viveka1_inyjhu.jpg",
                          ImageUrlFirst = "https://res.cloudinary.com/dig1baxyv/image/upload/v1668947498/YogaVision/Viveka1_inyjhu.jpg",
                          ImageUrlSecond = "https://res.cloudinary.com/dig1baxyv/image/upload/v1668947498/YogaVision/Viveka1_inyjhu.jpg",
                          ImageUrlThird = "https://res.cloudinary.com/dig1baxyv/image/upload/v1668947498/YogaVision/Viveka1_inyjhu.jpg",
                          FacebookLink="https://www.facebook.com/ralica.vasileva.58"
                    },
                    new Instructor // Id = 3
                    {
                        Nickname = "Сарасвати",
                         FirstName = "Искра",
                         LastName = "Йорданова",
                         Description = "Казвам се Искра Йорданова и съм сертифициран преподавател по  йога за деца и възрастни към Българска федерация по йога. Практикувам и преподавам йога повече от седем  години.\r\nПреподавам терапевтична йога за здрав гръб. Помагам на хората да се чувстват добре, да са по-здрави и щастливи.  От известно време преподавам йога в къщата ми в село Беляковец.",
                          ImageUrl = "https://res.cloudinary.com/dig1baxyv/image/upload/v1668945415/YogaVision/Sarasvati_rumu9t.jpg",
                          ImageUrlFirst = "https://res.cloudinary.com/dig1baxyv/image/upload/v1669233607/YogaVision/Iskra1_plspiq.jpg",
                          ImageUrlSecond = "https://res.cloudinary.com/dig1baxyv/image/upload/v1669233606/YogaVision/iskra2_wobeao.jpg",
                          ImageUrlThird = "https://res.cloudinary.com/dig1baxyv/image/upload/v1669233607/YogaVision/iskra3_syjxzm.jpg",
                          FacebookLink="https://www.facebook.com/uckpa"
                    },
                    new Instructor // Id = 4
                    {
                        Nickname = "Мукти",
                         FirstName = "Вяра",
                         LastName = "Бакърджиева",
                         Description = "Запознанство ми с йога започва през 2013г. През годините тя бе вдъхнала в мен сила и дух.\r\nОт 2018г започнах да се занимавам с йога по Айенгар.\r\nТочна, красива, изисква подравняване на тялото, което развива ума, работи върху гъвкавостта и силата едновременно. С благодарност осъзнавам, че тази йога е едно ценно богатство и всяко усилие да напредваш в нея си заслужава.",
                          ImageUrl = "https://res.cloudinary.com/dig1baxyv/image/upload/v1668946767/YogaVision/mukti_zs4t6l.jpg",
                          ImageUrlFirst = "https://res.cloudinary.com/dig1baxyv/image/upload/v1668946767/YogaVision/mukti_zs4t6l.jpg",
                          ImageUrlSecond = "https://res.cloudinary.com/dig1baxyv/image/upload/v1668946767/YogaVision/mukti_zs4t6l.jpg",
                          ImageUrlThird = "https://res.cloudinary.com/dig1baxyv/image/upload/v1668946767/YogaVision/mukti_zs4t6l.jpg",
                          FacebookLink = "https://www.facebook.com/vera.bakardjieva"
                    },
                     new Instructor // Id = 5
                    {
                        Nickname = "Сита",
                         FirstName = "Виктория",
                         LastName = "Димитрова",
                         Description = "Запознанство ми с йога започва през 2013г. През годините тя бе вдъхнала в мен сила и дух.\r\nОт 2018г започнах да се занимавам с йога по Айенгар.\r\nТочна, красива, изисква подравняване на тялото, което развива ума, работи върху гъвкавостта и силата едновременно. С благодарност осъзнавам, че тази йога е едно ценно богатство и всяко усилие да напредваш в нея си заслужава.",
                          ImageUrl = "https://res.cloudinary.com/dig1baxyv/image/upload/v1668947613/YogaVision/Sita_ruvelo.jpg",
                            ImageUrlFirst = "https://res.cloudinary.com/dig1baxyv/image/upload/v1668947613/YogaVision/Sita_ruvelo.jpg",
                              ImageUrlSecond = "https://res.cloudinary.com/dig1baxyv/image/upload/v1668947613/YogaVision/Sita_ruvelo.jpg",
                                ImageUrlThird = "https://res.cloudinary.com/dig1baxyv/image/upload/v1668947613/YogaVision/Sita_ruvelo.jpg",
                         FacebookLink ="https://www.facebook.com/viktoria.dimitrova.5070"
                    },




                };

            // Need them in particular order
            foreach (var instructor in instructors)
            {
                await dbContext.AddAsync(instructor);
                await dbContext.SaveChangesAsync();
            }
        }



    }
}
