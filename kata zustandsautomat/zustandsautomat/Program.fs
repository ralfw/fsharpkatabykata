let prüfen r = 
  match reelle_zahlen.prüfen r with
  | reelle_zahlen.Erkannt -> printfn "%s erkannt" r
  | reelle_zahlen.Nicht_erkannt m -> printfn "%s nicht erkannt: %s" r m

prüfen "123"
prüfen "123,45"
prüfen "-123,45"
prüfen "--123"
prüfen "1,2,3"
prüfen "12,"
