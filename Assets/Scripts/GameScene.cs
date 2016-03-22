using UnityEngine;
using System.Collections;


namespace ROGUE
{
    public class GameScene : MonoBehaviour {

        MapData mCurrentMap;


	    // Use this for initialization
	    void Start () {
            mCurrentMap = Resources.Load<MapData>("Map/Map1");
            if (null == mCurrentMap)
            {
                Debug.Log("Load Map Faild @GameScene");
            }

            MapData map = Instantiate(mCurrentMap) as MapData;
            map.InstanciateMap();

	    }
	
	    // Update is called once per frame
	    void Update () {
	
	    }
    }
}
