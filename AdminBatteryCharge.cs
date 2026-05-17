using Oxide.Core;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("Admin Battery Charge", "Anurag Swarnkar", "1.0.1")]
    [Description("Allows admins or permitted players to instantly recharge batteries by command or hammer hit.")]
    public class AdminBatteryCharge : RustPlugin
    {
        private const string PermUse = "adminbatterycharge.use";
        private const string PermHammer = "adminbatterycharge.hammer";

        private void Init()
        {
            permission.RegisterPermission(PermUse, this);
            permission.RegisterPermission(PermHammer, this);
        }

        [ChatCommand("chargebattery")]
        private void ChargeBatteryCommand(BasePlayer player, string command, string[] args)
        {
            if (player == null) return;

            if (!player.IsAdmin && !permission.UserHasPermission(player.UserIDString, PermUse))
            {
                player.ChatMessage("You don't have permission to use this command.");
                return;
            }

            var entity = GetLookEntity(player, 5f);

            if (entity == null)
            {
                player.ChatMessage("Look directly at a battery and use /chargebattery.");
                return;
            }

            var battery = entity as ElectricBattery;

            if (battery == null)
            {
                player.ChatMessage("That is not a battery.");
                return;
            }

            ChargeBattery(battery);
            player.ChatMessage("Battery fully charged.");
        }

        [ConsoleCommand("chargebattery")]
        private void ChargeBatteryConsole(ConsoleSystem.Arg arg)
        {
            var player = arg.Player();

            if (player == null)
            {
                arg.ReplyWith("This command must be used by a player looking at a battery.");
                return;
            }

            ChargeBatteryCommand(player, "chargebattery", new string[0]);
        }

        private object OnHammerHit(BasePlayer player, HitInfo info)
        {
            if (player == null || info == null)
                return null;

            if (!player.IsAdmin && !permission.UserHasPermission(player.UserIDString, PermHammer))
                return null;

            var battery = info.HitEntity as ElectricBattery;

            if (battery == null)
                return null;

            ChargeBattery(battery);
            player.ChatMessage("Battery fully charged.");

            return null;
        }

        private void ChargeBattery(ElectricBattery battery)
        {
            battery.rustWattSeconds = battery.maxCapactiySeconds;
            battery.SendNetworkUpdateImmediate();
        }

        private BaseEntity GetLookEntity(BasePlayer player, float distance)
        {
            RaycastHit hit;
            if (!Physics.Raycast(player.eyes.HeadRay(), out hit, distance))
                return null;

            return hit.GetEntity();
        }
    }
}
