Shader "Noise"
{
    Properties {}

    CGINCLUDE
    #include "UnityCG.cginc"
    #include "Packages/jp.keijiro.noiseshader/Shader/ClassicNoise2D.hlsl"

    void Vertex(float4 position : POSITION,
                float2 uv : TEXCOORD,
                out float4 outPosition : SV_Position,
                out float2 outUV : TEXCOORD)
    {
        outPosition = UnityObjectToClipPos(position);
        outUV = uv;
    }

    float4 Fragment(float4 position : SV_Position,
                    float2 uv : TEXCOORD) : SV_Target
    {
        uv = uv * 4 + float2(-1, 1) * _Time.y;
        float output = 0.5;
        float size = 1;
        float width = 0.5;

        for (int i = 0; i < 3; i++)
        {
            float2 coord = uv * size;
            output += ClassicNoise(coord) * width;
        }

        return float4(output, output, output, 1);
    }
    ENDCG

    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex Vertex
            #pragma fragment Fragment
            ENDCG
        }
    }
}