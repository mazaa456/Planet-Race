using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(Rigidbody))]
public class HoverCarControl : MonoBehaviour
{
    public GameObject Cpoint;
    Rigidbody m_body;
    float m_deadZone = 0.1f;
    public GameObject bullet;
    public float m_hoverForce = 9.0f;
    public float m_hoverForceDown = 9.0f;
    public float m_hoverHeight = 2.0f;
    public GameObject[] m_hoverPoints;
    public GameObject shootpoint;
    public float m_forwardAcl = 100.0f;
    public static float currentMoveSpeed;
    public float m_backwardAcl = 25.0f;
    float m_currThrust = 0.0f;

    public float m_turnStrength = 10f;
    float m_currTurn = 0.0f;
    public static float turnAxis;
    public static float aclAxis;
    private int ammo;
    int m_layerMask;
    private float boostTimer;
    private float hitTimer;
    private float slowTimer;
    private bool hiting;
    private bool boosting;
    private bool slowing;
    private int speedItem=0;

    public Transform speedLines;
    public Transform speedBoost;

    public AudioSource shockSound;
    public AudioSource ShootBeam;
    public AudioSource ItemCollect;

    public Transform changePS;

    [SerializeField] private Image missileImage;
    [SerializeField] private Image turboImage;


    void Start()
    {
        m_body = GetComponent<Rigidbody>();
        hiting = false;
        m_layerMask = 1 << LayerMask.NameToLayer("Characters");
        m_layerMask = ~m_layerMask;
        boostTimer = 0;
        boosting = false;
        ammo = 0;
        speedLines.GetComponent<ParticleSystem>().enableEmission = false;
        speedBoost.GetComponent<ParticleSystem>().enableEmission = false;      
    }

