using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHover : MonoBehaviour
{
    Rigidbody m_body;
    public GameObject bulletPos;
    public float height;
    public float m_hoverForce = 9.0f;
    int m_layerMask;
    // Start is called before the first frame update
    void Start()
    {
        m_body = GetComponent<Rigidbody>();
        m_layerMask = 1 << LayerMask.NameToLayer("Characters");
        m_layerMask = ~m_layerMask;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        RaycastHit hit;
        if (Physics.Raycast(bulletPos.transform.position, -Vector3.up, out hit,height,m_layerMask))
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(bulletPos.transform.position, hit.point);
            Gizmos.DrawSphere(hit.point, 0.5f);
            
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(bulletPos.transform.position,
                           bulletPos.transform.position - Vector3.up * height);
        }
    }
    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(bulletPos.transform.position, -Vector3.up, out hit, height, m_layerMask))
        {
            m_body.AddForceAtPosition(Vector3.up * m_hoverForce * (1.0f - (hit.distance / height)), bulletPos.transform.position);
        }
        else
            m_body.AddForceAtPosition(bulletPos.transform.up * -m_hoverForce,bulletPos.transform.position);
    }
}
