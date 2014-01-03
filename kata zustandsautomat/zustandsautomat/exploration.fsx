type Symbol = M | D | C | L | X | V | I | CM | CD | XC | XL | IX | IV

let zustandsgraph = Map [
        (M, Set [M; CM; D; CD; C]);
        (CD, Set [CM; D; CD; C]);
        (D, Set [CD; C]);
        (C, Set [C])
    ]
    
exception Syntaxfehler of Symbol * Symbol

let ist_gültiges_folgesymbol aktuellerZustand symbol =
    zustandsgraph |> Map.find aktuellerZustand
                  |> Set.contains symbol

let zustand_wechseln aktuellerZustand symbol =        
    if ist_gültiges_folgesymbol aktuellerZustand symbol then symbol
    else raise (Syntaxfehler (aktuellerZustand, symbol))

zustand_wechseln M X