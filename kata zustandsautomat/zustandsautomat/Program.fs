let prüfen r = 
  match fließkommazahlen.prüfen r with
  | fließkommazahlen.Erkannt -> printfn "%s erkannt" r
  | fließkommazahlen.Nicht_erkannt m -> printfn "%s nicht erkannt: %s" r m

prüfen "123"
prüfen "123,45"
prüfen "-123,45"
prüfen "--123"
prüfen "1,2,3"
prüfen "12,"

printfn "Römische Zahl 'MMXIII' erkannt als %d" (römische_zahlen.fromRoman "MMXIII")
try
  römische_zahlen.fromRoman "XM" |> ignore
with
  ex -> printfn "Ausnahme bei 'XM': %A" ex.Message
