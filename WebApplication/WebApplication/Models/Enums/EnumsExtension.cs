namespace Application.Models.Enums
{
    public static class EnumsExtension
    {
        public static string Value<T>(object value) =>
            Enum.GetName(typeof(T), value)!;
    }
}
