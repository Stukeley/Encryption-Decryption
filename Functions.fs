module Functions

open System.IO

// For the first stage, you need to manually encrypt the message "we found a treasure!" and print only the ciphertext (in lower case).
// To encrypt the message, replace each letter with the letter that is in the corresponding position from the end of the English alphabet (a→z, b→y, c→x, ... x→c, y →b, z→a). Do not replace spaces or the exclamation mark.
// a->z (+25)
// z->a (-25)
// b->y (+23)
// We can add simply the difference between the two letters (it might be negative)
// if (currentChar >= 97 && currentChar <=122) then
// replacedChar = 219 - currentChar

let charToAscii (character : char) = int character

let minMaxAscii = (int)('a' + 'z')  // 219

let ReverseCharactersEncryption = 

    let message = "we found a treasure!"
    let mutable currentChar:char = 'a'
    let mutable replacedChar:char = 'z'
    let mutable encrypted:string = ""

    for i in 0 .. message.Length - 1 do
        currentChar <- message.[i]

        if currentChar >= 'a' && currentChar <= 'z' then
            replacedChar <- char(minMaxAscii - charToAscii currentChar)
            encrypted <- encrypted + replacedChar.ToString()
        else
            encrypted <- encrypted + currentChar.ToString()

    encrypted

let CaesarEncryption (input:string, key:int32) = 

    let mutable currentChar:char = 'a'
    let mutable replacedChar:char = 'z'
    let mutable encrypted:string = ""

    for i in 0 .. input.Length - 1 do
        currentChar <- input.[i]

        if currentChar >= 'a' && currentChar <= 'z' then
            let mutable charValue:int = charToAscii currentChar + key

            while charValue > 122 do
                charValue <- charValue - 26

            replacedChar <- char(charValue)
            encrypted <- encrypted + replacedChar.ToString()
        else
            encrypted <- encrypted + currentChar.ToString()

    encrypted

let CaesarDecryption (input:string, key:int32) = 
    let mutable currentChar:char = 'a'
    let mutable replacedChar:char = 'z'
    let mutable encrypted:string = ""

    for i in 0 .. input.Length - 1 do
        currentChar <- input.[i]

        if currentChar >= 'a' && currentChar <= 'z' then
            let mutable charValue:int = charToAscii currentChar - key

            while charValue < 97 do
                charValue <- charValue + 26

            replacedChar <- char(charValue)
            encrypted <- encrypted + replacedChar.ToString()
        else
            encrypted <- encrypted + currentChar.ToString()

    encrypted

let FileEncryption (inputFile:string, outputFile:string, key:int32) = 
    use reader = new StreamReader(inputFile)
    let input = reader.ReadToEnd()
    let encrypted = CaesarEncryption(input, key)

    use writer = new StreamWriter(outputFile)
    writer.Write(encrypted)