﻿namespace YogaVision.Infrastructure.Data.Seeding.CustomSeeders
{
    using YogaVision.Data;
    using YogaVision.Infrastructure.Data.Models;
    
    public class FoodRecepesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.FoodRecipes.Any())
            {
                return;
            }
            var foodRecipes = new FoodRecipe[]
            {
                new FoodRecipe() //id 1
                { 
                     Author = "Вера Бакърджиева",
                      Title = "ПОСТЕН КЕКС С ТИКВА И СУШЕНИ ПЛОДОВЕ",
                       RequiredProducts ="- брашно 3 чаени чаши\r\n- вода 1 чаена чаша\r\n- тиква 2 чаени чаши\r\n- олио 1/2 чаена чаша\r\n- захар 1 чаена чаша\r\n- сушени плодове 1 кафена чаша\r\n- орехи 1 кафена чаша\r\n- канела 1 чаена лъжица\r\n- бакпулвер 1 пакетче\r\n- сода за хляб 1/2 чаена лъжица",
                       Content = "В съвременния свят хората най-често постят, за да свалят някое друго килце и да прочистят организма си преди Коледа. Това означава, че възприемат постите като диета, което пък автоматично означава, че постите будят не особено приятни емоции. Независимо каква е причината за постенето това не е правилното отношение, най-малкото защото и постните ястия могат да бъдат много вкусни и да станат част от ежедневното менюто на всеки за цялата година. Това в пълна сила важи и за постните сладкиши. За печената пълнена тиква, печените пълнени ябълки, баницата с ябълки и баницата с тиква е известно колко са вкусни. Но и кексът може да бъде постен! И за голяма изненада постният кекс е не по-малко вкусен! Рецептата за постен кекс с тиква и сушени плодове е подходяща за периода на постите, подходяща е и за трапезата на Бъдни вечер. Добавените канела и сушени плодове придават на постния кекс с тиква и сушени плодове невероятен аромат на домашен празничен уют. Затова и ако приготвите веднъж постния кекс с тиква и сушени плодове той гарантирано ще се превърне в един от любимите ви зимни десерти!\r\nРецептата за постен кекс с тиква и сушени плодове в три стъпки:\r\nПървата стъпка от рецептата за постен кекс с тиква и сушени плодове е подготовката на продуктите. Почистете и настържете тиквата, пресейте брашното, заедно с бакпулвера и содата и ги оставете на страна.\r\nС помощта на миксер, или тел, или просто с вилица разбийте течните съставки и захарта, след което малко по малко при непрекъснато разбиване добавете брашнената смес. След като се е получила хомогенна смес добавете орехите, настърганата тиква и нарязаните на дребно сушени плодове. Може да ползвате всякакви сушени плодове – стафиди, смокини, кайсии, сини сливи, даже и фурми. Разбъркайте добре сместа, така че плодовете и тиквата да се разпределят равномерно, а не само в едната част на постния кекс с тиква и сушени плодове.\r\nНамажете формата за кекс с малко олио и изсипете сместа за постния кекс във формата. Печете кекса в предварително загрята на 180 градуса фурна за около 45 минути. За да сте сигурни, че вашият постен кекс с тиква и сушени плодове е изпечен го бучнете с клечка за зъби, ако остане суха, то значи е готов. След като го извадите от фурната и изстине, може да го поръсите с пудра захар. Имайте предвид, че преди да го поръсите с пудра захар трябва задължително да е изстинал, защото в противен случай захарта ще попие в кекса.",
                        ImageUrl = "https://res.cloudinary.com/dig1baxyv/image/upload/v1670237780/FoodRecipes/posten_keks_qf7osw.jpg",
                },
                 new FoodRecipe() //id 2
                 {
                    Author = "Вера Бакърджиева",
                    Title = "ТИКВЕНИК - БАНИЦА С ТИКВА",
                     RequiredProducts ="-точени кори 400 грама\r\n-тиква 1,2 кг\r\n-захар 1 чаена чаша\r\n-стафиди 1/2 чаена чаша\r\n-орехи 1 1/2 чаена чаша -1/2 чаена чаша смлени и 1 чаена чаша накълцани\r\n-олио 1 кафена чаша\r\n-канела 1/2 чаена лъжица\r\n-пудра захар 1/2 чаена чаша",
                     Content ="Ако говорим за истински български  десерти, то крем карамелът и млякото с ориз трябва да отпаднат и списъкът да стане съвсем късичък – само различни вариации на тема сладка баница, като сиропирана баница с локум, баница с ябълки и баница с тиква. Баницата с тиква, известна и като тиквеник е едно истинско зимно изкушение. Тиквеникът е задължителен за трапезата на Бъдни вечер, той е и много подходящ за постещите по време на Коледните пости. И въпреки, че в България се произвеждат и хапват толкова много тикви, тиквеникът и печената тиква са може би двете най-популярни рецепти за използването на тиквата в кухнята. Баницата с тиква става най-вкусна с домашно точени кори, но точенето на кори си е сложна процедура изискваща доста време и още повече умения. Затова предложената тук рецепта за тиквеник е за тиквеник с готови кори. Ако обаче умеете да точите използвайте плънката от рецептата, така вашият тиквеник ще стане още по-вкусен.\r\n\r\nПървата стъпка от рецептата за тиквеник е подготовката на тиквата. Обелвате и нарязвате тиквата на парчета, след което я настъргвате. Изсипвате тиквата в тенджера, добавяте олиото и захарта и задушавате, докато водата на тиквата поизври и се получи гъста каша. Добавяте и орехите, канелата и стафидите и слагате сместа на страна, за да поизстине.\r\nСлед като  тиквената смес е поизстинала разтваряте пакета кори, намазвате кората леко с олио и в тесния ѝ край слагате от сместа, след което навивате на руло и поставяте рулото в тавата. Редите тиквеника от стените към вътрешността на тавата. Ако ползвате по-фини кори, то ползвайте по две, а не по една, за да не се накъсат при завиване. Повторете процедурата за навиването на рулцата докато свършат корите и сместа. Накрая намажете баницата с олио.\r\nТиквеникът  с готови кори се пече в предварително загрята на 180 градуса фурна, докато се зачерви, за което са му необходими около 50 минути. След като е готов го извадете от фурната и го изчакайте да изстине. Изстиналият тиквеник поръсете с пудра захар.", 
                     ImageUrl = "https://res.cloudinary.com/dig1baxyv/image/upload/v1670238058/FoodRecipes/tikvenik_cu8qpj.jpg",
                 },
                   new FoodRecipe() //id 3
                   { 
                        Author ="Цвети Горанова",
                        Title = "ПОСТНИ ПЪЛНЕНИ ЧУШКИ С БУЛГУР",
                        RequiredProducts = "- сушени чушки 10 броя\r\n- булгур 1 чаена чаша\r\n- лук 2 глави\r\n- олио 1/3 чаена чаша\r\n- джоджен 1 чаена лъжица\r\n- алуминиево фолио Fino",
                        Content ="Много хора считат, че за приготвянето на вкусно ястие задължително е нужно да се използва месо. Няма ли месце и ястието не би могло да бъде достатъчно вкусно или просто влиза в ролята на гарнитура. Рецептата за постни пълнени чушки е поредната рецепта, която развенчава тези митове. Задушени под алуминиевото фолио Fino, а впоследствие леко запечени, пълнените чушки с булгур са вкусно предложение за менюто за Бъдни вечер, което се приготвя бързо и лесно.\r\n\r\nПървата стъпка от рецептата за постни пълнени чушки с булгур е подготовката на чушките. Най-добре е да се ползват сушени чушки. Заливате ги с вряла вода и ги оставяте за около 5 минути, за да омекнат. Междувременно нарязвате на ситно лука, и го задушавате в олиото. Добавяте и измития и отцеден от водата булгур и разбърквате добре. Добавяте още ½ чаена лъжица сол, както и джоджена.\r\nСлед като плънката е готова, пълните с нея омекналите чушки и ги нареждате в намазана с олио тава. Наливате 1 ½ чаена чаша вода, покривате тавата плътно с алунимиево  фолио Fino и печете в предварително загрята на 180 градуса фурна за около 40 минути, за да се задушат добре. След това махате фолиото и печете още около 5 минути.",
                        ImageUrl = "https://res.cloudinary.com/dig1baxyv/image/upload/v1670238223/FoodRecipes/chushki_klrkzm.jpg",
                   },
                   new FoodRecipe() //id 4
                   {
                        Author ="Цвети Горанова",
                        Title = "КЕТО ЧИЙЗКЕЙК БЕЗ ПЕЧЕНЕ",
                        RequiredProducts = "За блата\r\n-кокосово брашно 1 1/2 чаени чаши\r\n-какао 1/2 чаена чаша\r\n-краве масло 1/2 чаена чаша\r\nЗа крема\r\n-заквасена сметана 800 грама\r\n-маскарпоне 200 грама\r\n-еритритол 1 чаена чаша\r\n-ванилии 1 брой\r\n-желатин 25 грама\r\nЗа плодовата смес\r\n-плодове 500 грама\r\n-лимон 1/2 брой\r\n-еритритол 1/3 чаена чаша\r\n-желатин 5 грама",
                        Content ="Класическият чийзкейк е добре познат и категорично любим. Класическият чийзкейк се приготвя с крема сирене и задължително се пече. Но има много рецепти за чийзкейк,които се различават съществено от основната рецепта. Някои от тях са без печене, други са без захар, има рецепти за чийзкейк без яйца, други пък са кето, а има и рецепти за чийзкейк, които съчетават всички тези условия, точно като настоящата рецепта за кето чийзкейк без печене. Истината е, че приготвяйки чийзкейк по рецептата за кето чийзкейк без печене получаваме един изключително вкусен сладкиш, който обаче има общо с истинския чийзкейк най-вече на външен вид. Да, един различен чийзкейк, който обаче е не само вкусен, а и много летен, много лек и много свеж.\r\nПървата стъпка от рецептата за кето чийзкейк без печене е подготовката за блата. Смесвате кокосовото брашно, заедно какаото и разбърквате добре, след което добавяте и разтопеното маслото и бъркате, най-добре с ръка, до получаване на тесто. На дъното на форма с падащи стени слагате хартия за печене, след което разпределяте кокосовото тесто равномерно и притискате с ръце. Докато приготвяте крема за кето чийзкейк, прибирате формата с блата в хладилника.\r\nВ малка чаша със студена вода добавяте желатина и го оставяте да набъбне. След като набъбне сложете чашата в малка тенджерка с вода на котлона, за да се разтопи желатина на водна баня. Междувременно с помощта на миксер разбийте заквасената сметана, заедно с маскарпонето, еритритола и ванилията до хомогенна смес. След това на тънка струйка при непрекъснато разбиване добавете към тази смес и разтопения желатин. След това изсипете крема върху блата и веднага приберете в хладилник.\r\nСлед около час-два пригответе и последната част от сладкиша. Може да ползвате любими за вас сезонни плодове. Междувременно разтопете желатина следвайки инструкциите на опаковката. Почистете плодовете, нарежете ги на средно големи парченца и добавете към тях лимоновия сок, еритритола заедно с ⅓ чаена чаша вода. Свалете сместа от котлона и след като поистите добавете разтворения на водна баня желатин и разбъркайте добре.Тази смес изсипете върху чийзкейка и оставете за още 2-3 часа в хладилника.\r\n",
                        ImageUrl = "https://res.cloudinary.com/dig1baxyv/image/upload/v1670238712/FoodRecipes/cheesecake_lictnf.jpg",
                   },
                    new FoodRecipe() //id 5
                   {
                        Author ="Цвети Горанова",
                        Title = "ВЕГАН СОС БОЛОНЕЗЕ С ЛЕЩА",
                        RequiredProducts = "-леща 1 чаена чаша\r\n-добруджанска леща Статев\r\n-лук 1 брой\r\n-моркови 2 броя\r\n-целина 30 грама\r\n-домати 1 кг или 5 супени лъжици доматена паста\r\n-червен пипер 1 чаена лъжица\r\n-черен пипер 1/3 чаена лъжица\r\n-дафинов лист 3 броя\r\n-олио 1/3 чаена чаша\r\n-паста 500 грама\r\n-магданоз 1/2 връзка",
                        Content ="Рецептата за сос Болонезе без месо е една истинска находка. И голяма изненада. Макар да звучи някак ексцентрично, защото за всички ни сосът Болонезе е най-популярният сос за паст с месо, веган сос Болонезе е толкова вкусен и толкова лесен за приготвяне, че очарова и по-мнителните. Да, вкусът на веган сос Болонезе се различава от класически сос Болонезе, тъй като каймата, или рагуто, с което се приготвя класиката е заменено от леща в тази рецепта, но пък резултатът е изключително вкусна комбинация от вкусове и аромати. Подходяща за веган меню, но също и за всеки, който обича разнообразието в кухнята, рецептата за веган сос Болонезе с леща има място на всяка трапеза.\r\nПървата стъпка от рецептата за веган сос Болонезе с леща е подготовката на лещатата. Избирате качествена леща, която се сварява добре, като Добруджанска леща Статев. Измивате я и я сварявате до готовност. Докато лещата ври, приготвяте соса. Почиствате зеленчуците, нарязвате всички на ситно, като единият морков настъргвате. \r\nВ дълбок тиган или тенджера изсипвате олиото и след като се сгорещи, добавяте приготвените лук, моркови и целина. След като поомекнат, добавяте и нарязаните на ситно домати. Ако ползвате пресни домати е добре да ги обелите предварително. Добавяте ½ чаена лъжица сол, червения, черния пипер и дафиновия лист, и оставяте да ври на слаб огън, като разбърквате от време на време. В случай, че ползва доматена паста, която е гъста, то добавете и ½ чаена чаша вода.\r\nСлед като лещата е сварена, отцедете от водата и я добавете към доматения сос, за да поври още 5-10 минути. През това време пригответе и пастата в подсолена вода, като следвате инструкциите за варене на опаковката. След като пастата е готова, разпределете я в чинии, добавете от веган соса Болонезе с леща върху всяка порция и поръсете със ситно нарязан магданоз.\r\n",
                        ImageUrl = "https://res.cloudinary.com/dig1baxyv/image/upload/v1670239405/FoodRecipes/leshta_rs4sqd.jpg",
                   },

    };
            foreach (var foodRecipe in foodRecipes)
            {
                await dbContext.AddAsync(foodRecipe);
                await dbContext.SaveChangesAsync();
            }

        }
    }
}