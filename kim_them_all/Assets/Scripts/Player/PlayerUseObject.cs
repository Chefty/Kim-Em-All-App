using UnityEngine;
using System.Collections;


namespace CompleteProject
{
    public class PlayerUseObject : MonoBehaviour
    {

        // Use this for initialization
        private Pickup invent;
        private PlayerUseSoju _soju;
        private PlayerUseBomb _bomb;
        // Orb 
        private Vector3 Orbpos;
        private Vector3 Orbdist = new Vector3(-4f, 1f, 2f);
        public GameObject Orb;
        // Turret
        public GameObject Turret;
        private Vector3 turdist = new Vector3(1f, 0f, 0f);
        private Vector3 turpos;
        // Kimchi
        public GameObject Fart;
        private Vector3 fartpos = new Vector3(0f, 1f, 0f);
        AudioSource fartsound;

        ScriptHud hudDisplay;

        void Start()
        {
            invent = GetComponent<Pickup>();
            _soju = GetComponent<PlayerUseSoju>();
            _bomb = GetComponent<PlayerUseBomb>();
            hudDisplay = GameObject.Find("HudCanvas").GetComponent<ScriptHud>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("1") && invent.soju > 0)
            {
                invent.soju -= 1;
                hudDisplay.handle_bonus(0, true, invent.soju);
                _soju.UseSoju(hudDisplay);
           
            }
            if (Input.GetKeyDown("2") && invent.bomb > 0)
            {
                invent.bomb -= 1;
                hudDisplay.handle_bonus(1, true, invent.bomb);
                _bomb.UseBomb(hudDisplay);
            }
            if (Input.GetKeyDown("3") && invent.orb > 0)
            {
                invent.orb -= 1;
                Orbpos = transform.position + Orbdist;
                Instantiate(Orb, Orbpos, transform.rotation);
                hudDisplay.handle_bonus(2, true, invent.orb);
            }
            if (Input.GetKeyDown("4") && invent.turret > 0)
            {
                invent.turret -= 1;
                turpos = transform.position + turdist;
                Instantiate(Turret, turpos, transform.rotation);
                hudDisplay.handle_bonus(3, true, invent.turret);
            }
            if (Input.GetKeyDown("5") && invent.kimchi > 0)
            {
                invent.kimchi -= 1;
                fartsound = GetComponent<AudioSource>();
                fartsound.Play();
                Instantiate(Fart, transform.position + fartpos, transform.rotation);
                hudDisplay.handle_bonus(4, true, invent.kimchi);

            }
        }
    }
}
