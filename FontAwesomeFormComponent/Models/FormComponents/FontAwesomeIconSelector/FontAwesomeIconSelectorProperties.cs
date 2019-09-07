using CMS.DataEngine;
using Kentico.Forms.Web.Mvc;

namespace NetC.FontAwesomeFormComponent.Kentico.MVC
{
    public class FontAwesomeIconSelectorProperties : FormComponentProperties<string>
    {
        public FontAwesomeIconSelectorProperties() : base(FieldDataType.Text)
        {
        }

        [DefaultValueEditingComponent(TextInputComponent.IDENTIFIER)]
        public override string DefaultValue { get; set; }
    }
}