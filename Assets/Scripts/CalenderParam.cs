using UnityEngine;
using System.Collections;


namespace ROGUE
{
    public class Json_CalenderParam
    {
        public int year;
        public int month;
        public int daysec;
        public int clocksec;
        public int elpsmin;
        public int clockmin;


    }

    public class CalenderParam
    {
        public int Year;        // １年経つまでの月
        public int Month;       // １月経つまでの日
        public int Daysec;      // リアル秒でゲーム時間１日
        public int ClockSec;    // １クロックに必要なリアル秒
        public int ElpsMin;     // １クロックで進むゲーム分
        public int ClockMin;    // 時計に反映される分単位
        
        public void Desrialize(Json_CalenderParam json)
        {
            Year = json.year;
            Month = json.month;
            Daysec = json.daysec;
            ClockSec = json.clocksec;
            ElpsMin = json.elpsmin;
            ClockMin = json.clockmin;
        }
    }
}
