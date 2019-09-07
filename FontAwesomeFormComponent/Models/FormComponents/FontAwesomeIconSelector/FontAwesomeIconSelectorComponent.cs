using Kentico.Forms.Web.Mvc;
using NetC.FontAwesomeFormComponent.Kentico.MVC;

[assembly: RegisterFormComponent(FontAwesomeIconSelectorComponent.IDENTIFIER, typeof(FontAwesomeIconSelectorComponent), "FontAwesome icon selector", IsAvailableInFormBuilderEditor = false, ViewName = "FormComponents/_FontAwesomeIconSelector")]
namespace NetC.FontAwesomeFormComponent.Kentico.MVC
{
    /// <summary>
    /// Represents a FontAwesome icon selector
    /// </summary>
    public class FontAwesomeIconSelectorComponent : FormComponent<FontAwesomeIconSelectorProperties, string>
    {
        public const string IDENTIFIER = "FontAwesomeIconSelector";

        [BindableProperty]
        public string Value { get; set; }

        public override string GetValue()
        {
            return Value;
        }

        public override void SetValue(string value)
        {
            Value = value;
        }
    }
}