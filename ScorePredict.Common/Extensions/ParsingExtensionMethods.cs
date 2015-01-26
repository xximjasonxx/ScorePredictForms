
namespace ScorePredict.Common.Extensions
{
    public static class ParsingExtensionMethods
    {
        public static int AsInt(this string str, int defaultValue = int.MinValue)
        {
            int intVal;
            if (!int.TryParse(str, out intVal))
                return defaultValue;

            return intVal;
        }

        public static GameState AsGameStateEnumeration(this string str)
        {
            switch (str.ToLower())
            {
                case "p": return GameState.Pregame;
                case "f": return GameState.Final;
                default: return GameState.InProgress;
            }
        }
    }
}
