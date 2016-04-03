using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace ROGUE
{

    public enum FloorType
    {
        NoEnter,
        Normal,
        Hatake,
        Tagayashi,
    };

    public class MapParam
    {
        public int MapId;
        
        public int Width;
        public int Height;

        public string[] ColumnNames;
        public FloorType[] MapData;
    }


    public class MapData
    {
        public MapParam mMapData;

        //void Deserialize(string[] columns, string[] datas)
        public void Deserialize(TextAsset asset)
        {

            mMapData = new MapParam();

            string[] datas = null;
            BaseData.Deserialize(asset, out mMapData.ColumnNames, out datas);

            for (int i = 0; i < mMapData.ColumnNames.Length; ++i)
            {
                switch (mMapData.ColumnNames[i])
                {
                    case "mapid":
                        mMapData.MapId = int.Parse(datas[i]);
                        break;

                    case "size":
                        string[] size = datas[i].Split(BaseData.DataDlm);
                        mMapData.Width = int.Parse(size[0]);
                        mMapData.Height = int.Parse(size[1]);
                        break;

                    case "floor":
                        string[] types = datas[i].Split(BaseData.DataDlm);
                        mMapData.MapData = new FloorType[types.Length];
                        for(int j = 0; j < types.Length; ++j)
                        {
                            mMapData.MapData[j] = (FloorType)int.Parse(types[j]);
                        }
                        break;

                };

            }

        }

        public void InstanciateMap()
        {
            //for (int i = 0; i < Width; ++i)
            {
                //for (int j = 0; j < Height; ++j)
                {
                    //Vector3 pos = new Vector3(i, 0, j);

                    //int index = i * Width + j;

                    GameObject floorObject = null;
                    /*
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
                    */
                    if (null != floorObject)
                    {
                        //floorObject.transform.SetParent(transform, false);
                    }
                }
            }
        }

    }
}
