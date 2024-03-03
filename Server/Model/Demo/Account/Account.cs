// ReSharper disable All
namespace ET
{
    public enum AccountTYpe
    {
        General = 0,
        
        BlackList = 1,
    }
    
    [ComponentOf(typeof(Session))]
    public class Account : Entity, IAwake
    {
        public string AccountName;

        public string Password;

        public long CreateTime;

        public int AccountType;
    }
}