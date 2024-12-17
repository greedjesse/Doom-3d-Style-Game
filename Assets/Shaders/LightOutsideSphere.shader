Shader "Unlit/LightOutsideSphere"
{
    Properties
    {
        [HDR]_Color ("Color", Color) = (1, 1, 1, 0.5)
    }
    SubShader
    {
        Tags { 
            "RenderType"="Transparent"
            "Queue"="Transparent+1"
        }
        LOD 100
        Zwrite Off
        Blend DstColor One

        Stencil
        {
            Ref 1
            Comp Equal
            Pass Zero
            Fail Zero
            Zfail Zero
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
            
            float4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return _Color * _Color.a;
            }
            ENDCG
        }
    }
}
