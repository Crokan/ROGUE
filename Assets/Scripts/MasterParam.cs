using UnityEngine;
using System.Collections;

namespace ROGUE
{

    public class Json_MasterParam
    {
        public Json_FixParam fix;
        public Json_CalenderParam calender;
    }

    public class MasterParam
    {
        Json_FixParam Fix;
        Json_CalenderParam Calender;


        public void Deserialize(Json_MasterParam json)
        {
            //Fix = json.fix;
            Calender = json.calender;
        }
    }
}
