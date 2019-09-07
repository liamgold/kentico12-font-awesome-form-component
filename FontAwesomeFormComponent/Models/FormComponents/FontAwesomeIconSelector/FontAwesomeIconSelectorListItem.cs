namespace NetC.FontAwesomeFormComponent.Kentico.MVC
{
    public class FontAwesomeIconSelectorListItem
    {
        public FontAwesomeIconSelectorListItem(string label, string name, string style)
        {
            _label = label;
            _name = name;
            _style = style;
        }

        private readonly string _name;
        private readonly string _label;
        private readonly string _style;
        public string DisplayName => $"{_label} ({_style})";
        public string CssClasses => $"fa{_style[0]} fa-{_name}";
    }
}