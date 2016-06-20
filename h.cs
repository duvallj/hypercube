using UnityEngine;
using System.Collections;

public class h : MonoBehaviour {

	public void d(float[]r)
    {
        transform.position=Vector3.back*2.5f;
        GetComponent<Camera>().backgroundColor=Color.black;
        Vector4[]p=new Vector4[16];
        Matrix4x4[]m=new Matrix4x4[6];
        int i = 0;
        for(;i<16;i++)p[i]=new Vector4(i%2,i/2%2,i/4%2,i/8%2)-new Vector4(0.5f,0.5f,0.5f,0.5f);
        int[]S={6,8,1,12,7,11};
        int[]C={5,0,0,0,5,10};
        int[]D={10,10,5,15,15,15};
        for(i=0;i<6;i++)
        {
            m[i]=Matrix4x4.identity;
            r[i]=Mathf.Deg2Rad * r[i];
            float c=Mathf.Cos(r[i]);
            float s=Mathf.Sin(r[i]);
            m[i][C[i]]=c;
            m[i][D[i]]=c;
            m[i][S[i]]=s;
            m[i][S[i]%4*4+S[i]/4]=-s;
        }
        for(i=0;i<16;i++)foreach(Matrix4x4 x in m)p[i]=x*p[i];
        /*int[,] F = { {0,1,3,2 }, {5,4,6,7 }, {1,5,7,3 }, {4,0,2,6 }, {4,5,1,0 }, {3,2,6,7 },
                     {8,9,11,10 }, {13,12,14,15 }, {9,13,15,11 }, {12,8,10,14 }, {12,13,9,8 }, {14,10,11,15 },
                     {0,1,9,8 }, {4,5,13,12 }, {1,5,13,9 }, {4,0,8,12 }, {3,2,10,11 }, {7,6,14,15 },
                     {3,7,15,11 }, {2,6,14,10 }, {2,0,8,10 }, {1,3,11,9 }, {5,7,15,13 }, {6,4,12,14 } };*/
        int[]F={0,1,3,2,5,4,6,7,1,5,7,3,4,0,2,6,4,5,1,0,3,2,6,7,8,9,11,10,13,12,14,15,9,13,15,11,12,8,10,14,12,13,9,8,14,10,11,15,0,1,9,8,4,5,13,12,1,5,13,9,4,0,8,12,3,2,10,11,7,6,14,15,3,7,15,11,2,6,14,10,2,0,8,10,1,3,11,9,5,7,15,13,6,4,12,14};
        for (i=0;i<96;i+=4)
        {
            LineRenderer l = new GameObject().AddComponent<LineRenderer>();
            l.SetVertexCount(5);
            l.SetPositions(new Vector3[]{p[F[i]],p[F[i+1]],p[F[i+2]],p[F[i+3]],p[F[i]]});
            l.material=new Material(Shader.Find("Sprites/Default"));
            l.SetWidth(0.01f,0.01f);
            l.tag = "Player";
        }
    }
    public float[] input;
    void Start()
    {
        d(input);
    }
}
