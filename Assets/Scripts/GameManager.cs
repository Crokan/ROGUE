using UnityEngine;
using System.Collections;

namespace ROGUE
{
    public class GameManager : MonoBehaviour
    {
#region Parameters
        static GameManager mInstance;

#endregion

        private GameManager() { }

        public static GameManager Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new GameManager();
                }
                return mInstance;
            }
        }


        void Awake()
        {

        }
    }
}