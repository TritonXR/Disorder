Shader "Custom/InvertNormals" {
  Properties
  {
    [NoScaleOffset]_MainTex("Texture (RGB)", 2D) = "white" {}
  }
    SubShader
  {
    Tags{ "RenderType" = "Opaque" }
    Cull Front

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
    float3 normal : NORMAL;
  };

  struct v2f
  {
    float4 vertex : SV_POSITION;
    float2 uv : TEXCOORD0;
  };
  sampler2D _MainTex;

  v2f vert(appdata v)
  {
    v2f o;
    o.vertex = UnityObjectToClipPos(v.vertex);
    o.uv = float2(v.uv.x, v.uv.y);
    v.normal = v.normal * -1;
    return o;
  }

  fixed4 frag(v2f i) : SV_Target
  {
    return tex2D(_MainTex, i.uv);
  }
    ENDCG
  }
  }
}