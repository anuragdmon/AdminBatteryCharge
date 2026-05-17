# Admin Battery Charge

Instantly recharge electrical batteries in Rust using a chat command or simply by hitting them with a hammer.

Perfect for admins, moderators, creative servers, build servers, PvE servers, and VIP utilities.

## Features

* Recharge batteries instantly with:

  * `/chargebattery`
  * Hammer hit system
* Supports:

  * Admins
  * Permission-based players
* Fully charges:

  * Small Batteries
  * Medium Batteries
  * Large Batteries
* Lightweight and optimized
* No configuration required
* Easy permission system

## Permissions

### Allow command usage

`adminbatterycharge.use`

### Allow hammer recharge

`adminbatterycharge.hammer`

## Commands

### Chat Command

`/chargebattery`

Look directly at a battery and use the command to instantly fully recharge it.

### Console Command

`chargebattery`

## Hammer Recharge

Players with the permission:

`adminbatterycharge.hammer`

can simply hit a battery with a hammer to instantly recharge it.

## Example Permission Commands

Grant command access:

```bash
oxide.grant user PLAYERNAME adminbatterycharge.use
```

Grant hammer recharge:

```bash
oxide.grant user PLAYERNAME adminbatterycharge.hammer
```

Grant to an entire group:

```bash
oxide.grant group vip adminbatterycharge.hammer
```

## Ideal Uses

* VIP perks
* Creative/build servers
* Admin utility
* Electricity testing
* Event servers
* PvE quality-of-life

## Notes

* The hammer recharge only works on batteries.
* Regular players without permission cannot use the feature.
* Compatible with modern Rust/Oxide versions.

## Version

1.0.1

## Author

Anurag Swarnkar
