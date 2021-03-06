using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CamerControl : MonoBehaviour
{
	private Vector2 pivotPoint;
	
	public float daoHangDisScreen = 85;
    public float minHeight = 1.75f;
    public float maxHeight = 100.0f;
    public float rotate_Speed = 15f;
    public float scrollbar_Speed = 0.025f;
	public float scrollWheel_Speed = 0.025f;
	public float keyCode_Speed = 0.025f;	
	public float mouse_Move_Speed = 0.05f;
	public float mouse_Rotate_Speed = 100f;

    private bool isLeftFuWei = false;
    private bool isRightFuWei = false;

    private float vSliderValue = 1F;

    private bool isMoveUp = false;
    private bool isMoveDown = false;
    private bool isMoveLeft = false;
    private bool isMoveRight = false;
	
    private bool isRotateUp = false;
    private bool isRotateDown = false;
    private bool isRotateLeft = false;
    private bool isRotateRight = false;
	
    private bool isScrollbar_Up = false;
    private bool isScrollbar_Down = false;
    private bool isChangedHigth = false;
    private int up;
    private int down;
    private int left;
    private int right;
	
	public bool isMoveBool = false;
	public bool isRotateBool = false;
	public bool is_MouseRight_Rotate = false;
	public bool is_Window = false;

    void Start()
    {
        SliderValue();		
		isMoveBool = true;
		isRotateBool = true;
		is_Window = true;
    }


    void Update()
    {
        if (is_MouseRight_Rotate == true) Moues_Right_Rotate();      
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(2)) UpdateMouseButton();
		
		if(isMoveBool)
		{
			if(Input.GetMouseButton(0))
			{
				mouseMove();
				clampCamHigth();
			}
		}
        if (isMoveUp) MoveUp();
        if (isMoveDown) MoveDown();
        if (isMoveLeft) MoveLeft();
        if (isMoveRight) MoveRight();
		
		if(isRotateBool)
		{
        	if (isRotateUp) RotateUp();
        	if (isRotateDown) RotateDown();
        	if (isRotateLeft) RotateLeft();
        	if (isRotateRight) RotateRight();
		}
		
		if (isLeftFuWei) leftFuWei();           
        if (isRightFuWei) rightFuWei();
		
        if (isScrollbar_Up) scrollBar_Up();
        if (isScrollbar_Down) scrollBar_Down();

        if (isChangedHigth) cam_Higth();
		
		if(is_Window)
		{
			if (Input.GetAxis("Mouse ScrollWheel") < 0 || Input.GetKey(KeyCode.J)) scrollWheel_Back();
			if (Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetKey(KeyCode.K)) scrollWheel_Forward();
		}
        upDateKey();
    }
