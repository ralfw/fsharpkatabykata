open System

let toDictionary konfig =
  let in_zuweisungen_zerlegen (konfig:string) =
    konfig.Split ([|';'|], StringSplitOptions.RemoveEmptyEntries)
  
  let in_name_wert_paare_zerlegen (zuweisungen:string array) =
    let zerlegen (zuweisung:string) = 
      let name_wert = zuweisung.Split '='
      (name_wert.[0], name_wert.[1])
    zuweisungen |> Array.map zerlegen

  konfig |> in_zuweisungen_zerlegen 
         |> in_name_wert_paare_zerlegen 
         |> Map.ofArray
  
printfn "%A" (toDictionary "a=1;bc=2;;a=42")