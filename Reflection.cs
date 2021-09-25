
namespace RoboPhredDev.PotionCraft.SaveFiles
{
    public static class Reflection
    {
        public static T GetPrivateField<T>(object instance, string fieldName)
        {
            var prop = instance.GetType().GetField(fieldName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return (T)prop.GetValue(instance);
        }

        public static void SetPrivateField<T>(object instance, string fieldName, T value)
        {
            var prop = instance.GetType().GetField(fieldName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            prop.SetValue(instance, value);
        }

        public static TValue GetPrivateStaticField<TType, TValue>(string fieldName)
        {
            var prop = typeof(TType).GetField(fieldName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            return (TValue)prop.GetValue(null);
        }
    }
}