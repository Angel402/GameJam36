using Gameplay;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            Vector3 inputPosition;

            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                inputPosition = touch.position;
            }
            else
            {
                inputPosition = Input.mousePosition;
            }

            var ray = Camera.main.ScreenPointToRay(inputPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject objetoTocado = hit.transform.gameObject;
                if (hit.transform.TryGetComponent(out EnemyBehaviour enemyBehaviour))
                {
                    Debug.Log("Tocado/clic en el enemigo: " + objetoTocado.name);
                    enemyBehaviour.GetDamage();
                }
            }
        }
    }
}