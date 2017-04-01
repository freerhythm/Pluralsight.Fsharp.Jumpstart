#if INTERACTIVE
#else
module Module4
#endif

type Person = 
    {
        FirstName : string
        Surname : string
    }

type Pupil =
    {
        FirstName : string
        Surname : string
    }

let person = { FirstName = "Max";  Surname = "Kritzinger" } : Person
let pupil = { FirstName = person.FirstName; Surname = person.Surname } : Pupil

//Create a new pupil from an existing pupil
let pupil2 = {pupil with FirstName = "Ron"}

//F# uses structural equality to compare records (compares the content of the two records)
let personA = { FirstName = "Joe"; Surname = "Bloggs"} : Person
let personB = { FirstName = "Joe"; Surname = "Bloggs"} : Person
//personA = personB;;
//val it : bool = true


type Company =
    {
        Name : string
        TaxNumber : int option   
    }

//Pattern matching for an optional type
let PrintCompany (company: Company) =
    let taxNumberStr =
        match company.TaxNumber with
        | Some n -> sprintf " [%i]" n
        | None -> ""

    printfn "%s%s" company.Name taxNumberStr

type Shape = 
    | Square of float
    | Rectangle of float * float
    | Circle of float

let s = Square 3.4
let r = Rectangle(2.2, 1.9)
let c = Circle(1.0)

let drawing = [|s; r; c|]

//Pattern matching on type cases
let Area(shape : Shape) =
    match shape with
    | Square x -> x * x
    | Rectangle(h, w) -> h * w
    | Circle r -> System.Math.PI * r * r

let total1 = drawing |> Array.sumBy(fun s -> Area s)
let total2 = drawing |> Array.sumBy Area


//Pattern matching on arrays
let one = [|50|]
let two = [|60; 61|]
let many = [|0..99|]

let Describe arr =
    match arr with
    | [|x|] -> sprintf "One element: %i" x
    | [|x; y|] -> sprintf "Two elements: %i, %i" x y
    | _ -> sprintf "A longer array"