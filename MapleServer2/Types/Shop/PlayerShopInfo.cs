﻿using Maple2Storage.Enums;
using MaplePacketLib2.Tools;
using MapleServer2.Database;
using MapleServer2.Database.Types;

namespace MapleServer2.Types;

public class PlayerShopInfo
{
    public long Uid;
    public int ShopId;
    public long CharacterId;
    public long AccountId;
    public long RestockTime;
    public int TotalRestockCount;
    public bool IsPersistant; // Account wide
    public List<ShopItem> ShopItems;

    public PlayerShopInfo() { }

    public PlayerShopInfo(Shop shop, Player player)
    {
        ShopId = shop.Id;
        RestockTime = shop.RestockTime;
        CharacterId = player.CharacterId;
        AccountId = player.AccountId;
        Uid = DatabaseManager.PlayerShopInfos.Insert(this);
    }

    public PlayerShopInfo(dynamic data)
    {
        Uid = data.uid;
        ShopId = data.shop_id;
        CharacterId = data.character_id;
        AccountId = data.account_id;
        RestockTime = data.restock_time;
        TotalRestockCount = data.total_restock_count;
        IsPersistant = data.is_persistant;
    }
}
