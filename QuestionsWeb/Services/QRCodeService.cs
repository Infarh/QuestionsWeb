using QRCoder;
using QuestionsWeb.Services.Interfaces;

namespace QuestionsWeb.Services;

public class QRCodeService : IQRCodeService
{
    private readonly QRCodeGenerator _Generator;

    public QRCodeService(QRCodeGenerator Generator)
    {
        _Generator = Generator;
    }

    public byte[] GetCodePNG(string message)
    {
        //var generator = new QRCodeGenerator();

        var data = _Generator.CreateQrCode(message, QRCodeGenerator.ECCLevel.Q);
        var code = new PngByteQRCode(data);

        var bytes = code.GetGraphic(20);

        return bytes;
    }
}
