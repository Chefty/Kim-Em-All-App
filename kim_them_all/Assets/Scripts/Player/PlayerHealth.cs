using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace CompleteProject
{
    public class PlayerHealth : MonoBehaviour
    {
        public int startingHealth = 100;                            // The amount of health the player starts the game with.
        public int currentHealth;                                   // The current health the player has.
        public AudioClip deathClip;                                 // The audio clip to play when the player dies.
        public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
        public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
        public Rigidbody rb;

        Animator anim;                                              // Reference to the Animator component.
        AudioSource playerAudio;                                    // Reference to the AudioSource component.
        PlayerMovement playerMovement;                              // Reference to the player's movement.
        PlayerShooting playerShooting;                              // Reference to the PlayerShooting script.
        bool isDead;                                                // Whether the player is dead.
        bool damaged;                                               // True when the player gets damaged.
        int LifeNumber;                                             // Player's life number.
        bool playerHitGround;
        bool playerRespawn;

        public ScriptHud hudDisplay;

        void Awake ()
        {
            // Setting up the references.
            anim = GetComponent <Animator> ();
            playerAudio = GetComponent <AudioSource> ();
            playerMovement = GetComponent <PlayerMovement> ();
            playerShooting = GetComponentInChildren <PlayerShooting> ();

            hudDisplay = GameObject.Find("HudCanvas").GetComponent<ScriptHud>();

            // Set the initial health of the player.
            currentHealth = startingHealth;
            LifeNumber = 1;
            playerHitGround = false;
            playerRespawn = false;
            rb = GetComponent<Rigidbody>();
        }


        void Update ()
        {
            // If the player has just been damaged...
            if(playerHitGround && playerRespawn)
            {
                // ... set the colour of the damageImage to the flash colour.
                PlayerReset();
                //rb.isKinematic = true;
                /*foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    go.GetComponent<EnemyHealth>().TakeDamage(10000, new Vector3(go.transform.position.x, go.transform.position.y, go.transform.position.z));
                }*/
                playerRespawn = false;
                playerHitGround = false;
            }
            // Otherwise

            // Reset the damaged flag.
            damaged = false;
        }

        void OnCollisionEnter(Collision hit)
        {
            if (hit.gameObject.tag == "Ground" && playerRespawn == true)
            {
                //Instantiate(GameObject.Find("GroundSlam"), hit.transform);
                playerHitGround = true;
            }
        }

        public void TakeDamage (int amount)
        {
            // Set the damaged flag so the screen will flash.
            damaged = true;

            // Reduce the current health by the damage amount.
            currentHealth -= amount;

            // Play the hurt sound effect.
            playerAudio.Play ();

            // If the player has lost all it's health and the death flag hasn't been set yet...
            if(currentHealth <= 0 && !isDead)
            {
                // ... it should die.
                Death ();
            }
        }


        void Death ()
        {
            hudDisplay.handle_life(0);
            // Set the death flag so this function won't be called again.
            isDead = true;

            // Turn off any remaining shooting effects.
            playerShooting.DisableEffects ();

            // Tell the animator that the player is dead.
            anim.SetTrigger ("Death");
            gameObject.GetComponent<ThirdPersonMouseLook>().enabled = false;

            //Respawn player if enough life remaining
            if (LifeNumber > 0)
                StartCoroutine("Reset", 3);
            /*{
                PlayerRespawn pr = playerManager.GetComponent<PlayerRespawn>();
                pr.Respawn();
            }*/

            // Turn off the movement and shooting scripts.
            playerMovement.enabled = false;
            playerShooting.enabled = false;
         
            // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
            playerAudio.clip = deathClip;
            playerAudio.Play();
        }


        public void RestartLevel ()
        {
            // Reload the level that is currently loaded.
            SceneManager.LoadScene (0);
        }

        public void PlayerRespawn()
        {
            playerRespawn = true;
            gameObject.GetComponent<ThirdPersonMouseLook>().enabled = true;
            anim.ResetTrigger("Death");
            anim.Play("IdleRun");
            //rb.isKinematic = false;
            transform.position = new Vector3(60, 0, 50);
            transform.Translate(Vector3.up * 5, Space.World);
        }

        public void PlayerReset()
        {
            isDead = false;
            currentHealth = 1;
            playerMovement.enabled = true;
            playerShooting.enabled = true;
            playerShooting.EnableEffects();
        }

        IEnumerator Reset(float Count)
        {
            yield return new WaitForSeconds(Count); //Count is the amount of time in seconds that you want to wait.
            PlayerRespawn();
            yield return null;
        }
    }
}