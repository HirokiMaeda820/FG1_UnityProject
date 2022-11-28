using UnityEngine;

public class bomb : MonoBehaviour
{
    //[SerializeField] ParticleSystem m_particle;
    private GameObject _goal;
    private Goal _goalScript;

    [SerializeField] float m_force = 20;
    [SerializeField] float m_radius = 5;
    [SerializeField] float m_upwards = 5;
    Vector3 m_position;

    public GameObject centerCube;

    bool flag = false;

    void Start()
    {
        flag = false;
        _goal = GameObject.Find("GoalCollider");
        _goalScript = _goal.GetComponent<Goal>();
    }

    void Update()
    {
        if ((_goalScript.GetIsGoal() || Input.GetKeyDown(KeyCode.Return)) && (flag == false))
        {
            if (centerCube.activeSelf == false)
            {
                Explosion();
                flag = true;
                Debug.Log("‚Î‚­‚Í‚Â");
            }
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