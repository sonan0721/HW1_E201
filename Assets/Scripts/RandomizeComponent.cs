using TMPro;
using UniRx;
using UnityEngine;

public class RandomizeComponent : MonoBehaviour
{
    private TextMeshPro text;
    void Start()
    {
        text = GetComponentInChildren<TextMeshPro>();
        text.gameObject.SetActive(false);
     
        UiHolder.UIOn.Subscribe(
            x =>
            {
                text.gameObject.SetActive(x);
            });
        
        // Setting
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationY;
        Randomize();
    }

    private void Randomize()
    {
        var material = GetComponent<Renderer>().material;
        material.color = new Color(Random.value, Random.value, Random.value);
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector3((Random.value*2) - 1, (Random.value*2) - 1, 0) * 3;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = gameObject.transform.position.ToString();
        
        if (Input.GetMouseButtonDown(0))
        {
            var screenRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            var ray = Physics.Raycast(screenRay, out var hitInfo);

            if (ray && hitInfo.collider.gameObject == gameObject)
            {
                Randomize();
            }
        }
    }
}
