Shader "Unlit/Mask"
{
    Properties
    {
    }
    SubShader
    {
        Tags {
            "RenderType"="Transparent"
            "Queue"="Transparent+1"
        }
        LOD 100
        ZTest Greater
        ZWrite Off
        Cull Front
        ColorMask 0

        Stencil
        {
            Ref 1
            Comp Always
            Pass Replace
        }
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return fixed4(1, 1, 0.5, 0.5);
            }
            ENDCG
        }
    }
}
