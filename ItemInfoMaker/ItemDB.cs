using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemInfoMaker
{
    enum ItemDBPos
    {
        ID = 0,
        Name = 1,
        Jname = 2,
        Type = 3,
        Price = 4,
        Sell = 5,
        Weight = 6,
        ATK = 7,
        DEF = 8,
        Range = 9,
        Slot = 10,
        Job = 11,
        Gender = 12,
        Loc = 13,
        wLV = 14,
        eLV = 15,
        View = 16,
        Refine = 17,
        UseScript = 18,
        EquipScript = 19,
        UnEquipScript = 20,
    }
    enum EquipLoc
	{
		LOC_NOTHING = 0x000000,
		LOC_HEAD = 0x000001,    // 頭下段
		LOC_RARM = 0x000002,    // 右手
		LOC_ROBE = 0x000004,    // 肩
		LOC_RACCESSORY = 0x000008,  // アクセサリ右
		LOC_BODY = 0x000010,    // 体
		LOC_LARM = 0x000020,    // 左手
		LOC_RLARM = 0x000022,   // 両手
		LOC_SHOES = 0x000040,   // 靴
		LOC_LACCESSORY = 0x000080,  // アクセサリ左
		LOC_RLACCESSORY = 0x000088, // アクセサリ右左
		LOC_HEAD2 = 0x000100,   // 頭上段
		LOC_HEAD_TB = 0x000101, // 頭上下段
		LOC_HEAD3 = 0x000200,   // 頭中段
		LOC_HEAD_MB = 0x000201, // 頭中下段
		LOC_HEAD_TM = 0x000300, // 頭上中段
		LOC_HEAD_TMB = 0x000301,    // 頭上中下段
		LOC_COSTUME_HEAD2 = 0x000400,   // コスチューム上段
		LOC_COSTUME_HEAD3 = 0x000800,   // コスチューム中段
		LOC_COSTUME_HEAD_TM = 0x000C00, // コスチューム上中段
		LOC_COSTUME_HEAD = 0x001000,    // コスチューム下段
		LOC_COSTUME_HEAD_TB = 0x001400, // コスチューム上下段
		LOC_COSTUME_HEAD_MB = 0x001800, // コスチューム中下段
		LOC_COSTUME_HEAD_TMB = 0x001C00,    // コスチューム上中下段
		LOC_COSTUME_ROBE = 0x002000,    // コスチューム肩
		LOC_COSTUME_FLOOR = 0x004000,   // コスチュームFLOOR
		LOC_ARROW = 0x008000,   // 矢・弾丸・苦無・手裏剣・キャノンボール
		LOC_ARMOR_SHADOW = 0x010000,    // アーマーシャドウ
		LOC_WEAPON_SHADOW = 0x020000,   // ウェポンシャドウ
		LOC_SHIELD_SHADOW = 0x040000,   // シールドシャドウ
		LOC_SHOES_SHADOW = 0x080000,    // シューズシャドウ
		LOC_RACCESSORY_SHADOW = 0x100000,   // アクセサリ右シャドウ
		LOC_LACCESSORY_SHADOW = 0x200000,   // アクセサリ左シャドウ
	}
    class ItemDB
    {
    }
}
