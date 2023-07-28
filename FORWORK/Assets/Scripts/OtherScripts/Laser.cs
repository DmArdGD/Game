using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{

	[SerializeField] private float size = 10; // длинна луча
	[SerializeField] private Transform laser; // родительский объект модели луча
	[SerializeField] private Transform Marker; // точка откуда должен вылетать луч
	[SerializeField] private LayerMask ignoreMask; // фильтр по слоям
	private float dist;

	void Create()
	{
		dist = size;
		Vector3 hit = Marker.position + (Marker.localPosition + Marker.forward * dist);
		Vector3 center = (Marker.position + hit) / 2;

		RaycastHit line;
		if (Physics.Linecast(Marker.position, hit, out line, ~ignoreMask))
		{
			if (!line.collider.isTrigger)
			{
				dist = Vector3.Distance(Marker.position, line.point);
				center = (Marker.position + line.point) / 2;
			}

		}

		laser.localScale = new Vector3(1, 1, dist / 2);
		laser.position = center;
		laser.localPosition = new Vector3(0, 0, laser.localPosition.z);
		laser.gameObject.SetActive(true);
	}

	void LateUpdate()
	{
		if (Input.GetMouseButton(0) && (Input.GetKey("shift")))
		{
			Create();
		}
		else
		{
			laser.gameObject.SetActive(false);
		}

	}

}
