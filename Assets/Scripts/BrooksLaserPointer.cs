using UnityEngine;
using System.Collections;

public class BrooksLaserPointer : MonoBehaviour {

    public Color color;
    public float thickness = 0.002f;
    public GameObject holder;
    public GameObject pointer;
    public bool addRigidBody = false;
    [HideInInspector]
    public bool bHit;
    public RaycastHit hit;

    Transform previousContact = null;


	// Use this for initialization
	void Start () {
        holder = new GameObject();
        holder.transform.parent = this.transform;
        holder.transform.localPosition = Vector3.zero;

        pointer = GameObject.CreatePrimitive(PrimitiveType.Cube);
        pointer.transform.parent = holder.transform;
        pointer.transform.localScale = new Vector3(thickness, thickness, 100f);
        pointer.transform.localPosition = new Vector3(0f, 0f, 50f);
        BoxCollider collider = pointer.GetComponent<BoxCollider>();

        if(addRigidBody)
        {
            if(collider)
            {
                collider.isTrigger = true;
            }
            Rigidbody rigidBody = pointer.AddComponent<Rigidbody>();
            rigidBody.isKinematic = true;
        }
        else
        {
            if(collider)
            {
                Object.Destroy(collider);
            }
        }
        Material newMaterial = new Material(Shader.Find("Unlit/Color"));
        newMaterial.SetColor("_Color", color);
        pointer.GetComponent<MeshRenderer>().material = newMaterial;
    }

    // Update is called once per frame
    void Update() {
        SteamVR_TrackedController controller = GetComponent<SteamVR_TrackedController>();

        float dist = 100f;

        Ray raycast = new Ray(transform.position, transform.forward);
        bHit = Physics.Raycast(raycast, out hit);
        

        if (!bHit)
        {
            previousContact = null;
        }
        if (bHit && hit.distance < 100f)
        {
            dist = hit.distance;
        }

        if(controller != null && controller.triggerPressed)
        {
            pointer.transform.localScale = new Vector3(thickness * 5f, thickness * 5f, dist);
        }
        else
        {
            pointer.transform.localScale = new Vector3(thickness, thickness, dist);
        }

        pointer.transform.localPosition = new Vector3(0f, 0f, dist / 2f);
	}
}
