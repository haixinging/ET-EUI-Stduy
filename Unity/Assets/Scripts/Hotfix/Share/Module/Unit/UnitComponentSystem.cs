namespace ET
{
	[FriendOf(typeof(UnitComponent))]
	public static partial class UnitComponentSystem
	{
		public static void Add(this UnitComponent self, Unit unit)
		{
			self.CurrentUnitId = unit.Id;
		}

		public static Unit Get(this UnitComponent self, long id)
		{
			Unit unit = self.GetChild<Unit>(id);
			return unit;
		}

		public static void Remove(this UnitComponent self, long id)
		{
			Unit unit = self.GetChild<Unit>(id);
			unit?.Dispose();
		}
	}
}