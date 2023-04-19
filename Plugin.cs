using ClansTags;
using Qurre.API;
using Qurre.API.Attributes;
using Qurre.Events;
using Qurre.Events.Structs;

[PluginInit("ClansTags", "DaNoNe", "1.0.0")]
static class Plugin
{
    [EventMethod(PlayerEvents.Join)]
    static internal void JoinPlayerEvent(JoinEvent ev)
    {
        Player player = ev.Player;

        foreach(string tag in Configs.ClansTags)
        {
            if (player.UserInfomation.Nickname.Contains($"[{tag}]"))
            {
                if(player.Administrative.RoleName == "")
                {
                    player.Administrative.RoleName = $"{tag}";
                } else
                {
                    player.Administrative.RoleName = $"{tag} | {player.Administrative.RoleName}";
                }
                if (Configs.EnableJoinMessage)
                {
                    Map.Broadcast(Configs.JoinMessage.Replace("%tag%", tag), Configs.TimeMessageDisplay);
                }
            }
        }
    }
}