namespace GameMaker.Core.Runtime
{
    public class BundleGateway
    {
        private static BundleRuntimeDataManager _manager;
        internal static BundleRuntimeDataManager Manager => _manager;
        internal static void Initialize(BundleRuntimeDataManager manager)
        {
            _manager = manager;
        }
    }
}