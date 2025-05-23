Shader "Custom/RevealCursorShader"
{
    Properties
    {
        _Color("Overlay Color", Color) = (0,0,0,1)
        _Radius("Radius", Float) = 0.2
        _Mouse("Mouse Position", Vector) = (0.5, 0.5, 0, 0)
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            fixed4 _Color;
            float _Radius;
            float2 _Mouse;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float dist = distance(i.uv, _Mouse);
                float mask = smoothstep(_Radius * 0.2, _Radius, dist);
                return fixed4(_Color.rgb, _Color.a * mask);
            }
            ENDCG
        }
    }
}
