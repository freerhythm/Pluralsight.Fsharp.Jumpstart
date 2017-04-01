#if INTERACTIVE
#else 
module Jumpstart
#endif

let x = 42
let hi = "Hello"



let Square x = x * x

let Area (length : float) (height : int) = 
    length * System.Convert.ToDouble(height)

let Greeting name =
    if System.String.IsNullOrWhiteSpace(name) then
        "whoever you are"
    else
        name

let SayHiTo me = 
    printfn "Hi, %s" (Greeting me)

let PrintNumbers min max =
    let square n = 
        n * n
    for x in min..max do
    printfn "%i squared is %i" x (square x)

let RandomPosition() =
    let r = new System.Random()
    r.NextDouble(), r.NextDouble()

open System.IO
let files = Directory.EnumerateFiles(@"c:\windows", "*.exe")