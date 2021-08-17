namespace Acerpro.Shared.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsNotEmpty(this string value)
        {
            try
            {
                return value.Trim().Length > 0;
            }
            catch 
            {
                return false;
            }
        }
    }
}
