namespace NetC.FontAwesomeFormComponent.Kentico.MVC
{
    public class FontAwesomeIcon
    {
        public string[] Changes { get; set; }
        public object[] Ligatures { get; set; }
        public Search Search { get; set; }
        public string[] Styles { get; set; }
        public string Unicode { get; set; }
        public string Label { get; set; }
        public bool Voted { get; set; }
        public Svg Svg { get; set; }
        public string[] Free { get; set; }
    }

    public class Search
    {
        public string[] Terms { get; set; }
    }

    public class Svg
    {
        public Brands Brands { get; set; }
    }

    public class Brands
    {
        public long Last_modified { get; set; }
        public string Raw { get; set; }
        public string[] ViewBox { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Path { get; set; }
    }
}