// +kff20

#version 3.5;

#include "colors.inc"

global_settings {
  assumed_gamma 1.0
  max_trace_level 150
}

//#declare S=seed(frame_number);
#declare S=seed(3);//85//1598

// ----------------------------------------

#declare camx = rand(S);
#declare camy = rand(S);
#declare camz = rand(S);

#declare lookx = rand(S);
#declare looky = rand(S);
#declare lookz = rand(S);

camera {
  //location  <1, 10, 1>*.25
  //look_at   <0, 1, 0>
  //location <0, 0.75, 0>
  //look_at <1, -0.5, 0>                     
  location <camx, camy, camz>*2-1
  look_at <lookx, looky, lookz>*2-1+<1.748,-.735,0>
  angle .3
}

sky_sphere {
  pigment {
    gradient y
    color_map {
      [0.0 rgb <0.6,0.7,1.0>]
      [0.7 rgb <0.0,0.1,0.8>]
    }
  }
}

light_source
{
  0, 1
  rotate y*30
}

// ----------------------------------------

#declare mirror =
  texture
  {
    finish { ambient 0 diffuse 0 reflection 1 }//.8
  }


// ----------------------------------------

/*
plane
{
  y, -100
  pigment { color rgb <0.7,0.5,0.3> }
}
*/

difference
{
  sphere { 0, 1   pigment { rgb x } }
  sphere { 0, 0.99   texture { mirror } }
  
  plane { y, 0.98  inverse  pigment { rgb x } }
  
  scale <1, 3, 3>
  
  //pigment { rgb x }
  
}

sphere
{
  //<0, -0.8,0>, .19
  <rand(S), rand(S), rand(S)>, rand(S)/10+0.1
  //texture { mirror }
  pigment { rgb y/2+z }
  finish { specular 1 reflection 0.4 }
}

sphere
{
  <0, 2, 0>, 1
  pigment { rgb x/2+z/3 }
  finish { specular 1 reflection 0.4 }
  //texture { mirror }
  
}

//plane { y, 0 rotate <rand(S), rand(S), rand(S)>*90 texture { mirror } }

sphere {
   <camx, camy, camz>*2-1, 0.001 hollow
   pigment {color rgb .5 transmit 1.5 }
   finish {ambient 1 diffuse 0}
}

