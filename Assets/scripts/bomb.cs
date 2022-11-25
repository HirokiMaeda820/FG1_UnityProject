using UnityEngine;


public class bomb : MonoBehaviour
{
    //[SerializeField] ParticleSystem m_particle;
    public Goal _goal;

    [SerializeField] float m_force = 20;
    [SerializeField] float m_radius = 5;
    [SerializeField] float m_upwards = 5;
    Vector3 m_position;

    bool flag = false;

    void Start()
    {
        flag = false;
    }

    void Update()
    {
        if ((_goal.GetIsGoal() || Input.GetKeyDown(KeyCode.Return)) && (flag == false))
        {
            Explosion();
            flag = true;
            Debug.Log("‚Î‚­‚Í‚Â");
        }
    }

    public void Explosion()
    {
        // m_particle.Play();
        // m_position = m_particle.transform.position;

        // ”ÍˆÍ“à‚ÌRigidbody‚ÉAddExplosionForce
        Collider[] hitColliders = Physics.OverlapSphere(m_position, m_radius);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            var rb = hitColliders[i].GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddExplosionForce(m_force, m_position, m_radius, m_upwards, ForceMode.VelocityChange);
            }
        }
        
    }
}