namespace QuestionsWeb.Services.Interfaces;

public interface IQRCodeService
{
    byte[] GetCodePNG(string message);
}
