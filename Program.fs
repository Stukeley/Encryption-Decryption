// Project: Encryption-Decryption
// https://hyperskill.org/projects/46
// Originally to be made in Java, but implemented with F#
// Privacy is an important matter is the realm of the Internet. When sending a message, you want to be sure that no-one but the addressee with the key can read it. The entirety of the modern Web is encrypted - take https for example! Don’t stay behind: hop on the encryption/decryption train and learn the essential basics while implementing this simple project.

open System

[<EntryPoint>]
let main argv =
    // Stage 1
    printfn "1."
    printfn "%s" "we found a treasure!"
    let encrypted = Functions.ReverseCharactersEncryption
    printfn "%s" encrypted
    printfn ""

    // Stage 2 & 3
    printfn "2. & 3."
    printfn "Type in a sentence, then the key to encrypt it (a positive integer); then enc if you want to encrypt, or dec if you want to decrypt"

    printf "Sentence: "
    let inputSentence = Console.ReadLine()

    printf "Key: "
    let mutable key = Convert.ToInt32(Console.ReadLine())

    if key < 0 then
        printfn "Not a valid key!"
        key <- 1

    printf "enc/dec: "
    let algorithmType = Console.ReadLine()

    if algorithmType.ToLower() = "enc" then
        let result = Functions.CaesarEncryption (inputSentence, key)
        printfn "%s" result
    else if algorithmType.ToLower() = "dec" then
        let result = Functions.CaesarDecryption (inputSentence, key)
        printfn "%s" result
        

    printfn ""

    // Stage 5
    printfn "5."
    printfn "Encrypting files. Please type in the input file's name, then the output file's name"

    printf "Input: "
    let inputFileName = Console.ReadLine()

    printf "Output: "
    let outputFileName = Console.ReadLine()

    printf "Key: "
    key <- Convert.ToInt32(Console.ReadLine())

    if key < 0 then
        printfn "Not a valid key!"
        key <- 1

    Functions.FileEncryption (inputFileName, outputFileName, key)

    0
