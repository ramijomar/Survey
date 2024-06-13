namespace Survey.Configurations.Shared
{
    public class ConnectionsStringConfiguration
    {
        public static string SectionName => "connectionsStringConfiguration";
        public string ConnectionString { get; set; }
    }
}
