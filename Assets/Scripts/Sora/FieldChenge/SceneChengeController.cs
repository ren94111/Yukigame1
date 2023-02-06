using System.Collections.Generic;
using UnityEngine;

namespace Sora_Field
{
    public class SceneChengeController : MonoBehaviour
    {
        [SerializeField]
        private List<Camera> sceneCameras;

        void Start()
        {
            for (int i = 1; i < sceneCameras.Count; i++)
            {
                sceneCameras[i].gameObject.SetActive(false);
            }
            sceneCameras[0].gameObject.SetActive(true);
        }
        public void ChengeCamera(int _camera)
        {
            for (int i = 0; i < sceneCameras.Count; i++)
            {
                sceneCameras[i].gameObject.SetActive(false);
            }
            Debug.Log(_camera);
            sceneCameras[_camera].gameObject.SetActive(true);
        }

        public int GetCameraValue()
        {
            return sceneCameras.Count;
        }
    }
}