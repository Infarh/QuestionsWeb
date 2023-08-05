using Microsoft.AspNetCore.Mvc;

using QuestionsWeb.Services.Interfaces;

namespace QuestionsWeb.Controllers;

public class QRController : Controller
{
    private readonly IQRCodeService _CodeService;
    private readonly ILogger<QRController> _Logger;

    public QRController(IQRCodeService CodeService, ILogger<QRController> Logger)
    {
        _CodeService = CodeService;
        _Logger = Logger;
    }

    public IActionResult Code(string str)
    {
        var bytes = _CodeService.GetCodePNG(str);

        return File(bytes, "image/png");
    }
}
