using UnityEngine;
using System.Collections;


namespace ROGUE
{
    public class GameScene : MonoBehaviour {

        public TextAsset map;
        public GameObject hatake;

        FloorType[] types;
        int width;
        int height;

	    // Use this for initialization
	    void Start () {
            MapData data = new MapData();
            data.Deserialize(map);

            width = data.mMapData.Width;
            height = data.mMapData.Height;
            types = data.mMapData.MapData;
            for (int h = 0; h < height; ++h)
            {
                for (int w = 0; w < width; ++w)
                {
                    Debug.Log(h * height + w);
                    if (types[h * height + w] == FloorType.Hatake)
                    {
                        GameObject obj = Instantiate<GameObject>(hatake);
                        obj.transform.position = new Vector3((float)w, 0.1f, (float)height - h);
                        obj.transform.rotation = new Quaternion();
                    }
                }
            }


	    }
	
	    // Update is called once per frame
	    void Update () {
            
	    }
    }
}
