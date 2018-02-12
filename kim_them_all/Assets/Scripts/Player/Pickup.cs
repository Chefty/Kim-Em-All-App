using UnityEngine;

namespace CompleteProject
{
    public class Pickup : MonoBehaviour
    {
        public int soju = 0;
        public int bomb = 1;
        public int orb = 0;
        public int turret = 0;
        public int kimchi = 0;

        ScriptHud hudDisplay;

        void Start()
        {
            hudDisplay = GameObject.Find("HudCanvas").GetComponent<ScriptHud>();
        }

        void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.tag == "Bomb")
            {
                Destroy(collider.gameObject);
                bomb += 1;
                hudDisplay.handle_bonus(1, true, bomb);
            }
            else if (collider.gameObject.tag == "Soju")
            {
                Destroy(collider.gameObject);
                soju += 1;
                hudDisplay.handle_bonus(0, true, soju);
            }
            else if (collider.gameObject.tag == "Turret_box")
            {
                Destroy(collider.gameObject);
                turret += 1;
                hudDisplay.handle_bonus(3, true, turret);
            }
            else if (collider.gameObject.tag == "Orb_box")
            {
                Destroy(collider.gameObject);
                orb += 1;
                hudDisplay.handle_bonus(2, true, orb);
            }
            else if (collider.gameObject.tag == "Kimchi_box")
            {
                Destroy(collider.gameObject);
                kimchi += 10;
                hudDisplay.handle_bonus(4, true, kimchi);
            }
        }
    }
}