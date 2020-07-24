using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody rocketRB;
    private AudioSource thrustSound;
    private ParticleSystem flame;
    private Light rocketLight;

    // Start is called before the first frame update
    void Start()
    {
        rocketRB = GetComponent<Rigidbody>();
        thrustSound = GetComponent<AudioSource>();
        rocketLight = GetComponent<Light>();
        flame = GetChildComponentByName<ParticleSystem>("Flame");
        rocketLight = GetChildComponentByName<Light>("RocketLight");
    }

    private T GetChildComponentByName<T>(string name) where T : Component
    {
        foreach (T component in GetComponentsInChildren<T>(true))
        {
            if (component.gameObject.name == name)
            {
                return component;
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {     
        if (Input.GetKey(KeyCode.Space))
        {
            rocketRB.AddRelativeForce(Vector3.up);
            if (!thrustSound.isPlaying)
            {
                thrustSound.Play();
                flame.Play();
                rocketLight.enabled = true;
            }
        }
        else
        {
            thrustSound.Stop();
            flame.Stop();
            rocketLight.enabled = false;
        }

        rocketRB.freezeRotation = true;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }

        rocketRB.freezeRotation = false;
    }
}
