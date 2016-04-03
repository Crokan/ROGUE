using UnityEngine;
using System.Collections;

namespace ROGUE
{

    public class BaseData
    {

        static public char[] LineDlm = { '\n' };
        static public char[] ColDlm = { '\t' };
        static public char[] DataDlm = { ',' };

        static public void Deserialize(TextAsset asset, out string[] colmns, out string[] datas)
        {

            if (null == asset)
            {
                colmns = null;
                datas = null;
                return;
            }

            // カラム、データ部分の切り分け
            string mapText = asset.text;
            string[] mapDataArray = mapText.Split(LineDlm);

            // カラムを切り分け
            string colmuns = mapDataArray[0];
            colmns = colmuns.Split(ColDlm);

            // データを切り分け
            string data = mapDataArray[1];
            datas = data.Split(ColDlm);

        }

    }
}
