Shader "Custom/Storm"
{
    Properties
    {
        _NoiseScale ("Float", Float) = 0.75
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    
    SubShader
    {
        Tags
        {
            "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"
        }
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        //Cull front 
        LOD 100
        Pass
        {
            CGPROGRAM
            #pragma vertex Vertex
            #pragma fragment Fragment

            #include "UnityCG.cginc"
            #include "Packages/jp.keijiro.noiseshader/Shader/SimplexNoise3D.hlsl"
            //#include "Assets/Materials/Shaders/PsrdNoise2D.hlsl"
            //#include "Assets/Materials/Shaders/PsrdNoise3D.hlsl"

            void Vertex(float4 position : POSITION,
                        float2 uv : TEXCOORD,
                        out float4 outPosition : SV_Position,
                        out float2 outUV : TEXCOORD)
            {
                outPosition = UnityObjectToClipPos(position);
                outUV = uv;
            }

            float4 _Color;
            float _NoiseScale;

            float4 Fragment(float4 position : SV_Position,
                            float2 uv : TEXCOORD) : SV_Target
            {
                uv = uv * 10;
                const float size = 1;

                float2 coord = uv * size;                                
                float a = sin(coord.x*UNITY_PI/2.5)*10;
                float b = cos(coord.x*UNITY_PI/2.5)*10;
                const float3 inp = float3(a, b, coord.y)*_NoiseScale;
                const float output = SimplexNoise(inp + _CosTime.y);                

                return float4(_Color.x, _Color.y, _Color.z, output * _Color.w);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}