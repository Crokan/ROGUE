using UnityEngine;
using System.Collections;


namespace ROGUE
{
    public class Json_CalenderParam
    {
        public int year;
        public int month;
        public int clocksec;
        public int ElpsMin;
        public int ClockMin;
    }

    public class CalenderParam
    {
        public int Year;        // １年経つまでの月
        public int Month;       // １月経つまでの日
        public int clocksec;    // １クロックに必要なリアル秒
        public int ElpsMin;     // １クロックで進むゲーム分
        public int ClockMin;    // 時計に反映される分単位
        
        public void Desrialize(string json)
        {
            LitJson.JsonMapper.ToObject<
        }
    }
}
