module reelle_zahlen

type Geprüft =
| Erkannt
| Nicht_erkannt of string

// ["-"] d d* ["." d d*] 
let d = "0123456789"
let zustandsgraph = Map [
                            (0, [("-", 1); (d, 2)]);
                            (1, [(d, 2)]);
                            (2, [(d, 2); ("†", 99); (",", 3)]);
                            (3, [(d, 4)]);
                            (4, [(d, 4); ("†", 99)]);
                            (99, [])
                        ]

let passender_übergang (zeichen:char) (erlaubteZeichen:string, _)  =
  erlaubteZeichen.IndexOf(zeichen) >= 0
  
let übergang_finden zeichen übergänge =
  übergänge |> List.find (passender_übergang zeichen)

let übergänge_für_zustand_finden zustand =
  zustandsgraph |> Map.find zustand

let zustand_wechseln zeichen zustand =
  let übergänge = übergänge_für_zustand_finden zustand
  let (_, neuerZustand) = übergang_finden zeichen übergänge
  neuerZustand
  
let prüfen (zeichenkette:string) =
  let rec prüfen' zustand zeichenkette =
    try
      match zeichenkette with
      | erstesZeichen :: rest ->
        let neuerZustand = zustand_wechseln erstesZeichen zustand
        prüfen' neuerZustand rest
      | [] ->
        let neuerZustand = zustand_wechseln '†' zustand
        Erkannt
    with
    | _ -> 
      match zeichenkette with
      | [] -> Nicht_erkannt "Unerwartetes Ende der Zahl"
      | _ -> Nicht_erkannt ("Unerwartetes Zeichen bei " + (new string(zeichenkette |> Array.ofList)))
    
  zeichenkette.ToCharArray() |> List.ofArray 
  |> prüfen' 0
