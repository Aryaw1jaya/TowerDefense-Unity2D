using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    private Tower _placedTower;

    // Fungsi yang terpanggil sekali ketika ada object Rigidbody yang menyentuh area collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_placedTower != null)
        {
            return;
        }
        Tower tower = collision.GetComponent<Tower>();
        if (tower != null)
        {
            tower.SetPlacePosition(transform.position);
            _placedTower = tower;
        }
    }

    // Kebalikan dari OnTriggerEnter2D, fungsi ini terpanggil sekali ketika object tersebut meninggalkan area collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_placedTower == null)
        {
            return;
        }
        _placedTower.SetPlacePosition(null);
        _placedTower = null;
    }
    public Vector2? PlacePosition { get; private set; }
    public void SetPlacePosition(Vector2? newPosition)
    {
        PlacePosition = newPosition;
    }
}
