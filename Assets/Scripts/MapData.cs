using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace ROGUE {

    public class MapData : MonoBehaviour {

        int Width = 0;
        int Height = 0;

        int mMapId;

        EDirection mStartDir;

        public TextAsset MapDataFile;

        enum EFloorType
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

        enum EDirection
        {
            NUTRAL,
            UP,
            RIGHT,
            DOWN,
            LEFT,
        };

        string[] mColumnNames;


        EFloorType[] mMapTypes;

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

        Vector2 mStartPoint;



        public Vector2 StartPoint
        {
            get
            {
                return mStartPoint;
            }
        }



        void Awake()
        {
            if (null == MapDataFile)
            {
                return;
            }

            // カラム、データ部分の切り分け
            string mapText = MapDataFile.text;
            char[] delimiterRet = { '\n' };
            string[] mapDataArray = mapText.Split(delimiterRet);

            // カラムを切り分け
            string colmuns = mapDataArray[0];
            char[] delimiterCom = { ',' };
            mColumnNames = colmuns.Split(delimiterCom);

            // データを切り分け
            string data = mapDataArray[1];
            string[] dataArray = data.Split(delimiterCom);

            for (int i = 0; i < dataArray.Length; ++i)
            {
                if ("mapid" == mColumnNames[i])
                {
                    mMapId = int.Parse(dataArray[i]);
                }
                else if ("startdir" == mColumnNames[i])
                {
                    mStartDir = (EDirection)int.Parse(dataArray[i]);
                }
                else if ("floordata" == mColumnNames[i])
                {
                    char[] delimiterCol = { ':' };
                    string[] types = dataArray[i].Split(delimiterCol);
                    Width = (int)Mathf.Sqrt((float)types.Length);
                    Height = Width;
                    mMapTypes = new EFloorType[Width * Height];
                    for (int w = 0; w < Width; ++w)
                    {
                        for (int h = 0; h < Height; ++h)
                        {
                            mMapTypes[w * Width + h] = (EFloorType)int.Parse(types[Width * w + h]);
                        }
                    }
                }
            }

            for (int i = 0; i < mMapTypes.Length; ++i)
            {
                if (EFloorType.Enter == mMapTypes[i])
                {
                    mStartPoint.x = i / Width;
                    mStartPoint.y = i % Height;
                    break;
                }
            }

            //InstanciateMap();
        }

        public void InstanciateMap()
        {
            for (int i = 0; i < Width; ++i)
            {
                for (int j = 0; j < Height; ++j)
                {
                    Vector3 pos = new Vector3(i, 0, j);

                    int index = i * Width + j;

                    GameObject floorObject = null;

                    switch (mMapTypes[index])
                    {
                        case EFloorType.NoEntry:
                            floorObject = Instantiate(NoEntryObject, pos, new Quaternion()) as GameObject;
                            break;
                        case EFloorType.Enter:
                            //floorObject = Instantiate(EnterObject, pos, new Quaternion()) as GameObject;
                            break;
                        case EFloorType.Normal:
                            //floorObject = Instantiate(NormalObject, pos, new Quaternion()) as GameObject;
                            break;
                        case EFloorType.Wall:
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

        void Update()
        {

        }
    }
}
