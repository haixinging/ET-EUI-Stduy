namespace ET
{
    public enum ServerStatus
    {
        Normal = 0,
        Stop   = 1,
    }
    
    public class ServerInfo : Entity, IAwake
    {
        public int Status { get; set; }
        public string ServerName { get; set; }
    }
}