# CineWaifu
Application converting videos into ANSI standard colored ASCII art frames.

## Usage
`.\CineWaifu.exe --help`  
Commands:
  download      Downloads and preprocesses video for ansi frame generation.
  preprocess    Preprocesses video for ansi frame generation.
  generate      Generate ANSI file from video.
  run           Runs ANSI file.
  serve         Serve ANSI file or directory over tcp.

Sample commands usage:

Generating ansi file:  
`.\CineWaifu.exe run -i .\Resources\Samples\Videos\badapple.mp4 -o badapple`

Running an ansi file:  
`.\CineWaifu.exe run -i .\Resources\Samples\Ansi\badapple.ansi`

## Examples

![alt text](https://github.com/Kur3k/CineWaifu/blob/master/Examples/sample4.png?raw=true)
![alt text](https://github.com/Kur3k/CineWaifu/blob/master/Examples/sample5.png?raw=true)
![alt text](https://github.com/Kur3k/CineWaifu/blob/master/Examples/sample3.png?raw=true)
![alt text](https://github.com/Kur3k/CineWaifu/blob/master/Examples/sample1.png?raw=true)
![alt text](https://github.com/Kur3k/CineWaifu/blob/master/Examples/sample2.png?raw=true)

In future serving data via TCP.
