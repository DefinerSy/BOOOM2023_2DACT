using System;
using UnityEngine;

namespace BillBoard
{
    public class BillBoard : MonoBehaviour
    {
        private Collider2D _collider2D;
        public GameObject indicator;
        public GameObject video;
        private void Start()
        {
            _collider2D = gameObject.GetComponent<BoxCollider2D>();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                indicator.SetActive(true);
            }

            if (other.CompareTag("Player")&& Input.GetKey(KeyCode.E))
            {
                //video.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                indicator.SetActive(false);
            }
        }
    }
}
