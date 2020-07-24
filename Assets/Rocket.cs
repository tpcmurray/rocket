using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody rocketRB;
    private AudioSource thrustSound;
    private MeshRenderer flame;
    private Light flameLight;

    // Start is called before the first frame update
    void Start()
    {
        rocketRB = GetComponent<Rigidbody>();
        thrustSound = GetComponent<AudioSource>();
        MeshRenderer[] items = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer item in items)
        {
            if (item.name.Equals("Flame"))
            {
                flame = item;
            }
        }

        Light[] lights = GetComponentsInChildren<Light>();

        foreach (Light light in lights)
        {
            if (light.name.Equals("Flame"))
            {
                flameLight = light;
            }
        }
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
                flame.enabled = true;
                flameLight.enabled = true;
            }
        }
        else
        {
            thrustSound.Stop();
            flame.enabled = false;
            flameLight.enabled = false;
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
