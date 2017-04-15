open System

let level1 = System.IO.File.ReadAllLines "Level1.txt"
let level2 = System.IO.File.ReadAllLines "Level2.txt"

[<EntryPoint>]
let main argv =
    printfn "Welcome to Sight Words, built in 2017."
    printf "Please enter your name: "
    let name = Console.ReadLine ()
    printfn "Hello %s from Sight Words!" name
    let random = Random ()
    let rec loop (words:string array) = 
        printfn "Press enter to get a sight word."
        Console.ReadLine () |> ignore
        words.[random.Next(words.Length)]
        |> printfn "%s"
        Console.WriteLine ()
        loop words
    let rec selectLevel () =
        printfn "Which level do you want, 1 or 2?"
        let selection = Console.ReadLine ()
        match selection with
        | "1" -> loop level1
        | "2" -> loop level2
        | _ -> printfn "I don't know that level."; selectLevel ()
    selectLevel ()
    0
