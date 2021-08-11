using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestAssignment
{
    public class Restart : MonoBehaviour
    {
        public void RestartButton()
        {
            SceneManager.LoadScene(0);
        }
    }
}
