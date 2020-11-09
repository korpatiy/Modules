namespace MainApp
{
    public class Plugin
    {
        public LoadMode mode { get; set; } = LoadMode.Auto;
        public string name { get; set; }
        public string author { get; set; }

        public Plugin()
        {

        }

        public Plugin(string name, string author)
        {
            this.name = name;
            this.author = author;
        }
    }
}