using UnityEngine;
using System.Collections;

public class MapCreator : MonoBehaviour {

    int Width = 0;
    int Height = 0;

    public TextAsset MapDataFile;

    enum FloorType
    {
        NoEntry,
        Normal,
        Enter,
        Wall,
        Event,
        Next,
        Prev,
        Town,
    };

    FloorType[] MapData;

    public GameObject NoEntryObject;
    public GameObject WallObject;

    class MapPoint
    {
        public int X;
        public int Y;

        public MapPoint(int X = 0, int Y = 0)
        {
            this.X = X;
            this.Y = Y;
        }

    }

    private void ClearMap()
    {
        for (int i = 0; i < Width; ++i)
        {
            for (int j = 0; j < Height; ++j)
            {
                Vector3 pos = new Vector3(i, 0, j);

                int index = i * Width + j;
                if (i == 0)
                {
                    MapData[index] = FloorType.NoEntry;
                }
                else if (i == (Width - 1))
                {
                    MapData[index] = FloorType.NoEntry;
                }
                else if (j == 0)
                {
                    MapData[index] = FloorType.NoEntry;
                }
                else if (j == (Width - 1))
                {
                    MapData[index] = FloorType.NoEntry;
                }
                else
                {
                    MapData[index] = FloorType.Normal;
                }
            }
        }
    }

    private void InstanciateMap()
    {
        for (int i = 0; i < Width; ++i)
        {
            for (int j = 0; j < Height; ++j)
            {
                Vector3 pos = new Vector3(i, 0, j);

                int index = i * Width + j;

                GameObject floorObject = null;

                switch(MapData[index])
                {
                    case FloorType.NoEntry :
                        floorObject = Instantiate(NoEntryObject, pos, new Quaternion()) as GameObject;
                        break;
                    case FloorType.Enter :
                        //floorObject = Instantiate(EnterObject, pos, new Quaternion()) as GameObject;
                        break;
                    case FloorType.Normal :
                        //floorObject = Instantiate(NormalObject, pos, new Quaternion()) as GameObject;
                        break;
                    case FloorType.Wall :
                        floorObject = Instantiate(WallObject, pos, new Quaternion()) as GameObject;
                        break;
                }

                if (null != floorObject)
                {
                    floorObject.transform.SetParent(transform, false);
                }
            }
        }
    }

	void Start ()
    {
        if (null == MapDataFile)
        {
            return;
        }

        string mapText = MapDataFile.text;
        char[] delimiter = {',', '\n'};
        string[] dataArray = mapText.Split(delimiter);

        Width = (int)Mathf.Sqrt((float)dataArray.Length);
        Height = Width;
        MapData = new FloorType[Width * Height];

        for (int i = 0; i < Width; ++i)
        {
            for (int j = 0; j < Height; ++j)
            {
                SetPointType(i, j, (FloorType)int.Parse(dataArray[Width * i + j]));
            }
        }


        //ClearMap();

        MapPoint start = new MapPoint(1, 1);
        SetPointType(start.X, start.Y, FloorType.Enter);

        InstanciateMap();
    }

    void SetPointType(int x, int y, FloorType type)
    {
        MapData[x * Width + y] = type;
    }
	
	void Update () {
	
	}
}
