using UnityEngine;

public class ConveyorBeltController : MonoBehaviour
{
    Rigidbody rgb;

    public float speed = 2f;
    public float materialSpeed = .1f;

    //MeshRenderer meshRenderer;
    public Material material;

    float yOffset = 0;

    private void Start()
    {
        rgb = GetComponent<Rigidbody>();
        //meshRenderer = GetComponent<MeshRenderer>();
        //if (meshRenderer.Length >= 2) 
        //{
        //    secondMaterial = meshRenderer[;
        //}
    }

    private void FixedUpdate()
    {
        MoveBelt();
    }

    private void MoveBelt()
    {
        Vector3 pos = rgb.position;
        rgb.position += transform.forward * Time.fixedDeltaTime * speed;
        rgb.MovePosition(pos);

        yOffset += Time.fixedDeltaTime * speed;// * materialSpeed;
        //meshRenderer.material.mainTextureOffset = new Vector2(0, yOffset);
        material.mainTextureOffset = new Vector2(0, -yOffset);

    }
}
