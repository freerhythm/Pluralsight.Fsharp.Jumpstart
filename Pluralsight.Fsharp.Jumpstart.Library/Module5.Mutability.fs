#if INTERACTIVE
#else
module Module5
#endif

let ImmutabilityDemo () = 
    let x = 42
    printfn "x: %i" x
    if 1 = 1 then
        // creates a shadow
        let x = x + 1
        printfn "x: %i" x
    // original value is revealed when x+1 goes out of scope
    printfn "x: %i" x


let MutabilityDemo() =
    let mutable x = 42
    printfn "x: %i" x
    x <- x + 1
    printfn "x: %i" x