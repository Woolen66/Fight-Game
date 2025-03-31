Shader "Custom/TransparentSprite"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _ColorKey ("Color Key", Color) = (0, 0, 1, 1) // Azul
        _Tolerance ("Tolerance", Range(0, 1)) = 0.1
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "RenderType"="Transparent"}
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            fixed4 _ColorKey;
            float _Tolerance;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                float diff = distance(col.rgb, _ColorKey.rgb);

                if (diff < _Tolerance)
                    discard;

                return col;
            }
            ENDCG
        }
    }
}
