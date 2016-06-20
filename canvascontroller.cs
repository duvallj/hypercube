using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class canvascontroller : MonoBehaviour {

    public InputField[] sliders;
    public h doer;

    void Update()
    {
        GameObject[] toDelete = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(toDelete.Length);
        for(int i=0; i<toDelete.Length; i++)
        {
            Destroy(toDelete[i]);
        }
        float[] f = new float[6];
        for(int i=0; i<6; i++)
        {
            float num;
            bool res = float.TryParse(sliders[i].text, out num);
            if(res)
            {
                f[i] = num;
            }
            else
            {
                f[i] = 0;
            }
        }
        doer.d(f);
    }
}