//    //判断鼠标是否在此区域
//    bool MouseAtButton(Rect m_rect)
//    {
//        Vector2 mousePosition = Vector2.zero;
//        mousePosition = Event.current.mousePosition;
//        if (mousePosition.x >= m_rect.x && mousePosition.x <= m_rect.x + m_rect.x + m_rect.width
//            && mousePosition.y >= m_rect.y && mousePosition.y <= m_rect.y + m_rect.y + m_rect.height)
//			
//            return false;
//        else
//            return true;
//    }
    void northRotate()
    {
//        pivotPoint = new Vector2(Screen.width - 60, 95);
//        GUIUtility.RotateAroundPivot(transform.eulerAngles.y, pivotPoint);
				
//        if (GUI.Button(new Rect(Screen.width - 63, 49, 15, 15), northTex, north_Style) || Input.GetKey(KeyCode.G))
//        {
//           	if(transform.rotation.y != 0)
//			{
//				if (transform.eulerAngles.y > 0 && transform.eulerAngles.y <= 180) 
//					isRightFuWei = true;	 
//	            if (transform.eulerAngles.y > 180 && transform.eulerAngles.y <= 360) 
//					isLeftFuWei = true;
//	        }
//		}		
    }
    void leftFuWei()
    {
        if (transform.eulerAngles.y > 180f && transform.eulerAngles.y <= 360f)
        {
            transform.Rotate(new Vector3(0, 1, 0), Space.World);
        }
        else
        {
           transform.rotation = new Quaternion(transform.rotation.x, 0, 0, transform.rotation.w);
			//transform.rotation = new Quaternion(default_Cam_Angle.x,0,0,default_Cam_Angle.w);
            isLeftFuWei = false;
        }
    }
    void rightFuWei()
    {
        if (transform.eulerAngles.y > 0f && transform.eulerAngles.y <= 180f)
        {
            transform.Rotate(new Vector3(0, -1, 0), Space.World);
        }
        else
        {
            transform.rotation = new Quaternion(transform.rotation.x, 0, 0, transform.rotation.w);
			//transform.rotation = new Quaternion(default_Cam_Angle.x,0,0,default_Cam_Angle.w);
            isRightFuWei = false;
        }
    }
    void upDateKey()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) isMoveUp = true;
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) isMoveUp = false;

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) isMoveDown = true;
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) isMoveDown = false;

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) isMoveLeft = true;
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) isMoveLeft = false;

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) isMoveRight = true;
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) isMoveRight = false;		
				
        if (Input.GetKeyDown(KeyCode.Q)) isRotateLeft = true;
        if (Input.GetKeyUp(KeyCode.Q)) isRotateLeft = false;

        if (Input.GetKeyDown(KeyCode.E)) isRotateRight = true;
        if (Input.GetKeyUp(KeyCode.E)) isRotateRight = false;

        if (Input.GetKeyDown(KeyCode.C)) isRotateUp = true;
        if (Input.GetKeyUp(KeyCode.C)) isRotateUp = false;

        if (Input.GetKeyDown(KeyCode.Z)) isRotateDown = true;
        if (Input.GetKeyUp(KeyCode.Z)) isRotateDown = false;
    }
	//滚轮放缩
	void scrollWheel_Forward()
	{
		clampCamHigth();
        if (transform.position.y > minHeight)
        {
            transform.Translate(Vector3.back * -transform.position.y * scrollWheel_Speed);
            SliderValue();
        }
	}	
	void scrollWheel_Back()
	{
		clampCamHigth();
        if (transform.position.y < maxHeight)
        {
            transform.Translate(Vector3.back * transform.position.y * scrollWheel_Speed);
            SliderValue();
        }
	}
    //按下鼠标拖动
    void mouseMove()
    {
        if (GUIUtility.hotControl != 0) return;

        float xAxis = Input.GetAxis("Mouse X");
        float yAxis = Input.GetAxis("Mouse Y");
        Quaternion rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        transform.position = rotation * new Vector3(-xAxis, 0, -yAxis) * mouse_Move_Speed * transform.position.y + transform.position;
    }	
    void clampCamHigth()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minHeight, maxHeight), transform.position.z);
    }
    //前后左右移动
    void MoveUp()
    {
        Quaternion rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        transform.position = rotation * new Vector3(0, 0, 1) * keyCode_Speed * transform.position.y + transform.position;
    }
    void MoveDown()
    {
        Quaternion rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        transform.position = rotation * new Vector3(0, 0, -1) * keyCode_Speed * transform.position.y + transform.position;
    }
    void MoveLeft()
    {
        transform.Translate(Vector3.left * keyCode_Speed * transform.position.y);
    }
    void MoveRight()
    {
        transform.Translate(Vector3.right * keyCode_Speed * transform.position.y);
    }
    //左右,仰视俯视旋转
    void RotateUp()
    {
//        if (transform.eulerAngles.x <= 90 || transform.eulerAngles.x > 270)
//        {
//			transform.Rotate(new Vector3(-1,0,0) * Time.deltaTime * rotate_Speed);
//        }
		print ("up");
		if(transform.localEulerAngles.x <= 90 && transform.localEulerAngles.x > 70)
		{
			transform.Rotate(new Vector3(-1,0,0) * Time.deltaTime * rotate_Speed);
		}
		
    }
    void RotateDown()
    {
        if (transform.eulerAngles.x < 90 || transform.eulerAngles.x >= 270)
        {
			transform.Rotate(new Vector3(1,0,0) * Time.deltaTime * rotate_Speed);
        }
		
    }
    void RotateLeft()
    {
        transform.Rotate(-Vector3.up * Time.deltaTime * rotate_Speed, Space.World);
    }
    void RotateRight()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotate_Speed, Space.World);
    }
    //摄像机高度对应滑动块位置
    public void SliderValue()
    {
        float z = transform.position.y - minHeight;
        vSliderValue = 100f - z * 100f / (maxHeight - minHeight);
    }

    void cam_Higth()
    {
        float higth_Cam = (100 - vSliderValue) / 100 * (maxHeight - minHeight);

        if (vSliderValue < 100f && vSliderValue > 1f)
        {
            transform.position = new Vector3(transform.position.x, higth_Cam, transform.position.z);
        }

        if (vSliderValue == 100f)
            transform.position = new Vector3(transform.position.x, minHeight, transform.position.z);
        if (vSliderValue == 1f)
            transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
    }

    //拉杆按钮
    void scrollBar_Up()
    {
        clampCamHigth();
        if (transform.position.y > minHeight && transform.position.y <= maxHeight)
        { 
            transform.Translate(new Vector3(0, -1, 0) * scrollbar_Speed*transform.position.y, Space.World);
            SliderValue();
        }
    }
    void scrollBar_Down()
    {
        clampCamHigth();
        if (transform.position.y < maxHeight && transform.position.y >= minHeight)
        {
            transform.Translate(new Vector3(0, 1, 0) * scrollbar_Speed*transform.position.y, Space.World);
            SliderValue();
        }
    }
    void UpdateMouseButton()
    {
        if (up != -1)
        {
            isMoveUp = false;
            isRotateUp = false;
            isScrollbar_Up = false;
            up = -1;
        }

        if (down != -1)
        {
            isMoveDown = false;
            isRotateDown = false;
            isScrollbar_Down = false;
            down = -1;
        }

        if (left != -1)
        {
            isMoveLeft = false;
            isRotateLeft = false;
            left = -1;
        }

        if (right != -1)
        {
            isMoveRight = false;
            isRotateRight = false;
            right = -1;
        }
    }	
    void Moues_Right_Rotate()
    {
        if (Input.GetMouseButton(1))
        {
            if (GUIUtility.hotControl != 0) return;

            float delta_rotation_x = Input.GetAxis("Mouse X") * Time.deltaTime * mouse_Rotate_Speed;
            float delta_rotation_y = -Input.GetAxis("Mouse Y") * Time.deltaTime * mouse_Rotate_Speed;
			
			
            if (transform.eulerAngles.x == 90)
            {
                if (Input.GetAxis("Mouse Y") < 0)
                    delta_rotation_y = 0;
            }
            if (transform.eulerAngles.x == 270)
            {
                if (Input.GetAxis("Mouse Y") > 0)
                    delta_rotation_y = 0;
            }
			
            transform.Rotate(0, delta_rotation_x, 0, Space.World);
            transform.Rotate(delta_rotation_y, 0, 0);
			
        }
    }
	
	
	public void my_Contains(Rect my_Rect)
	{
		Debug.Log(Input.mousePosition);
		
		Vector2 mousePos = Event.current.mousePosition;
		if(my_Rect.Contains(mousePos))
		{
			is_Window = false;
			Debug.Log("Input.mousePosition" + Input.mousePosition);
		}
		else
			is_Window = true;
	}
}
