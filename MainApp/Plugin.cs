namespace MainApp
{
    public class Plugin
    {
        public LoadMode Mode { get; set; } = LoadMode.Auto;
        public string Name { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public Plugin()
        {

        }

        public Plugin(string name, string author, string version)
        {
            this.Name = name;
            this.Author = author;
            this.Version = version;
        }
    }
}