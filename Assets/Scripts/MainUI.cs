using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour {

    public Camera MainCamera;//主摄像机
    public GameObject CameraObj;
    //UI的各个按钮
    public GameObject renyuanshezhi_btn;
    public GameObject JianKongPlane;
    public GameObject fanhui_btn;
    public GameObject shezhiwancheng_btn;
    public GameObject kaishixunlu_btn;
    public GameObject shezhirenshuPlane;
    public GameObject quyuchakan_btn;
    public GameObject touming_btn;
    public GameObject Rs_Plane;
    //
    public GameObject modelObj;
    public GameObject Person_08;
    public GameObject Person_06;
   
    public GameObject JZObj;
   
    public GameObject[] louceng;
    public GameObject[] persons;

    float x1,x2;
    float z1,z2;
    string ModelLayer;

    public InputField Inf;

    Vector3 maincamVe3;

    public GameObject Person_Obj;
    //透明所需的那些材质
    public Material Qiang_02;
    public Material Qiang_02_tra;
    public Material concrete_d100;
    public Material concrete_d100_tra;
    public Material DiaoJu_01;
    public Material DiaoJu_01_tra;
    public Material Door_01;
    public Material Door_01_tra;
    public Material Floor_01;
    public Material Floor_01_tra;
    public Material GR052;
    public Material GR052_tra;
    public Material Gzigang_1;
    public Material Gzigang_1_tra;
    public Material LanGan_01;
    public Material LanGan_01_tra;
    public Material SheB_01;
    public Material SheB_01_tra;
    public Material Taijie_1;
    public Material Taijie_1_tra;
    bool isTra = false;


    //相机位置
    CameraPos campos;
    void Start ()
    {
        maincamVe3 = MainCamera.transform.localPosition;
        campos = GetComponent<CameraPos>();
    }
		
	void Update () {

        if (renyuanshezhi_btn.activeInHierarchy)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (hitInfo.collider.tag == "cube")
                    {

                        x1 = (hitInfo.collider.gameObject.transform.position.x) + (hitInfo.collider.gameObject.transform.localScale.x) * 0.5f;
                        x2 = (hitInfo.collider.gameObject.transform.position.x) - (hitInfo.collider.gameObject.transform.localScale.x) * 0.5f;
                        z1 = (hitInfo.collider.gameObject.transform.position.z) + (hitInfo.collider.gameObject.transform.localScale.z) * 0.5f;
                        z2 = (hitInfo.collider.gameObject.transform.position.z) - (hitInfo.collider.gameObject.transform.localScale.z) * 0.5f;
                        Rs_Plane.SetActive(true);

                        if (hitInfo.collider.gameObject.transform.position.y < -10)
                        {
                            ModelLayer = "Lar08";
                        }
                        else
                        {
                            ModelLayer = "Lar06";
                        }
                    }
                }

            }
        }
        
		
	}

    public void Mon_btnClick()
    {
        JianKongPlane.SetActive(true);
        CameraObj.SetActive(true);
        MainCamera.enabled = false;
    }

    public void CloseJiankong()
    {
        JianKongPlane.SetActive(false);
        CameraObj.SetActive(false);
        MainCamera.enabled = true;
        MainCamera.GetComponent<CameraFlow>().target = null;
    }


    void CameraCull(int x)
    {
        CloseJiankong();       
        MainCamera.cullingMask = 1 << x + 1;
        fanhui_btn.SetActive(true);
        MainCamera.GetComponent<CameraFlow>().target = null;
    }
    public void Jiankong_btn14()
    {
        CameraCull(14);
        campos.CameraLar01();
    }

    public void Jiankong_btn13()
    {
        CameraCull(13);
        campos.CameraLar02();
    }

    public void Jiankong_btn12()
    {
        CameraCull(12);
        campos.CameraLar03();
    }
    public void Jiankong_btn11()
    {
        CameraCull(11);
        campos.CameraLar04();
    }

    public void Jiankong_btn10()
    {
        CameraCull(10);
        campos.CameraLar05();
    }

    public void Jiankong_btn9()
    {
        CameraCull(9);
        campos.CameraLar06();
    }
    public void Jiankong_btn8()
    {
        CameraCull(8);
        campos.CameraLar07();
    }

    public void Jiankong_btn7()
    {
        CameraCull(7);
        campos.CameraLar08();
    }

    public void fanhui_Click()//返回按钮
    {
        fanhui_btn.SetActive(false);
        MainCamera.cullingMask = ~(1 << 3);
        campos.CameraStart();
        MainCamera.GetComponent<CameraFlow>().target = null;
    }


    public void renshu_Click()//人员设置按钮
    {
        shezhirenshuPlane.SetActive(true);
        shezhiwancheng_btn.SetActive(true);
        foreach (GameObject go in louceng)
        {
            go.SetActive(true);
        }
        kaishixunlu_btn.SetActive(false);
        quyuchakan_btn.SetActive(false);
        CameraObj.SetActive(true);
        MainCamera.enabled = false;
        MainCamera.transform.GetComponent<CameraFlow>().enabled = false;
    }
 
    public void shengcheng_Click()//生成按钮
    {
        int num;
        if (Inf.text != null)
        {
            num = int.Parse(Inf.text);

            for (int i = 0; i < num; i++)
            {
                if (ModelLayer == "Lar08")
                {
                  GameObject go =  Instantiate(modelObj, new Vector3(Random.Range(x1, x2), -12.478f, Random.Range(z1, z2)), Quaternion.identity);
                    go.transform.parent = Person_08.transform;
                    foreach (Transform tran in go.transform.GetComponentsInChildren<Transform>())
                    {
                        tran.transform.gameObject.layer = LayerMask.NameToLayer("Lar08");
                    }

                    
                }
                else if (ModelLayer == "Lar06")
                {
                    GameObject go = Instantiate(modelObj, new Vector3(Random.Range(x1, x2), -0.04390621f, Random.Range(z1, z2)), Quaternion.identity);
                    go.transform.parent = Person_06.transform;

                    foreach (Transform tran in go.transform.GetComponentsInChildren<Transform>())
                    {
                        tran.transform.gameObject.layer = LayerMask.NameToLayer("Lar06");
                    }
                }
               
            }
        }
        Rs_Plane.SetActive(false);

    }

    public void kaishixunlu_Click()//开始寻路按钮
    {
        Transform[] Trs = Person_Obj.GetComponentsInChildren<Transform>(true);
        foreach (Transform child in Trs)
        {
            if (child.tag == "Player")
            {
                Nav_toTarget nt = child.GetComponent<Nav_toTarget>();
                if (nt == null)
                {
                    child.transform.gameObject.AddComponent<Nav_toTarget>();
                }
               
               
                Animation ani = child.GetComponent<Animation>();
                ani.Play("run");      
                
            }
        }
    }

    public void renyuanshezhi_8Click()//设置面板按钮8
    {
       
        shezhirenshuPlane.SetActive(false);
        campos.CameraLar08();
        CameraObj.SetActive(false);
        MainCamera.enabled = true;
        MainCamera.GetComponent<CameraFlow>().target = null;
        foreach (GameObject go in louceng)
        {
            go.SetActive(false);
        }
        louceng[7].SetActive(true);

        foreach (GameObject go in persons)
        {
            go.SetActive(false);
        }
        persons[7].SetActive(true);
    }

    public void renyuanshezhi_6Click()//设置面板按钮6
    {

        campos.CameraLar06();
        shezhirenshuPlane.SetActive(false);
        campos.CameraLar08();
        CameraObj.SetActive(false);
        MainCamera.enabled = true;
        MainCamera.GetComponent<CameraFlow>().target = null;
        foreach (GameObject go in louceng)
        {
            go.SetActive(false);
        }
        louceng[5].SetActive(true);
        foreach (GameObject go in persons)
        {
            go.SetActive(false);
        }
        persons[5].SetActive(true);
    }
    
    public void Close_renyuanshezhi_Click()//设置面板关闭按钮
    {
        shezhirenshuPlane.SetActive(false);
        CameraObj.SetActive(false);
        MainCamera.enabled = true;
        MainCamera.GetComponent<CameraFlow>().target = null;
    }
    public void shezhiwancheng_Click()//设置完成按钮
    {
        shezhiwancheng_btn.SetActive(false);
        renyuanshezhi_btn.SetActive(false);
        touming_btn.SetActive(true);
        kaishixunlu_btn.SetActive(true);
        quyuchakan_btn.SetActive(true);
        foreach (GameObject go in louceng)
        {
            go.SetActive(true);
        }
        foreach (GameObject go in persons)
        {
            go.SetActive(true);
        }
        campos.CameraStart();
        MainCamera.transform.GetComponent<CameraFlow>().enabled = true;
       
    }

    public void Tra_Button_Click()
    {
        isTra = !isTra;
        TransparentBuilding();
    }

    void TransparentBuilding()
    {
        Transform[] Trs = JZObj.GetComponentsInChildren<Transform>(true);
        foreach (var child in Trs)
        {
            if (child.GetComponent<MeshRenderer>() != null)
            {

                if (child.GetComponent<MeshRenderer>().materials[0].name.Contains("Door_"))
                {
                    print(child.GetComponent<MeshRenderer>().materials[0].name);
                    ChangeBuildingMaterial(child, Door_01, Door_01_tra);
                }
                else if (child.GetComponent<MeshRenderer>().materials[0].name.Contains("Floor_"))
                {
                    ChangeBuildingMaterial(child, Floor_01, Floor_01_tra);
                }
                else if (child.GetComponent<MeshRenderer>().materials[0].name.Contains("LanGan_"))
                {
                    ChangeBuildingMaterial(child, LanGan_01, LanGan_01_tra);
                }
                else if (child.GetComponent<MeshRenderer>().materials[0].name.Contains("Taijie_"))
                {
                    ChangeBuildingMaterial(child, Taijie_1, Taijie_1_tra);
                }
                else if (child.GetComponent<MeshRenderer>().materials[0].name.Contains("Qiang_"))
                {
                    ChangeBuildingMaterial(child, Qiang_02, Qiang_02_tra);
                }
                else if (child.GetComponent<MeshRenderer>().materials[0].name.Contains("concrete_"))
                {
                    ChangeBuildingMaterial(child, concrete_d100, concrete_d100_tra);
                }
                else if (child.GetComponent<MeshRenderer>().materials[0].name.Contains("DiaoJu_"))
                {
                    ChangeBuildingMaterial(child, DiaoJu_01, DiaoJu_01_tra);
                }
                else if (child.GetComponent<MeshRenderer>().materials[0].name.Contains("GR0"))
                {
                    ChangeBuildingMaterial(child, GR052, GR052_tra);
                }
                else if (child.GetComponent<MeshRenderer>().materials[0].name.Contains("Gzigang_"))
                {
                    ChangeBuildingMaterial(child, Gzigang_1, Gzigang_1_tra);
                }
                else if (child.GetComponent<MeshRenderer>().materials[0].name.Contains("SheB_"))
                {
                    ChangeBuildingMaterial(child, SheB_01, SheB_01_tra);
                }
                else
                {
                    ChangeBuildingMaterial(child, Qiang_02, Qiang_02_tra);
                }

            }
        }
    }

    void ChangeBuildingMaterial(Transform tra,Material mat,Material mat_tra)
    {
        if (isTra)
        {
            tra.GetComponent<MeshRenderer>().material = mat_tra;
        }
        else
        {
            tra.GetComponent<MeshRenderer>().material = mat;
        }
    }

    public void Res_btnClick()
    {
        SceneManager.LoadScene("Scene1");
    }
}

