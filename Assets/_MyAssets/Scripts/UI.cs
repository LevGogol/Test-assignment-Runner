using UnityEngine;

namespace TestAssignment
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private GameObject _finalScreen;
        
        void Start()
        {
            _finalScreen.SetActive(false);
        }

        public void EnableFinalScreen()
        {
            _finalScreen.SetActive(true);
        }
    }
}
