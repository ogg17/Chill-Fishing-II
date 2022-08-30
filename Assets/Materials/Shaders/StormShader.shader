Shader "Custom/Storm"
{
    Properties
    {
        _NoiseScale ("Scale", Float) = 0.75
        _Speed ("Speed", Float) = 10
        _Fill ("Fill", Float) = 10
        _Size ("Size", Float) = 10
        _TOffset ("TOffset", Float) = 2.5
        _Color ("Color", Color) = (1,1,1,1)
        
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
            #include "Packages/jp.keijiro.noiseshader/Shader/SimplexNoise2D.hlsl"

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
            float _Speed;
            float _Size;
            float _Fill;
            float _TOffset;

            float4 Fragment(float4 position : SV_Position,
                            float2 uv : TEXCOORD) : SV_Target
            {           
                float2 coord = uv * _Size;     
                coord.x -= _Time.y*_Speed;                        
                const float output = _TOffset + SimplexNoise(coord);                

                return float4(_Color.x, _Color.y, _Color.z, output * _Color.w);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}