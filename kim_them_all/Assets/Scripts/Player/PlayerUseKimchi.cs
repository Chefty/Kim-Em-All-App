using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class PlayerUseKimchi : MonoBehaviour
    {
        private EnemyHealth enemyhealth;
        private int Damage;
        public float timeLeft = 4.0f;
        ScriptHud hudDisplay;

        // Use this for initialization
        void Start()
        {

            hudDisplay = GameObject.Find("HudCanvas").GetComponent<ScriptHud>();
        }

        // Update is called once per frame
        void Update()
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Destroy(this.gameObject);
                timeLeft = 4.0f;
                //hudDisplay.handle_bonus(5, false);
            }
        }

        void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.tag == "Enemy")
            {
                enemyhealth = collider.GetComponent<EnemyHealth>();
                Damage = enemyhealth.currentHealth;
                enemyhealth.TakeDamage(Damage, collider.transform.position);
            }
        }
    }
}
