using UnityEngine;

public class ReflectionProbeControl : MonoBehaviour
{
    public float renderDis;

    ReflectionProbe probe;
    Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        probe = GetComponent<ReflectionProbe>();
        cam = GameObject.FindWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float dot = Vector3.Dot(cam.TransformDirection(Vector3.forward), transform.TransformDirection(Vector3.forward));
        float dis = Vector3.Distance(cam.position, transform.position);       

        if (dot < 0 && Vector3.Distance(cam.position, transform.position) <= renderDis)
            probe.RenderProbe();
    }
}
