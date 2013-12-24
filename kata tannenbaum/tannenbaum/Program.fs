let tannenbaum baumhöhe =
  let einrücken n = String.replicate n " "
  let stamm baumhöhe = 
    einrücken (baumhöhe-1)
    + "I"

  let rec geäst baumhöhe astnummer =
    let ast baumhöhe astnummer = 
      einrücken (baumhöhe - astnummer)
      + String.replicate (2 * astnummer - 1) "X"
      + "\n"
      
    if astnummer = 1 then
      ast baumhöhe astnummer
    else
      geäst baumhöhe (astnummer-1) 
      + ast baumhöhe astnummer
      
  geäst baumhöhe baumhöhe
  + stamm baumhöhe

printfn "%s" (tannenbaum 5)