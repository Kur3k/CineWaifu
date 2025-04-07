# CineWaifu
Application converting videos into ANSI standard colored ASCII art frames.

## Usage
`.\CineWaifu.exe --help` 

### Sample commands usage:  

#### Download video file from external soruce and preprocess:  
`.\CineWaifu.exe download --url https://www.youtube.com/watch?v=5R9ZaIGgNnc -o slayers --fps 24 --width 100 --height 30`

#### Preprocessing video file:  
`.\CineWaifu.exe preprocess -i .\Resources\Samples\Videos\badapple.mp4 -o badapple --fps 24 --width 100 --height 30`

#### Generating ansi file:  
`.\CineWaifu.exe generate -i .\Resources\Samples\Videos\badapple.mp4 -o badapple`

#### Running an ansi file:  
`.\CineWaifu.exe run -i .\Resources\Samples\Ansi\badapple.ansi`

#### Serving single ansi video via tcp:  
`.\CineWaifu.exe serve -i .\Resources\Samples\Ansi\badapple.ansi -p 5050`

#### Serving whole directory ansi videos via tcp:  
`.\CineWaifu.exe serve -i .\Resources\Samples\Ansi -p 5050`  
Random video plays for connected user.


## Examples

![alt text](https://github.com/Kur3k/CineWaifu/blob/master/Examples/sample4.png?raw=true)
![alt text](https://github.com/Kur3k/CineWaifu/blob/master/Examples/sample5.png?raw=true)
![alt text](https://github.com/Kur3k/CineWaifu/blob/master/Examples/sample3.png?raw=true)
![alt text](https://github.com/Kur3k/CineWaifu/blob/master/Examples/sample1.png?raw=true)
![alt text](https://github.com/Kur3k/CineWaifu/blob/master/Examples/sample2.png?raw=true)

In future serving data via TCP.
