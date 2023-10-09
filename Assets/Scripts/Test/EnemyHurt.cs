using UnityEngine;

namespace Test
{
    public class EnemyHurt : MonoBehaviour
    {
        Character _character;
        private void Awake()
        {
            _character=GetComponentInParent<Character>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerHurt>().Hurt(1);
            }
        }
    }
}