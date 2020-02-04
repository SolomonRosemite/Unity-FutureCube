using UnityEngine;

public class ChangeCamColor : MonoBehaviour
{
    public static ChangeCamColor ins;

    public Color color1;
    public Color color2;
    public float duration = 3.0F;

    public Transform tr;
    public Camera cam;

    public float Speed;

    [HideInInspector]
    public bool StartReverse = false;

    private bool StartRotate = true;

    void Start()
    {
        ins = this;
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
    }

    void Update()
    {
        if (StartReverse == true)
        {
            float t = Mathf.PingPong(Time.time, duration) / duration;
            cam.backgroundColor = Color.Lerp(color1, color2, t);
            
            if (StartRotate == true)
            {
                tr.Rotate(Vector3.up, 10.0f * Time.deltaTime * Speed);

                if (tr.rotation.y >= 0.9999)
                {
                    StartRotate = false;
                }
            }

            if (StartReverse == false)
            {
                tr.rotation = Quaternion.identity;
            }
        }

    }
}