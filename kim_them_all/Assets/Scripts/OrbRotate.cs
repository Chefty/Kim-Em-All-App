using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class OrbRotate : MonoBehaviour
    {
        public float timeLeft = 10.0f;
        Vector3 posPlayer;
        GameObject m_target;
        Transform target;
        public float orbitDistance = 10.0f;
        public float orbitDegreesPerSec = 180.0f;
        public Vector3 relativeDistance = Vector3.zero;
        private EnemyHealth enemyhealth;
        private int Damage;

        ScriptHud hudDisplay;

        // Use this for initialization
        void Start()
        {
            m_target = GameObject.FindGameObjectWithTag("Player");
            target = m_target.transform;

            hudDisplay = GameObject.Find("HudCanvas").GetComponent<ScriptHud>();
            if (target != null)
            {
                relativeDistance = transform.position - target.position;
            }
        }

        void Orbit()
        {
            if (target != null)
            {
                transform.position = target.position + relativeDistance;
                transform.RotateAround(target.position, Vector3.up, orbitDegreesPerSec * Time.deltaTime);
                relativeDistance = transform.position - target.position;
            }
        }

        void LateUpdate()
        {
            timeLeft -= Time.deltaTime;
            Orbit();
            if (timeLeft < 0)
            {
                Destroy(this.gameObject);
                timeLeft = 10.0f;
                //hudDisplay.handle_bonus(3, false);
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
