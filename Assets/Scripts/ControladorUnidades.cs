using UnityEngine;
using System.Collections.Generic;

public class ControladorUnidades : MonoBehaviour
{
    public SeleccionMultiple selector;

    private GrupoUnidades grupoActual = new GrupoUnidades();

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // clic derecho
        {
            if (grupoActual == null) return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 destino = hit.point;
                grupoActual.MoverA(destino);
            }
        }
    }

    public void ActualizarGrupo(List<UnidadMilitar> seleccionadas)
    {
        grupoActual.LimpiarGrupo();
        foreach (UnidadMilitar unidad in seleccionadas)
        {
            grupoActual.AgregarUnidad((IUnidadEjecutable)unidad);
        }
    }
}