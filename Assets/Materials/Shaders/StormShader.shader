Shader "Noise"
{
    Properties
    {
        
    }

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
        float o = 0.5;
        float s = 1;
        float w = 0.5;

        for (int i = 0; i < 3; i++)
        {            
            float2 coord = uv * s;        

            o += ClassicNoise(coord) * w;            

            s *= 2.0;
            w *= 0.5;
        }
        
        return float4(o, o, o, 1);
       
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