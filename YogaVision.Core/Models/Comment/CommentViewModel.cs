namespace YogaVision.Core.Models.Comment
{
    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Models;
    public  class CommentViewModel :IMapFrom<Comment>
    {
        public DateTime CreatedOn { get; set; }
        public string Content { get; set; }
        public string ApplicationUserUserName { get; set; }


    }
}
