module mit_Symbolen

type Symbol = M | D | C | L | X | V | I | CM | CD | XC | XL | IX | IV
  

let scannen (römischeZahl:string) =
  [for c in römischeZahl.ToCharArray() do
    if   c='M' then yield M
    elif c='D' then yield D
    elif c='C' then yield C
    elif c='L' then yield L
    elif c='X' then yield X
    elif c='V' then yield V    
    elif c='I' then yield I
  ]


let parsen tokens =
  let rec zusammenfassen asl tokens =
    match tokens with
    | C :: M :: rest ->
      zusammenfassen (asl @ [CM]) rest
    | C :: D :: rest ->
      zusammenfassen (asl @ [CD]) rest
    | X :: C :: rest ->
      zusammenfassen (asl @ [XC]) rest
    | X :: L :: rest ->
      zusammenfassen (asl @ [XL]) rest
    | I :: X :: rest ->
      zusammenfassen (asl @ [IX]) rest
    | I :: V :: rest ->
      zusammenfassen (asl @ [IV]) rest
    | s :: rest ->
      zusammenfassen (asl @ [s]) rest
    | [] -> asl

  tokens |> zusammenfassen []


let übersetzen asl =
  let r2a = Map.ofList [(M, 1000); (D, 500); (C, 100); (L, 50); (X, 10); (V, 5); (I, 1);
                        (CM, 900); (CD, 400); (XC, 90); (XL, 40); (IX, 9); (IV, 4)]
  let symbol_in_zahl_übersetzen symbol =
    r2a |> Map.find symbol

  asl |> List.map symbol_in_zahl_übersetzen
      |> List.sum
        

let fromRoman römischeZahl =
  römischeZahl |> scannen |> parsen |> übersetzen

printfn "%A" (fromRoman "XLII")
