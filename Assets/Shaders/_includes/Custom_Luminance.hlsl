#ifndef LUMINANCE_CUSTOM
#define LUMINANCE_CUSTOM

void Luminance_float(float3 color,out float value){
    value = 0.2125 * color.r + 0.7154 * color.g + 0.0721 * color.b; 
}

#endif