using Qurre.API.Addons;
using Qurre.API.Attributes;
using System.Collections.Generic;

namespace ClansTags
{
    public static class Configs
    {
        internal static JsonConfig Config { get; private set; }
        public static List<string> ClansTags { get; private set; }
        public static bool EnableJoinMessage { get; private set; }
        public static string JoinMessage { get; private set; }
        public static ushort TimeMessageDisplay { get; private set; }
        [EventMethod(4001u, 0)]
        internal static void LoadReloadConfig()
        {
            if (Config == null)
            {
                Config = new JsonConfig("ClansTags");
            }

            ClansTags = Config.SafeGetValue("ClansTags", new List<string>()
            {
                "PLM",
                "FFCL",
                "KPB"
            }, "Clan tags are available for installation");
            EnableJoinMessage = Config.SafeGetValue("EnableJoinMessage", true, "Will greeting players with clan tags be included?");
            JoinMessage = Config.SafeGetValue("JoinMessage", "<color=green>A member of the<color=red> <<%tag%>> </color>clan logged into the server!</color>", "A message at the player's entrance");
            TimeMessageDisplay = Config.SafeGetValue("TimeMessageDisplay", (ushort) 10, "How long will the message be displayed?");
        }
    }
}
