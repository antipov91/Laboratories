using JCMG.EntitasRedux;

namespace Laboratories.Meta
{
	public class UpdateTimeSystem : IUpdateSystem
	{
		private readonly Contexts contexts;

		public UpdateTimeSystem(Contexts contexts)
        {
            this.contexts = contexts;
        }

    	public void Update()
		{
			contexts.Meta.ManagerEntity.ReplaceDeltaTime(UnityEngine.Time.deltaTime);
		}
	}
}