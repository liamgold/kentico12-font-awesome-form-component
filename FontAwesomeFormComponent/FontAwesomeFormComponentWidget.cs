using Kentico.PageBuilder.Web.Mvc;
using NetC.FontAwesomeFormComponent.Kentico.MVC;

// Registers the Widget, pointing to the View that is actually compiled and located in the FontAwesomeFormComponent.View project.
[assembly: RegisterWidget("NetC.FontAwesomeFormComponent", "Sample widget", typeof(FontAwesomeFormComponentWidgetModel), customViewName: "Widgets/_FontAwesomeFormComponent")]

// FOR TESTING
// You can change the registration to point to a local View (non compiled) in order to debug.  
// This particular view is on my MVC Project, NOT my compiled FontAwesomeFormComponent.View project
//[assembly: RegisterWidget("NetC.FontAwesomeFormComponent", "Sample widget", typeof(FontAwesomeFormComponentWidgetModel), customViewName: "Widgets/_FontAwesomeFormComponent_Test")]
