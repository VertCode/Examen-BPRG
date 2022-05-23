using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalSpeed = 5.0F;
    public float verticalSpeed = 5.0F;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    public Camera thirdPersonCamera;
    public Camera firstPersonCamera;

    // Start is called before the first frame update
    void Start()
    {
        firstPersonCamera.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * horizontalSpeed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * verticalSpeed);
        
        rotationX += 1.5F * Input.GetAxis("Mouse Y");
        rotationY += Input.GetAxis("Mouse X");

        rotationX = Mathf.Clamp(rotationX, -30f, 30f);

        if (rotationY > 30 || rotationY < 30)
        {
            transform.eulerAngles = new Vector3(0, rotationY - 30, 0);
        }

        if (Input.GetKeyDown(KeyCode.F11))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
        
        if (Input.GetKeyDown(KeyCode.F5))
        {
            if (firstPersonCamera.gameObject.activeSelf)
            {
                thirdPersonCamera.gameObject.SetActive(true);
                firstPersonCamera.gameObject.SetActive(false);
            }else
            {
                thirdPersonCamera.gameObject.SetActive(false);
                firstPersonCamera.gameObject.SetActive(true);
            }
        }
    }
}