module Iterative_Lösung

let toRoman i =
  let übersetzungen = 
    [(50, "L"); (40, "XL"); 
     (10, "X"); (9, "IX"); 
     (5, "V"); (4, "IV"); 
     (1, "I")]

  let finde_größte_zahl i =
    übersetzungen |> List.find (fun (a, s) -> a <= i)

  let mutable rest = i
  let mutable resultat = ""
  while rest > 0 do
    let (a, s) = finde_größte_zahl rest
    resultat <- resultat+s
    rest <- rest-a
    
  resultat

