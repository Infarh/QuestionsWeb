using QuestionsWeb.DAL.Context;

namespace QuestionsWeb.Services;

public class QuestionDBInitializer
{
    private readonly QuestionsDB _DB;
    private readonly ILogger<QuestionDBInitializer> _Logger;

    public QuestionDBInitializer(QuestionsDB db, ILogger<QuestionDBInitializer> Logger)
    {
        _DB = db;
        _Logger = Logger;
    }

    public async Task InitializeAsync()
    {

    }
}
