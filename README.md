# CSharp_Application
This application was written for Professor Andrew Davidhazy, Rochester Institute of Technology (RIT). \
Camera: Mightex TCN/TCE-1209-U - High-Speed 2048-Pixel USB2.0 CCD Line Camera with External Trigger\
Languages: C# Unmanaged C++ interOp \
IDE: Visual Studio 2008 \
Features:
1. Application to communicate with SDK (driver) and camera.
2. Image processing - histogram equalization.
3. Stitch images into 1.
4. Conversion of image format.

There are 2 additional applications to process the camera output.
By Default, camera produces ascii file data ressembling an oscilloscope.
1. ascii2Bmp converts the raw output into bitmap files.
2. RawOutputConverter is a more advanced converter that has histogram equalization (look up table).


Photos taken at Lake Bde Maka Ska \
<img height="80" src="https://user-images.githubusercontent.com/1282659/131254678-5074a060-ce41-4f67-8972-d2cfcaa079e3.jpg">
<img height="80" src="https://user-images.githubusercontent.com/1282659/131254682-988c510d-d4a6-4a7d-8519-19f69385bc52.jpg">

Configuration of Camera, destination, exposure and histogram equalization. \
<img height="300" src="https://user-images.githubusercontent.com/1282659/131255060-da802c7e-47ac-4742-b4c9-c2889d960a8b.png">

images (lines) collected during a scan. \
<img height="300" src="https://user-images.githubusercontent.com/1282659/131255063-2e48a34e-f4a9-4cb2-b1ad-ccac9a81014a.png">

Start / Stop photo-lines capture. \
<img height="300" src="https://user-images.githubusercontent.com/1282659/131255069-351e8d5f-2c34-4c9e-aef4-5649875948c2.png">

Viewing screen during photo-lines capture. \
<img height="300" src="https://user-images.githubusercontent.com/1282659/131255084-4f3f184d-909e-43ee-a22a-f3557d881f4b.png">

Folder view of captured photos. \
<img height="300" src="https://user-images.githubusercontent.com/1282659/131255097-636f1a1c-c017-41ea-b69d-989501a2c469.png">
<img height="300" src="https://user-images.githubusercontent.com/1282659/131255104-74f2822e-6be3-4bd2-a660-05d2212a8708.png">

Example stitched photo of my family. \
<img height="400" src="https://user-images.githubusercontent.com/1282659/131255107-3fb3a81c-d811-4d0d-8c7f-48882753ca10.png">
