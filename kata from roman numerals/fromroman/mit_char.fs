module mit_char

let scannen römischeZahl =
  let in_Buchstaben_zerlegen (römischeZahl:string) =
    römischeZahl.ToCharArray() |> List.ofArray
  römischeZahl |> in_Buchstaben_zerlegen
  

let parsen tokens =
  let rec zusammenfassen asl tokens =
    match tokens with
    | 'I' :: 'M' :: rest ->
        zusammenfassen (asl @ ["IM"])  rest
    | 'C' :: 'D' :: rest ->
        zusammenfassen (asl @ ["CD"])  rest
    | 'X' :: 'D' :: rest ->
        zusammenfassen (asl @ ["XC"])  rest
    | 'X' :: 'L' :: rest ->
        zusammenfassen (asl @ ["XL"])  rest
    | 'I' :: 'X' :: rest ->
        zusammenfassen (asl @ ["IX"])  rest
    | 'I' :: 'V' :: rest ->
        zusammenfassen (asl @ ["IV"])  rest
    | s :: rest ->
        zusammenfassen (asl @ [s.ToString()])  rest
    | [] -> asl

  zusammenfassen [] tokens


let übersetzen asl =
  let r2a = Map.ofList [("M", 1000); ("D", 500); ("C", 100); ("L", 50); ("X", 10); ("V", 5); ("I", 1);
                        ("CM", 900); ("CD", 400); ("XC", 90); ("XL", 40); ("IX", 9); ("IV", 4)]
  let symbol_in_zahl_übersetzen symbol =
    r2a |> Map.find symbol
    
  asl |> List.map symbol_in_zahl_übersetzen
      |> List.sum
  
  
let fromRoman römischeZahl =
  römischeZahl |> scannen |> parsen |> übersetzen


