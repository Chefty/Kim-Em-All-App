using UnityEngine;
using System.Collections;

public class TurretTracking : MonoBehaviour {

    public float speed = 3.0f;
    float distance;
    Transform m_target = null;
    public float range = 15;
    Vector3 m_lastKnownPosition = Vector3.zero;
    Quaternion m_lookAtRotation;
    public float fireRate = 0.5f;
    public Rigidbody bullet;
    public float speed_bullet = 20;
    float nextFireTime = 0;
    float reloadTime = 0.1f;
    public float timeLeft = 20.0f;

    ScriptHud hudDisplay;
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
            Destroy(GameObject.FindGameObjectWithTag("Turret"));
            timeLeft = 10.0f;
            //hudDisplay.handle_bonus(4, false);
        }
        if (m_target)
          {
              if (m_lastKnownPosition != m_target.transform.position)
              {
                  m_lastKnownPosition = m_target.transform.position;
                  m_lookAtRotation = Quaternion.LookRotation(m_lastKnownPosition - transform.position);
              }

              if (transform.rotation != m_lookAtRotation)
              {
                  transform.rotation = Quaternion.RotateTowards(transform.rotation, m_lookAtRotation, speed * Time.deltaTime);
              }
            if (Time.time >= nextFireTime)
            {
                Shoot();
            }
          }
      }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            nextFireTime = Time.time + (reloadTime * 0.5f);
            m_target = other.gameObject.transform;
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform == m_target)
        {
            m_target = null;
        }
    }

    void Shoot()
    {
        nextFireTime = Time.time + reloadTime;
       // distance = Vector3.Distance(m_target.transform.position, transform.position);
                Rigidbody instantiatedProjectile = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
                instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed_bullet));
    }
}
