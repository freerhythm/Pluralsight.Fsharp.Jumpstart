#if INTERACTIVE
#else
namespace ObjectOrientedTypes
#endif


type PersonRecord =
    {
        Name : string
        Surname: string
    }

//Imutable object - equivalent to record above
type PersonObject(name : string, surname : string) =
    member this.Name = name
    member this.Surname = surname

//let p1 = { Name = "Max"; Surname = "Kritzinger" }
//let p2 = PersonObject("Max", "Kritzinger")

//Mutable object with auto getters and setters
type MutablePerson2(name : string, surname : string) = 
    member val Name = name with get, set
    member val Surname = surname with get, set

//Mutable object (members with backing variables) for custom get set logic
type MutablePerson(name: string, surname: string) =
    
    let validateName n =
        if System.String.IsNullOrWhiteSpace n then
            raise (System.ArgumentException())
    
    let mutable _name = name
    let mutable _surname = surname

    do //executes in constructor 
        validateName name
        validateName surname

    member this.Name
        with get() = _name
        and set value = 
            validateName value
            _name <- value

    member this.Surname
        with get() = _surname
        and set value = 
            validateName value
            _surname <- value


//Mutable object with custom constructor logic
type MutablePerson3(name : string, surname : string) = 
    
    let validateName n =
        if System.String.IsNullOrWhiteSpace n then
            raise (System.ArgumentException())
    
    do 
        validateName name
        validateName surname

    member val Name = name with get, set
    member val Surname = surname with get, set


//Interfaces
type IPerson =
    abstract member Name : string
    abstract member Surname : string
    abstract member Fullname : string

type PersonFromInterface(name : string, surname : string) =
    
    let validateName n =
        if System.String.IsNullOrWhiteSpace n then
            raise (System.ArgumentException())
    
    do 
        validateName name
        validateName surname

    interface IPerson with
        member this.Name = name
        member this.Surname = surname
        member this.Fullname = sprintf "%s %s" name surname


//FSI
// let me = PersonFromInterface("Max", "Kritzinger");;
// me.Name -> Error
// let me = (me :> IPerson)
// me.Name -> Successful

//Discriminated Union type
type Contact =
    | PhoneNumber of AreaCode:string * Number:string
    | EmailAddress of string


type ContactPerson(name: string, surname: string, preferredContact : Contact) =
    let validateName n =
        if System.String.IsNullOrWhiteSpace n then
            raise (System.ArgumentException())
    
    do 
        validateName name
        validateName surname

    member this.PreferredContact = preferredContact

    interface IPerson with
        member this.Name = name
        member this.Surname = surname
        member this.Fullname = sprintf "%s %s" name surname