using UnityEngine;
using System.Collections;


namespace ROGUE
{
    public class GameScene : MonoBehaviour {

        public TextAsset map;
        public GameObject hatake;

        public PlayerController Player;

        public TextAsset json;

        // カメラ追跡距離
        public float camTraceSpeed = 1.0f;
        public float camTraceMin = 0.5f;
        public float camTraceMax = 1.0f;


        FloorType[] types;
        int width;
        int height;

	    void Start ()
        {
            MapData data = new MapData();
            data.Deserialize(map);

/*
            //JSONテキストのデコード.
            LitJson.JsonData jsonData = LitJson.JsonMapper.ToObject(json.text);
            LitJson.JsonData d = jsonData["fix"];
            string year = (string)d["year"];
*/

            width = data.mMapData.Width;
            height = data.mMapData.Height;
            types = data.mMapData.MapData;
            for (int h = 0; h < height; ++h)
            {
                for (int w = 0; w < width; ++w)
                {
                    //Debug.Log(h * height + w);
                    
                    if (types[h * height + w] == FloorType.Hatake)
                    {
                        GameObject obj = Instantiate<GameObject>(hatake);
                        obj.transform.position = new Vector3((float)w, 0.1f, (float)height - h);
                        obj.transform.rotation = new Quaternion();
                    }
                }
            }


	    }
	
	    void Update ()
        {
            Transform camraTransform = Camera.main.transform;
            camraTransform.LookAt(Player.transform);

            Vector3 pos2d = camraTransform.position;
            Vector3 posPly = Player.transform.position;

            pos2d.y = 0.0f;
            posPly.y = 0.0f;

            Vector3 camToPos = posPly - pos2d;

            float diff = 0.0f;
            if (camToPos.sqrMagnitude > (camTraceMax * camTraceMax))
            {
                Debug.Log("max:");

                diff = camToPos.magnitude - camTraceMax;
                //diff = diff > camTraceMax ? camTraceMax : diff;
            }
            else if (camToPos.sqrMagnitude < (camTraceMin * camTraceMin))
            {
                Debug.Log("min");

                diff = camToPos.magnitude - camTraceMin;
                //diff = diff > camTraceMin ? camTraceMin : diff;
            }

            camraTransform.position += camToPos.normalized * diff;
	    }
    }
}
