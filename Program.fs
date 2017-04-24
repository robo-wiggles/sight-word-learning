open System

let level1 = System.IO.File.ReadAllLines "Level1.txt"
let level2 = System.IO.File.ReadAllLines "Level2.txt"
let level3 = System.IO.File.ReadAllLines "Level3.txt"
let level4 = System.IO.File.ReadAllLines "Level4.txt"
let level5 = System.IO.File.ReadAllLines "Level5.txt"

[<EntryPoint>]
let main argv =
    printfn "Welcome to Sight Words, built in 2017."
    printf "Please enter your name: "
    let name = Console.ReadLine ()
    printfn "Hello %s from Sight Words!" name
    let random = Random ()
    let rec loop (words:string array) = 
        let randomWord = words.[random.Next(words.Length)]
        printfn "%s" randomWord
        Console.ReadLine ()
        |> function
        | "q" | "Q" -> printfn "Quitting this level."
        | "h" | "H" -> 
            let p = System.Diagnostics.Process.Start ("say", randomWord)
            p.WaitForExit () |> ignore
            loop words
        | _ ->
            loop words
    let rec selectLevel () =
        printfn "Which level do you want, 1, 2, 3, 4, or 5?"
        let selection = Console.ReadLine ()
        match selection with
        | "1" ->
            printfn "Press enter to get a sight word."
            loop level1
            selectLevel ()
        | "2" ->
            printfn "Press enter to get a sight word."
            loop level2
            selectLevel ()
        | "3" ->
            printfn "Press enter to get a sight word."
            loop level3
            selectLevel ()
        | "4" ->
            printfn "Press enter to get a sight word."
            loop level4
            selectLevel ()
        | "5" ->
            printfn "Press enter to get a sight word."
            loop level5
            selectLevel ()
        | "q" | "Q" -> printfn "Quitting application.  We can learn more later."
        | _ -> 
            printfn "I don't know that level."
            selectLevel ()
    selectLevel ()
    0
