using UnityEngine;
using System.Collections;

namespace ROGUE
{
    public class PlayerController : MonoBehaviour
    {

        public GameObject Model;
        public float MoveSpeed;
        public Camera MainCamera;

        Vector3 DesirePosition;

        void Start()
        {
            DesirePosition = transform.position;
        }

        void Update()
        {
            // 左クリック中のみ移動
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);

                Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100);

                if (Physics.Raycast(ray, out hit))
                {
                    DesirePosition = hit.transform.position;
                }

                //return;
            }

            Vector3 start = transform.position;
            Vector3 goal = DesirePosition;
            Vector3 move = (goal - start).normalized * MoveSpeed * Time.deltaTime;

            if (move.sqrMagnitude >= (goal - start).sqrMagnitude)
            {
                move = goal - start;
            }

            transform.position += move;

        }
    }
}