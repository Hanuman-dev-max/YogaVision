namespace YogaVision.Common
{

    public static class GlobalConstants
    {
        public const string SystemName = "YogaVision";

        public const string AdministratorRoleName = "Administrator";





        public static class AccountsSeeding
        {
            public const string Password = "123456";

            public const string AdminEmail = "admin@admin.com";

            public const string UserEmail = "user@user.com";
        }

        public static class DataValidations
        {
            public const int TitleMaxLength = 150;

            public const int TitleMinLength = 5;

            public const int ContentMaxLength = 10000;

            public const int ContentMinLength = 200;

            public const int ShortContentMaxLength = 400;

            public const int ShortContentMinLength = 10;

            public const int NameMaxLength = 40;

            public const int NameMinLength = 2;

            public const int DescriptionMaxLength = 700;

            public const int DescriptionMinLength = 50;

            public const int AddressMaxLength = 100;

            public const int AddressMinLength = 5;

            public const int SeatMinLength = 1;

            public const int SeatMaxLength = 30;

            public const int FacebookLinkMaxLength = 100;

            public const int FacebookLinkMinLength = 10;

            public const int EventDescriptionMaxLength = 50;

            public const int EventDescriptionMinLength = 10;
        }

        public static class ErrorMessages
        {
            public const string Facebook = "Facebook линкът трябва да е между 10 и 60 символа";

            public const string Title = "Заглавието трябва да е между 5 и 60 символа";

            public const string Content = "Съдържанието трябва да е между 700 и 3500 ";

            public const string ShortContent = "Краткото съдържание трябва да е между 10 и 400";

            public const string Author = "Author name must be between 2 and 40 characters.";

            public const string Name = "Name must be between 2 and 40 characters.";

            public const string Description = "Description must be between 50 and 700 characters.";

            public const string Address = "Address must be between 5 and 100 characters.";

            public const string Image = "Please select a JPG, JPEG or PNG image smaller than 1MB.";

            public const string DateTime = "Please select a valid DATE and TIME from the datepicker calendar";

            public const string Rating = "Please choose a valid number of stars from 1 to 5.";
        }

        public static class DateTimeFormats
        {
            public const string DateFormat = "dd-MM-yyyy";

            public const string TimeFormat = "h:mmtt";

            public const string DateTimeFormat = "dd-MM-yyyy h:mmtt";
        }

        public static class Images
        {
            public const string Index = "https://res.cloudinary.com/dig1baxyv/image/upload/v1668750032/YogaVision/kike-vega-F2qh3yjz6Jk-unsplash_h3u7qc.jpg";

            public const string CoverBackground = "https://res.cloudinary.com/beauty-booking/image/upload/v1586874218/cover-bg_nnwh6d.jpg";

            public const string Footer = "https://res.cloudinary.com/beauty-booking/image/upload/v1586874219/footer_rvuuls.jpg";

            public const string Error404 = "https://res.cloudinary.com/beauty-booking/image/upload/v1587754604/404_mcjscs.jpg";

            public const string CloudinaryMissing = "https://res.cloudinary.com/beauty-booking/image/upload/v1587708556/cloudinary_veibtu.png";









        }
    }
}

