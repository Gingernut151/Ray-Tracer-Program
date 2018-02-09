IF EXIST %cd%\Video\sphere.mp4 DEL /F %cd%\Video\sphere.mp4
%cd%\Video\ffmpeg.exe -r 60 -f image2 -s 1920x1080 -i %cd%\Pics\spheres%%04d.ppm -vcodec libx264 -crf 25  -pix_fmt yuv420p %cd%\Video\sphere.mp4
%cd%\Video\sphere.mp4