﻿
namespace YogaVision.Infrastructure.Data.Seeding.CustomSeeders
{

    using YogaVision.Data;
    using YogaVision.Infrastructure.Data.Models;
    public class BlogPostsSeeder :ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.BlogPosts.Any())
            {
                return;
            }
            var blogPosts = new BlogPost[]
            {
                 new BlogPost  // Id = 1
                 { 
                       Title = "Д-р Светла Балтова ще изнесе лекция във Велико Търново с астрологична прогноза за 2023 (ПОКАНА)",
                       Author = "Светла Балтова",
                       ShortContent ="Д-р Светла Балтова ще представи астрологична прогноза за 2023 г. от гледна точка на древното познание, езотериката и учението на Учителя Беинса Дуно. Събитието ще се проведе на 3-и Декември (събота) от 11.00ч. в Изложбен комплекс \"Рафаел Михайлов\" във Велико Търново.",
                       Content = "Д-р Светла Балтова ще представи астрологична прогноза за 2023 г. от гледна точка на древното познание, езотериката и учението на Учителя Беинса Дуно. Събитието ще се проведе на 3-и Декември (събота) от 11.00ч. в Изложбен комплекс \"Рафаел Михайлов\" във Велико Търново.\r\n\r\nД-р Балтова споделя:\r\n\"Намираме се в повратна част на цикъла, който започна в края на 2019-та и началото на 2020-та година. Тази година ще бъде година на разместване на пластовете - във всякакъв план: в социален план - особено по отношение на политически формирования, големи финансови структури, големи международни организации. Възможно е в природен план да има също разместване на пластовете.\"\r\n\r\nХаосът в езотериката, обаче винаги е свързан с Раждането на нещо Ново. Да, на Нова Вселена. В Хаоса се Ражда Нова Вселена. И всъщност започва нещо Ново. Така ще бъде и през 2023 година.",
                        ImageUrl = "https://res.cloudinary.com/dig1baxyv/image/upload/v1669927098/BlogPosts/astrologichna-prognoza-2023-14529_j0fsgh.jpg",
                         Tags = new List<TagBlogPost>(){ new TagBlogPost { TagId = 12}, new TagBlogPost { TagId = 13 }, new TagBlogPost { TagId = 14 } },
                 },
                  new BlogPost  // Id = 2
                 {
                       Title = "Веселин Орешков: Няма друга държава в света, която да граничи със собствените си граници",
                       Author = "Веселин Орешков",
                       ShortContent ="Няма друга държава в света, където да граничи със собствените си граници. На нас не ни е дадено да се разширяваме, да се проливаме със собствените си граници. Обаче, Невидимият свят нас ни е сложил на грънчарското колело и като сложиш топката тук отдолу и грънчарят като си намокри ръчичките с водичката…и почва да източва глината.",
                       Content = "Вижте какво, не случайно за тази територия тука - България на Балканите... - знаете ли колко си точат зъбите? Да ни няма, и тук…те да са. Обаче, още ни държи Небето тука.Няма друга държава в света, където да граничи със собствените си граници. На нас не ни е дадено да се разширяваме, да се проливаме със собствените си граници. Обаче, Невидимият свят нас ни е сложил на грънчарското колело и като сложиш топката тук отдолу и грънчарят като си намокри ръчичките с водичката…и почва да източва глината.Българинът като качество е приспособим към най-невероятни условия, защото е научен да мисли. Туй говоря, за който е истински българин, а не само по лична карта. Личната карта - могат да издадат на толкова…, но зад понятието “българин” трябва да отговарят определени качества, иначе само по паспорта му е написано.Има доста неща върху, които да се замислим, с които да сме подготвени да посрещнем натиска, който ще бъде оказан върху нас. Защото ние живеем винаги с едно от най-ниските съзнания - сигурност. Да се подготвим да посрещнем събитията, които сами сме ги докарали до този ред. Във всяко едно отношение - физическо, психическо и емоционално трябва да се подготвим. Защо? На всеки натиск отвън, трябва да има напомпана пружина да издържи.Всяко действие има противодействие. То е физичен закон. Онова, което ке ни дойде въз главите, ако не можем да издържим ще ни сплещи, а ако можем - ще издържим. ",
                        ImageUrl = "https://res.cloudinary.com/dig1baxyv/image/upload/v1669928736/BlogPosts/oreshkov_i3veal.jpg",
                         Tags = new List<TagBlogPost>(){ new TagBlogPost { TagId = 15}, new TagBlogPost { TagId = 5}},
                 },
                  new BlogPost  // Id = 3
                  { 
                        Title = "Елеазар: Днес всяко слово трябва да бъде разбрано с ново съзнание, защото в традицията словото се превръща в застой",
                        Author = "Елиазар Хараш",
                        ImageUrl ="https://res.cloudinary.com/dig1baxyv/image/upload/v1669660911/images/sgkvkidgeptnwvwcrrrf.jpg",
                        ShortContent = "Устремът на ученика към Истината е необходим процес. Този устрем е чист пламък, чист огън. Това е най-красивото явление в живота на земята. В миналото е имало определени учители, чието слово е било подходящо за дадената епоха. В днешно време става голяма среща на всички учения от всички времена.",
                        Content = "Устремът на ученика към Истината е необходим процес. Този устрем е чист пламък, чист огън. Това е най-красивото явление в живота на земята. В миналото е имало определени учители, чието слово е било подходящо за дадената епоха. В днешно време става голяма среща на всички учения от всички времена. Защо? За да може всеки човек да намери и опази светлината през вековете, която го е докоснала тогава. Това е целта, за да може и днес, чрез тази светлина да се възроди в него Божественият път. За днешно време всяко свещено слово, всеки свещен Учител и всяко учение са на мястото си. И днес всички тези учители, мъдреци се срещат на земята, за да се обединят и да изведат земята към новото.\r\n\r\nВажно: Днес всяко слово трябва да бъде разбрано с ново съзнание, не както е говорено в миналото. Защото опасността е голяма – да не заживее миналото на учението, т.е. традицията. Учението трябва да се разбере по нов начин, с ново, свежо разбиране. Иначе учението ще стане традиция.\r\n\r\nСпоред Кабала традицията означава застой, самоубийство, т.е. суета. Всяко учение си има своето обновление, свое ново лице, свой нов израз. В традицията словото се превръща в знание и смърт. Обяснение: Пътят, или Божественият път, е сроден с Истината, но те се различават. Пътят е нещо, което постоянно съществува. ИСТИНАТА Е НЕЩО, КОЕТО ПОСТОЯННО СЕ РАЖДА.\r\n\r\nИстината винаги има ново лице. Когато Истината те докосне, ти винаги виждаш в себе си Пътя по нов начин (това важи за всяко прераждане), с ново разбиране, с нова дълбочина.\r\n\r\nАко Истината не те докосне, ти оставаш в традицията, в застоя, в ритуалите и в безкрайните игри на ума. Нещастието на хората стои в това, че те изпускат Истината, която постоянно се ражда и която е винаги нова. Истината е мистерия за самия Бог. Учителят казва: За нея ще има специална епоха.\r\n\r\nУчителят: Истината е тоталното Нищо. Например съществуват Любовта и Мъдростта, но Истината не съществува. Обяснение: съществуват майката и бащата, но Синът не съществува – той вечно се ражда. Той винаги е нов. Ето красотата на Нищото, на дълбокото в живота.\r\n\r\nУчението на Учителя е нещо много дълбоко и особено. Особеното е в това, че то не съществува реално, то винаги ще се видоизменя. Това, което съществува реално, е животът в Духа. Духът не е обвързан с учение и наука. Той е вечна и пълна любов и вечно се обновява. Когато говорим за любовта на Духа, (не любовта на духовете), тази любов не се усъвършенства, защото тя е нещо тотално, цялостно, тя само се проявява. Няма нужда от усъвършенстване, тя е въпрос на проява и дълбоко разбиране. В Нищото е скрита Истината, която е родена преди всеки учител и преди всяко учение. В тайната на Нищото няма постижения, няма какво да се постига. Ако ти мислиш нещо да постигаш, се отклоняваш от своята природа, защото НИЩОТО Е ПЪЛНОТА БЕЗ ПОСТИЖЕНИЯ и това е тайната на живота.\r\n\r\nТова означава, че Нищото е най-големият враг на Антихриста и на злото, защото в Нищото единството е пълно, а постиженията принадлежат само на Бога, те са дарове. Това означава, че човек не може да ги постигне; дарбите, постиженията не са на човека. Човек може да се слее с тях, те се дават, но не се постигат. Ако няма вдъхновение, няма дарба. Разликата между поета и мистика е: истинският мистик живее в сърцето на Духа. Ако поетите вместо мечтатели станат мистици, постигат поезията на Духа.",
                        Tags = new List<TagBlogPost>(){ new TagBlogPost { TagId = 1}, new TagBlogPost { TagId = 2}, new TagBlogPost { TagId = 5 } }
                  },
                    new BlogPost  // Id = 4
                    {
                       Title ="Перица Георгиев-Кану: Бог общува с нас през Детето, което е в Чистото Сърце. Тук е Порталът",
                       Author = "Перица Георгиев-Кану",
                       ImageUrl ="https://res.cloudinary.com/dig1baxyv/image/upload/v1669931824/images/kanu_r9thwz.jpg",
                       ShortContent = "Да! Детето е нашата Невинност, която не е изчезнала. Изчезнала е при много хора, обаче не при всички. А и при тези, при които е изчезнала – не е изчезнала, защото винаги може да се върнат към своята Невинност, в Сърцето. С детското, ние всъщност…",
                       Content = "Здравейте, Перица Георгиев!\r\n\r\nМного се радвам, че именно в деня на детето (1-ви Юни) ще говорим с вас за това, колко е важно да възродим детето в себе си.\r\n\r\nДа! Детето е нашата Невинност, която не е изчезнала. Изчезнала е при много хора, обаче не при всички. А и при тези, при които е изчезнала – не е изчезнала, защото винаги може да се върнат към своята Невинност, в Сърцето. С детското, ние всъщност…\r\n\r\nДетската Невинност е нещо по-дълбоко, от колкото можем да се замислим с умът.\r\n\r\nТо е едно Божествено Присъствие в нас, в същност – тази Детска Невинност.\r\n\r\nТо е даже… в едни има концепция – Шива Боленаат (Bholenath) – Шива Невинният.\r\n\r\nБог като Невинен, Абсолютно Невинен, Чист, Девствен, Детски.\r\n\r\nИ тази „Детскост“, тази Невинност, тази Чистота Е в Сърцето.\r\n\r\nИ с тази Невинност, всъщност се събуждаме за това…\r\n\r\nТози външен човек, който е на 20-30-50 години – той е служител на това Дете в Сърцето.\r\n\r\nТи си – Гопал даас .(Гопал или Гопала е името на детето Кришна)\r\n\r\nКришна Гопал – Го Обожават…\r\n\r\nГопал Кришна – като малък го наричат – Гопал.\r\n\r\nГопал даас – Служител на Гопал, на Детето, на Гопал, а Това Дете е в Сърцето.\r\n\r\n \r\n\r\nВ предходното ни интервю ти сподели едно изживяване за Детето вътре в Сърцето, което е…, но аз сега се сещам, че Христос не случайно казва: \"Докато не станете като децата.\"\r\n\r\nНяма друг начин да влезем в Царството Небесно.\r\n\r\nАко не сме деца, ако не сме Невинни в Сърцето.\r\n\r\nТука е нашият Вход (Сърцето), тук е Порталът – не е навън, но е в нас.\r\n\r\nИ от тука няма… няма да търсим ние, както сега – като отидем при някой портал (сме пред някоя врата).\r\n\r\nКогато се случи такова изживяване, това се случва вътре в нас, в нашето сърце.\r\n\r\nПонеже ние…, всъщност нашето сърце не го познаваме.\r\n\r\nЗащото ние не сме медитирали, не сме се запознали със собственото си сърце и с дълбочината, която (я) носим.\r\n\r\nТова мое изживяване с Детето – то беше… аз самия бях изненадан, защото мантрувах ОМ. И всеки път, когато кажех ОМ и това дете се усмихваше. С това се появи детето и започна да се радва. И се хранеше с ОМ. Самият звук ОМ беше храна за това дете. А разбрах, че досега съм го хранел с някаква неподходяща храна. Беше затрупано, все едно с макдоналдс, някаква (боклук) храна, такава [junk food]. А аз като казвах ОМ – „онова пада“ от него и то „излиза от това“… и се явява… и започва да се радва.\r\n\r\nИ то е Най-красивото Дете. Всички деца са красиви, обаче това Дете в Сърцето – То Е Божествената Красота.",
                        Tags = new List<TagBlogPost>(){ new TagBlogPost { TagId = 8}, new TagBlogPost { TagId = 10},{ new TagBlogPost { TagId = 3 } }, { new TagBlogPost { TagId = 2 } } }
                    },
                     new BlogPost  // Id = 5
                    {
                       Title ="Елеазар Хараш: Когато натрупаш много чистота и Любов, навлизаш във Висшата си душа. Тя е Акаша",
                       Author = "Елеазар Хараш",
                       ImageUrl ="https://res.cloudinary.com/dig1baxyv/image/upload/v1670170681/BlogPosts/Harash_nxis5t.jpg",
                       ShortContent = "В Акаша са скрити тайните на живота и тайните на древните думи, и тайното тълкуване на нещата. За да се проникне в Акаша се иска една много тънка енергия и позволение от Бога. “Акаша” на санскрит означава “небе”, “Етер” - древно, вибриращо тънко съзнание.",
                       Content = "ЗЗдравейте, Елеазар Хараш. Темата на днешното интервю е Акаша и в началото искам да започна със следния въпрос. Вие много често сте казвали, че ние трябва да обръщаме внимание на структурата на думите. “Акаша” е много близко до думата “Аша”, която означава “Истината”?\r\n“Истината”. Да. Персийски.\r\nКвинтесенцията Акаша е Етера и Ефира. Тези понятия се преливат. Има тънкости, ама…\r\nДревното минало на човечеството е скрито в Акаша. Не е напълно в Свещените писания, но в Акаша е напълно. Тук са скрити древните действия на Бога. Най-дълбоките истини са скрити в Акаша, която е част от Нищото и Мистерията.\r\nПарацелз казва: “Истинският човек е квинтесенция, Петия елемент, Етера, и тук той е образа и подобието на Бога”. Човекът-квинтесенция е Акаша повече от природата, той е чист Дух. Квинтесенцията е Дух. Това е качеството на нещата, тънкостта, финото.\r\nВ Акаша са скрити тайните на живота и тайните на древните думи, и тайното тълкуване на нещата. За да се проникне в Акаша се иска една много тънка енергия и позволение от Бога. “Акаша” на санскрит означава “небе”, “Етер” - древно, вибриращо тънко съзнание.\r\nАкаша е свързана с най-дълбоката мистична мъдрост, а не със знания, с информации. Акаша е квинтесенция, фина Праматерия, чисто духовна и затова тук може да се прониква само с истинската Любов, защото Тя не може да злоупотребява. Акаша е в нас, но в нашите дълбини. Тя е свръхтънко съзнание и отвъд това има нещо още по-дълбоко, което я е създало.\r\nДълбоко в Етера, в Сърцето (в нашето Сърце), царува безпределен покой. Например, Христос е Славата на Акаша, на Етера. Той е етерно Същество. Етерният свят, той е винаги лъчезарен. Парацелз казва, че петата същност в човека - Етера, е квинтесенцията. Това е подобието на Бога. И пак Парацелз: “Човекът има две тела - зримо и незримо. Зримото е образувано от четирите стихии - земя, вода, въздух и огън. Незримото е Петия елемент - квинтесенцията. Тук е истинският човек, Свободата”. Петият елемент е Божествения образ, скрит в човека. Той е над стихиите. Той може да управлява бурята и всичко подобно, както е Христос: “Богове сте”. Това е Петият елемент - Акаша, подобието. Парацелз пак казва, че Христос е Същество на Петия елемент и затова Той заповядва на бурята. Неговите ученици са Четвъртия елемент. Той ги обучава впоследствие.\r\nВие споменахте тези фундаментални елементи, а когато се говори за това, че ученикът трябва да изработи своето светлинно тяло, това ли е момента, когато има позволението да навлиза в Акаша?\r\nДа. Има позволение да навлиза в дълбините си, защото няма да злоупотребява, защото е честен към себе си, към Бога и Бог го познава. В Акаша, в тази свръхтънка Праматерия, никога няма страх и тревога. Затова Христос казва: “Моето иго е леко”. Етера… няма там тегла. Един вид “Завърнете се”.",
                        Tags = new List<TagBlogPost>(){ new TagBlogPost { TagId = 1}, new TagBlogPost { TagId = 10},{ new TagBlogPost { TagId = 5 } }, { new TagBlogPost { TagId = 16 } } }
                    },




            };




            foreach (var blogPost in blogPosts)
            {
                await dbContext.AddAsync(blogPost);
                await dbContext.SaveChangesAsync();
            }
        }



    }
}
