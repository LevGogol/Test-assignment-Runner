using UnityEngine;

namespace TestAssignment
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private GameObject _finalScreen;
        [SerializeField] private Finish _finish;
        
        void Start()
        {
            _finalScreen.SetActive(false);
            _finish.OnFinish += EnableFinalScreen;
        }

        private void EnableFinalScreen()
        {
            _finalScreen.SetActive(true);
        }
    }
}
