using GameEngine.Save;

namespace GameEngine
{
    public static class ResourcesExtensions
    {
        public static void Setup(this Resource resource, ResourceSerializableData data)
        {
            resource.Amount = data.Amount;
        }
    }
}