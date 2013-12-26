module Rekursive_Lösung

let toRoman i =
  let übersetzungen = 
    [(50, "L"); (40, "XL"); 
     (10, "X"); (9, "IX"); 
     (5, "V"); (4, "IV"); 
     (1, "I")]

  let finde_größte_zahl i =
    übersetzungen |> List.find (fun (a, s) -> a <= i)

  let rec rest_übersetzen rest resultat =
    if rest > 0 then
      let a, r = finde_größte_zahl rest
      rest_übersetzen (rest-a) (resultat+r)
    else
      resultat
    
  rest_übersetzen i "" 