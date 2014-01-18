module ToDictionary

open System

let convert konfig =
  let in_zuweisungen_zerlegen (konfig:string) =
    konfig.Split ([|';'|], 
                  StringSplitOptions.RemoveEmptyEntries)
  
  let in_name_wert_paare_zerlegen (zuweisungen:string array) =
    let zerlegen (z:string) = z.Split '='
    let in_tupel_wandeln (a:string array) = (a.[0], a.[1])
    zuweisungen |> Array.map zerlegen
                |> Array.map in_tupel_wandeln

  konfig |> in_zuweisungen_zerlegen 
         |> in_name_wert_paare_zerlegen 
         |> Map.ofArray
