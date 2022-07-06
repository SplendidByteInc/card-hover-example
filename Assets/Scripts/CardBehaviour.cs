using UnityEngine;

/// <summary>
/// Defines the behaviour of a card.
/// </summary>
[RequireComponent(typeof(Renderer))]
public class CardBehaviour : MonoBehaviour {

    /// <summary>
    /// The number of degrees that the card may rotate.
    /// </summary>
    const float MaxRotation = 30.0f;

    private Renderer _renderer;

    /// <summary>
    /// Called when the card initializes.
    /// </summary>
    private void Awake() {
        _renderer = GetComponent<Renderer>();
    }

    /// <summary>
    /// Called when a frame is rendered.
    /// </summary>
    private void Update() {
        var bounds = GetScreenBounds();
        var distanceFromCenter = Input.mousePosition - bounds.center;
        var x = Mathf.Clamp(distanceFromCenter.x / bounds.extents.x, -1.0f, 1.0f);
        var y = Mathf.Clamp(distanceFromCenter.y / bounds.extents.y, -1.0f, 1.0f);
        transform.rotation = Quaternion.Euler(y * MaxRotation, -x * MaxRotation, 0.0f);
    }

    /// <summary>
    /// Returns the bounds of the card in screen space.
    /// </summary>
    /// <returns>The bounds</returns>
    private Bounds GetScreenBounds() {
        var boundsMin = Camera.main.WorldToScreenPoint(_renderer.bounds.min);
        var boundsMax = Camera.main.WorldToScreenPoint(_renderer.bounds.max);
        var size = boundsMax - boundsMin;
        var center = boundsMin + size * 0.5f;
        return new Bounds(center, size);
    }
}
