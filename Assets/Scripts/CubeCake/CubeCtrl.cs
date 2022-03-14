using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCtrl : MonoBehaviour
{
    //큐브케이크의 텍스처를 저장할 배열
    public Texture[] textures;
    //meshRenderer 컴포넌트를 저장할 변수
    private MeshRenderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        //MeshRenderer 컴포넌트를 추출해 저장
        _renderer = GetComponent<MeshRenderer>();
        //난수를 발생시켜 불규칙적인 텍스처를 적용
        _renderer.material.mainTexture = textures[Random.Range(0, textures.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
