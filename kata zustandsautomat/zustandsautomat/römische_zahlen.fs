module römische_zahlen

let private scannen römischeZahl =
  let in_Buchstaben_zerlegen (römischeZahl:string) =
    römischeZahl.ToCharArray() |> List.ofArray
  römischeZahl |> in_Buchstaben_zerlegen
  

let private parsen tokens =
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

  let prüfen asl =
    let zustandsgraph = Map [
                                ("$", Set ["M"; "CM"; "D"; "CD"; "C"; "XC"; "L"; "XL"; "X"; "IX"; "V"; "IV"; "I"]);
                                ("M", Set ["M"; "CM"; "D"; "CD"; "C"; "XC"; "L"; "XL"; "X"; "IX"; "V"; "IV"; "I"]);
                                ("CM", Set ["D"; "CD"; "C"; "XC"; "L"; "XL"; "X"; "IX"; "V"; "IV"; "I"]);
                                ("D", Set ["CD"; "C"; "XC"; "L"; "XL"; "X"; "IX"; "V"; "IV"; "I"]);
                                ("CD", Set ["C"; "XC"; "L"; "XL"; "X"; "IX"; "V"; "IV"; "I"]);
                                ("C", Set ["C"; "XC"; "L"; "XL"; "X"; "IX"; "V"; "IV"; "I"]);
                                ("XC", Set ["L"; "XL"; "X"; "IX"; "V"; "IV"; "I"]);
                                ("L", Set ["XL"; "X"; "IX"; "V"; "IV"; "I"]);
                                ("XL", Set ["X"; "IX"; "V"; "IV"; "I"]);
                                ("X", Set ["X"; "IX"; "V"; "IV"; "I"]);
                                ("IX", Set ["V"; "IV"; "I"]);
                                ("V", Set ["IV"; "I"]);
                                ("IV", Set ["I"]);
                                ("I", Set ["I"]);
                            ]

    let rec prüfen' neueAsl zustand asl =
      let zustand_wechseln bisherigerZustand symbol =
        let ist_gültiges_folgesymbol symbol =
          zustandsgraph |> Map.find bisherigerZustand |> Set.contains symbol
        
        if ist_gültiges_folgesymbol symbol then symbol
        else failwith (sprintf "Ungültiges Symbol %s nach %s" symbol bisherigerZustand)

      match asl with
      | symbol :: rest ->
        let neuerZustand = zustand_wechseln zustand symbol
        prüfen' (neueAsl @ [symbol]) neuerZustand rest
      | [] -> 
        neueAsl

    prüfen' [] "$" asl

  tokens |> zusammenfassen [] |> prüfen


let private übersetzen asl =
  let r2a = Map.ofList [("M", 1000); ("D", 500); ("C", 100); ("L", 50); ("X", 10); ("V", 5); ("I", 1);
                        ("CM", 900); ("CD", 400); ("XC", 90); ("XL", 40); ("IX", 9); ("IV", 4)]
  let symbol_in_zahl_übersetzen symbol =
    r2a |> Map.find symbol
    
  asl |> List.map symbol_in_zahl_übersetzen
      |> List.sum
  
  
let fromRoman römischeZahl =
  römischeZahl |> scannen |> parsen |> übersetzen
