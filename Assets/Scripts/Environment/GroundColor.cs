using System.Collections.Generic;
using UnityEngine;

public class GroundColor : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Material groundMaterial;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private Color closeColor;

    private readonly Dictionary<GameObject, Material> _cubeMaterials = new();

    private void Start()
    {
        foreach (Transform child in transform)
        {
            var rendererComponent = child.GetComponent<Renderer>();
            if (rendererComponent == null) continue;
            var materialInstance = new Material(groundMaterial); 
            rendererComponent.material = materialInstance; 
            _cubeMaterials[child.gameObject] = materialInstance;
        }
    }

    private void Update()
    {
        foreach (var (cube, material) in _cubeMaterials)
        {
            var distance = Vector3.Distance(cube.transform.position, player.position);

            var transparency = Mathf.Clamp01(1 - (distance / maxDistance));
            
            var color = Color.Lerp(Color.clear, closeColor, transparency);
            material.color = color;
        }
    }
}