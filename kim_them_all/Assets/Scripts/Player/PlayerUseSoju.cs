using UnityEngine;
using System;

namespace CompleteProject
{
    public class PlayerUseSoju : MonoBehaviour
    {
        private bool _triggered = false;
        public float timeLeft = 10.0f;
        private PlayerHealth player;
        private EnemyHealth enemyhealth;
        private ScriptHud _hudDisplay;
        GameObject SojuAura;

        public void Start()
        {
        }

        public void UseSoju(ScriptHud hudDisplay)
        {
            player = GetComponent<PlayerHealth>();
            SojuAura = GameObject.FindGameObjectWithTag("SojuAura");
            if (SojuAura == null)
            {
                SojuAura = (GameObject)Instantiate(Resources.Load("SojuAura"), transform.position + new Vector3(0, 1f, 0), transform.rotation);
                SojuAura.transform.parent = GameObject.Find("Player").transform;
            }
            else
                return;
            _triggered = true;
            _hudDisplay = hudDisplay;
            player.currentHealth = 10000;
        }

        void Update()
        {
            if (_triggered == true)
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft < 0)
                {
                    _triggered = false;
                    player.currentHealth = 1;
                    timeLeft = 10.0f;
                    Destroy(GameObject.FindGameObjectWithTag("SojuAura"));
                    // _hudDisplay.handle_bonus(0, false);
                }
            }
        }

        void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.tag == "Enemy" && _triggered == true)
            {
                enemyhealth = collider.GetComponent<EnemyHealth>();
                enemyhealth.TakeDamage(enemyhealth.currentHealth, collider.transform.position);
            }
        }
    }
}