    void OnDrawGizmos()
    {

        //  Hover Force
        RaycastHit hit;
        for (int i = 0; i < m_hoverPoints.Length; i++)
        {
            var hoverPoint = m_hoverPoints[i];
            if (Physics.Raycast(hoverPoint.transform.position,
                                -Vector3.up, out hit,
                                m_hoverHeight,
                                m_layerMask))
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(hoverPoint.transform.position, hit.point);
                Gizmos.DrawSphere(hit.point, 0.5f);
            }
            else
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(hoverPoint.transform.position,
                               hoverPoint.transform.position - Vector3.up * m_hoverHeight);
            }
        }
    }

    void Update()
    {

        // Main Thrust
        m_currThrust = 0.0f;
        //float aclAxis = Input.GetAxis("Fire1");
        if (aclAxis > m_deadZone)
            m_currThrust = aclAxis * m_forwardAcl;
        else if (aclAxis < -m_deadZone)
            m_currThrust = aclAxis * m_backwardAcl;

        // Turning
        m_currTurn = 0.0f;
        //float turnAxis = Input.GetAxis("Fire2");
        if (Mathf.Abs(turnAxis) > m_deadZone)
            if (aclAxis < -m_deadZone)
                m_currTurn = -turnAxis;
            else m_currTurn = turnAxis;

    }

    void FixedUpdate()
    {

        //  Hover Force
        RaycastHit hit;
        for (int i = 0; i < m_hoverPoints.Length; i++)
        {
            var hoverPoint = m_hoverPoints[i];
            if (Physics.Raycast(hoverPoint.transform.position,-Vector3.up, out hit,m_hoverHeight,m_layerMask))
                m_body.AddForceAtPosition(Vector3.up* m_hoverForce* (1.0f - (hit.distance / m_hoverHeight)),hoverPoint.transform.position);
            else
            {
                if (transform.position.y > hoverPoint.transform.position.y)
                    m_body.AddForceAtPosition(
                      hoverPoint.transform.up * m_hoverForce,
                      hoverPoint.transform.position);
                else
                    m_body.AddForceAtPosition(
                      hoverPoint.transform.up * -m_hoverForceDown,
                      hoverPoint.transform.position);
            }
        }

        // Forward
        if (LapManager.Lap <= 3 && TimeManager.timeValue >= 0f)
        {
            if (Mathf.Abs(m_currThrust) > 0)
                m_body.AddForce(transform.forward * m_currThrust);
            
            // Turn
            if (m_currTurn > 0)
            {
                m_body.AddRelativeTorque(Vector3.up * m_currTurn * m_turnStrength);
            }
            else if (m_currTurn < 0)
            {
                m_body.AddRelativeTorque(Vector3.up * m_currTurn * m_turnStrength);
            }
        }
        if (boosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= 1.5)
            {
                m_forwardAcl = 20000;
                boostTimer = 0;
                boosting = false;
                if (speedItem<0)
                {
                    speedItem = 0;
                }
            }
        }
        if (slowing)
        {
            slowTimer += Time.deltaTime;
            if (slowTimer >= 1.5)
            {
                m_forwardAcl = 20000;
                slowTimer = 0;
                slowing = false;
            }
        }
        if (hiting)
        {
            hitTimer--;
            if (m_forwardAcl < 11000)
                m_forwardAcl += 10;
            if (hitTimer <= 0)
            {
                hiting = false;
                m_forwardAcl = 11000;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpeedBoost")
        {
            boosting = true;
            m_forwardAcl = 24000;
            speedLines.GetComponent<ParticleSystem>().enableEmission = true;
            StartCoroutine(stopspeedLines());
            speedBoost.GetComponent<ParticleSystem>().enableEmission = true;
            StartCoroutine(stopspeedBoost());
            changePS.GetComponent<ParticleSystem>().enableEmission = false;
            StartCoroutine(changeps());
        }
        else if (other.tag == "Slow")
        {
            slowing = true;
            m_forwardAcl = 5000;
            shockSound.Play();      
        }
        if (other.gameObject.tag == "Bullet")
        {
            hitTimer = 200;
            hiting = true;
            m_forwardAcl = 00;
        }
        if (other.gameObject.tag == "AmmoItem")
        {
            if (ammo==0)
            {
                ammo++;
                missileImage.enabled = true;
                turboImage.enabled = false;
                ItemCollect.Play();
            }
        }
        if (other.gameObject.tag == "SpeedItem")
        {
            speedItem = 1;
            turboImage.enabled = true;
            missileImage.enabled = false;
            ItemCollect.Play();
        }
        if(other.gameObject.tag == "CPoint")
        {
            Cpoint = other.gameObject;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Map")
        {
            transform.position = Cpoint.transform.position;
            transform.rotation = Cpoint.transform.rotation;
        }
    }
    IEnumerator stopspeedLines()
    {
        yield return new WaitForSeconds(1.5f);

        speedLines.GetComponent<ParticleSystem>().enableEmission = false;
    }

    IEnumerator stopspeedBoost()
    {
        yield return new WaitForSeconds(1.5f);

        speedBoost.GetComponent<ParticleSystem>().enableEmission = false;
    }

    IEnumerator changeps()
    {
        yield return new WaitForSeconds(1.5f);

        changePS.GetComponent<ParticleSystem>().enableEmission = true;
    }  


    public void OnMoveHorizon(CallbackContext c)
    {
        turnAxis = c.ReadValue<float>();
    }

    public void OnMoveVertical(CallbackContext c)
    {
        aclAxis = c.ReadValue<float>();

    }
    public void OnFire()
    {
        if (ammo > 0)
        {
            shoot();
            ShootBeam.Play();
            ammo--;
            missileImage.enabled = false;
        }
    }
    public void OnBoots()
    {
        if(speedItem>0)
        {
            speedLines.GetComponent<ParticleSystem>().enableEmission = true;
            StartCoroutine(stopspeedLines());
            speedBoost.GetComponent<ParticleSystem>().enableEmission = true;
            StartCoroutine(stopspeedBoost());
            changePS.GetComponent<ParticleSystem>().enableEmission = false;
            StartCoroutine(changeps());
            speedItem = -1;
            m_forwardAcl = 30000;
            boosting = true;
            boostTimer = 0;
            turboImage.enabled = false;
        }
    }
    void shoot()
    {
        GameObject newBullet = Instantiate(bullet, shootpoint.transform.position, shootpoint.transform.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10000);
        Destroy(newBullet, 7f);
    }
}


