using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float SpeedX, SpeedY;
    public bool fire = false;

    private void Start()
    {
        SetAsDefault();
    }

    void Update()
    {
        SpeedX = Input.GetAxisRaw("Horizontal");
        SpeedY = Input.GetAxisRaw("Vertical");
        fire = Input.GetKey(KeyCode.Mouse0);
    }
    
    void SetAsDefault()
    {
        SpeedX = 0;
        SpeedY = 0;
        fire = false;
    }
}
