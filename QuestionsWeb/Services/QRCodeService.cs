using QRCoder;
using QuestionsWeb.Services.Interfaces;

namespace QuestionsWeb.Services;

public class QRCodeService : IQRCodeService
{
    public byte[] GetCodePNG(string message)
    {
        var generator = new QRCodeGenerator();

        var data = generator.CreateQrCode(message, QRCodeGenerator.ECCLevel.Q);
        var code = new PngByteQRCode(data);

        var bytes = code.GetGraphic(20);

        return bytes;
    }
}
