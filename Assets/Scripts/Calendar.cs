using UnityEngine;
using System.Collections;

namespace ROGUE
{

    public class Calendar : MonoBehaviour
    {

#region Parameters

        static Calendar mInstance = null;

        static int mTotalDay;    // 総経過日数

        static bool mClock;         // 時間経過のカウントを行うか
        static float mDayElapsed;   // 一日の経過時間





#endregion




        private Calendar() {}
    
        public static Calendar Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new Calendar();
                }
                return mInstance;
            }
        }



        // 日付追加
        static void AddDay(int dayCount)
        {
            mTotalDay += dayCount;
        }

        // ゲーム内時間のカウント開始
        static void StartClock()
        {
            mClock = true;
        }

        // ゲーム内時間のカウント停止
        static void StopClock()
        {
            mClock = false;
        }

        void Update ()
        {
            if (mClock)
            {
                mDayElapsed += Time.deltaTime;
            }
        }
    }
}
