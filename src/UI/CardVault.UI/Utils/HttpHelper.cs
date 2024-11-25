namespace CardVault.UI.Utils
{
    public static class HttpHelper
    {
        public static bool IsJson(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return false;
            }

            content = content.Trim();

            return (content.StartsWith("{") && content.EndsWith("}"))
                || (content.StartsWith("[") && content.EndsWith("]"));
        }
    }
}
