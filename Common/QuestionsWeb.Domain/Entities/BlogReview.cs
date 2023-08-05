namespace QuestionsWeb.Domain.Entities;

public class BlogReview : Review
{
    public BlogPost Post { get; set; } = null!;
}