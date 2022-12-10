Shader "Unlit/texture"{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
    }
        SubShader
    {
        Tags
        {
            "Queue" = "Transparent"
        }

        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
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
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                //ïÅí 
                fixed4 col = tex2D(_MainTex, i.uv);

            //É^ÉCÉäÉìÉO
            //float2 tiling = float2(2,3);
            //fixed4 col = tex2D(_MainTex, i.uv*tiling);

            //float2 offset = float2(0.2,0.3);
            //fixed4 col = tex2D(_MainTex, i.uv + offset);

            return col;
             }
        ENDCG
        }
 
    }
}