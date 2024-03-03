namespace ET
{
    public class AccountSessionComponentDestroySystem: DestroySystem<AccountSessionComponent>
    {
        public override void Destroy(AccountSessionComponent self)
        {
            self.AccountSessionDictionary.Clear();
        }
        
    }
    
    [FriendClass(typeof(AccountSessionComponent))]
    public static class AccountSessionComponentSystem
    {
        public static long Get(this AccountSessionComponent self, long accountId)
        {
            if (!self.AccountSessionDictionary.TryGetValue(accountId, out long instanceId))
            {
                return 0;
            }

            return instanceId;
        }

        public static void Add(this AccountSessionComponent self, long accountId, long instanceId)
        {
            if (self.AccountSessionDictionary.ContainsKey(accountId))
            {
                self.AccountSessionDictionary[accountId] = instanceId;
                return;
            }
            self.AccountSessionDictionary.Add(accountId, instanceId);
        }

        public static void Remove(this AccountSessionComponent self, long accoundId)
        {
            if (self.AccountSessionDictionary.ContainsKey(accoundId))
            {
                self.AccountSessionDictionary.Remove(accoundId);
            }
        }
        
    }
}