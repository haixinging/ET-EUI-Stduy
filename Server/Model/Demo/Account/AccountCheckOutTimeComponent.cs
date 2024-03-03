namespace ET
{
    [ComponentOf(typeof(Session))]
    public class AccountCheckOutTimeComponent : Entity, IAwake<long>, IDestroy
    {
        public long Timer;
        public long AccountId { get; set; }
    }
}