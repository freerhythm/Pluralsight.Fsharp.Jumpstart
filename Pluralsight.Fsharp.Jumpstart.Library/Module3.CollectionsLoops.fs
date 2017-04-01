#if INTERACTIVE
#else
module Module3
#endif

//List, array or sequence have different syntax and each have their own higher order functions
let array =     [| 1..10 |]     //mutable
let list =      [1..10]         //immutable
let sequence =  {1..10}         //immutable

let fives = [| 5..5..100|]

let base2 = [| for i in 0..10 do yield pown 2 i|]

let fruits = [|"apple"; "pear"; "berry"; "kiwi"; "banana"; "orange"; "lemon"|]

//Initialise a string array that is 'count' long containing names of random fruits
let RandomFruits count =
    let random = System.Random()
    [|
        for i in 1..count do
            let index = random.Next(fruits.Length)
            yield fruits.[index]
    |]

//Group the array and pipe the results to an iterate function that 
//prints the number of each fruit in the basket
let FruitBasket numberOfFruits = 
    Array.groupBy(fun x -> x) (RandomFruits numberOfFruits)
    |> Array.iter(fun group -> 
        let (name, arr) = group
        printfn "%i %s" arr.Length name)

//Initialise array with Array.Init syntax
let RandomFruits2 count =
    let random = System.Random()
    Array.init count (fun _ -> 
        let index = random.Next(fruits.Length)
        fruits.[index]
        )

// try in FSI: LikeSomeFruit (RandomFruits 5);;

let LikeSomeFruit fruits =
    for fruit in fruits do
        printfn "I like %s" fruit


let evenSquares = 
     Array.filter(fun x -> x % 2 = 0) [| for i in 0..99 do yield i * i|] 
    

//Forward pipe the array into different higher order functions
//map is like select in linq
let PrintSquares min max =
    let square n = n * n
    [|min..max|]
    |> Array.map square
    |> Array.iter(printfn "%i")


//Look up all the big files in the windows directory
//Sequence is equiv of IEnumerable
open System.IO
let bigFiles = 
    Directory.EnumerateFiles(@"c:\windows")
    |> Seq.map (fun name -> FileInfo name)
    |> Seq.filter (fun fi -> fi.Length > 100000L)
    |> Seq.map(fun fi -> fi.Name)

   
