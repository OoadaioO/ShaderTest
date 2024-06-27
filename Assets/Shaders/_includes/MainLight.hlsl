

void MainLight_float(out float3 direction){
    #if SHADERGRAPH_PREVIEW
    direction = float3(0.5,0.5,0);
    #else
    direction = normalize(_WorldSpaceLightPos0.xyz);
    #endif
}