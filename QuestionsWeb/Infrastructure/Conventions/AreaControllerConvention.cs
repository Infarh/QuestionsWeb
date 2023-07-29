using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace QuestionsWeb.Infrastructure.Conventions;

public class AreaControllerConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        //if (controller.ControllerName == "Account")
        //{
        //    var login_action = controller.Actions.First(a => a.ActionName == "Login");
        //    controller.Actions.Remove(login_action);
        //}

        var type_namespace = controller.ControllerType.Namespace;

        if (type_namespace.StartsWith("QuestionsWeb.Areas"))
        {
            var namespace_elements = type_namespace.Split('.');

            var area_name = namespace_elements[2];

            if (string.IsNullOrWhiteSpace(area_name))
                return;

            if (controller.Attributes.OfType<AreaAttribute>().Any(a => a.RouteKey == "area" && a.RouteValue == area_name))
                return;

            controller.RouteValues["area"] = area_name;
        }
    }
}
