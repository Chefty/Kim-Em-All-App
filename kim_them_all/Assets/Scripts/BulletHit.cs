using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class BulletHit : MonoBehaviour
    {

        private EnemyHealth enemyhealth;
        private GameObject enemyhit;
        public int Damage = 10;

        // Use this for initialization
        void Start()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                enemyhit = other.gameObject;
                enemyhealth = enemyhit.GetComponent<EnemyHealth>();
                enemyhealth.TakeDamage(20, enemyhit.transform.position);
                Destroy(this.gameObject);
            }
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
