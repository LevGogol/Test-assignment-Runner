using UnityEngine;

namespace TestAssignment
{
    public class MyInput
    {
        public bool IsTouch => Input.GetMouseButton(0);
        
        public float GetMouseOffsetX()
        {
            return Input.GetMouseButton(0) ? Input.GetAxis("Mouse X") / Screen.width : 0;
        }
    }
}