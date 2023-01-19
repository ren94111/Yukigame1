using System.Collections.Generic;
using UnityEngine;

namespace Sora_Item
{
    public class ItemObjectPool : MonoBehaviour
    {
        private List<GameObject> objectPoolList = new(10);
        public void Create(GameObject createObj,ItemController _controller)
        {
            GameObject obj = Instantiate(createObj);
            obj.SetActive(false);
            if (obj.GetComponent<GetItem>())
            {
                obj.GetComponent<GetItem>().Init(_controller);
            }
            else
            {
                obj.AddComponent<GetItem>().Init(_controller);
            }
            obj.transform.parent = transform;
            objectPoolList.Add(obj);
        }

        public GameObject GetCreateObj(Transform parentobj)
        {
            GameObject obj = objectPoolList[0];
            obj.SetActive(true);
            obj.transform.parent = parentobj;
            obj.transform.position = parentobj.position;
            objectPoolList.Remove(obj);
            return obj;
        }

        public bool CheckPoolList()
        {
            if(objectPoolList.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteObj(GameObject obj)
        {
            objectPoolList.Add(obj);
            obj.SetActive(false);
            obj.transform.parent = transform;
        }
    }
}