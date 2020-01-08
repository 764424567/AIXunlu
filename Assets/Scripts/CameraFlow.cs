using UnityEngine;
using System.Collections;

public class CameraFlow : MonoBehaviour
{

    public Transform target;
    public GameObject fanhui_btn;

    public float distanceUp = 2f;
    public float distanceAway = 2f;
    public float smooth = 2f;//位置平滑移动值
    public float camDepthSmooth = 5f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          //  LayerMask mask = 1 << 8| 1 <<9 | 1 << 10 | 1 << 11 | 1 << 12 | 1 << 13 | 1 << 14 | 1 << 15 | 1 << 16;      
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, (1<<21)))
            {
                Debug.DrawLine(ray.origin, hitInfo.point,Color.red);
                Debug.Log("click object name is " + hitInfo.collider.gameObject.name);
                if (hitInfo.collider.tag == "Player")
                {
                    target = hitInfo.collider.gameObject.transform;
                    fanhui_btn.SetActive(true);
                    Camera.main.cullingMask = ~(1 << 3);
                }
            }
      }
           
            // 鼠标轴控制相机的远近
            if ((Input.mouseScrollDelta.y < 0 && Camera.main.fieldOfView >= 3) || Input.mouseScrollDelta.y > 0 && Camera.main.fieldOfView <= 80)
        {
            Camera.main.fieldOfView += Input.mouseScrollDelta.y * camDepthSmooth * Time.deltaTime;
        }

    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 disPos = target.position + Vector3.up * distanceUp - target.forward * distanceAway;
            transform.position = Vector3.Lerp(transform.position, disPos, Time.deltaTime * smooth);
            //相机的角度
            transform.LookAt(target.position);
        }             
    }
}