using UnityEngine;
using System.Collections;
using CompleteProject;

public class nuke_explode : MonoBehaviour {

    private GameObject[] enemies;
    GameObject explode;
    private EnemyHealth enemyhealth;
    private int Damage;
    private int i = 0;
    private AudioSource audioSource;

    public void UseBomb(ScriptHud hudDisplay){}
    
    // Use this for initialization
    void Start () {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().AddForce(1, -50000, 1);
    }

    void OnTriggerEnter(Collider collider)
    {
        audioSource.Play();
        GameObject.FindGameObjectWithTag("Bomb").GetComponent<Collider>().enabled = false;
        explode = (GameObject)Instantiate(Resources.Load("NuclearExplode"), new Vector3(60, 0, 50), Quaternion.identity);
        StartCoroutine(kill_enemies(0f));
        Destroy(explode, 2f);
        Destroy(GameObject.FindGameObjectWithTag("Bomb"), 5f);
    }

    IEnumerator kill_enemies(float Count)
    {
        //yield return new WaitForSeconds(Count); //Count is the amount of time in seconds that you want to wait.
        if (enemies.Length <= 0)
            yield return null;
        while (i < enemies.Length)
        {
            if (enemies[i].gameObject != null)
            {
                enemyhealth = enemies[i].GetComponent<EnemyHealth>();
                Damage = enemyhealth.currentHealth;
                enemyhealth.TakeDamage(Damage, enemies[i].transform.position);
            }
            i += 1;
        }
        yield return null;
    }
}
