// Mit F# Interactive im Windows Explorer oder über fsi.exe ausführen. (Bei Ausführung im F#I Fenster in VS
// wird die .fs Datei nicht gefunden.)
// Dazu VS Cmd Prompt starten - dann ist fsi.exe im Pfad - und fsi.exe script_das_lädt.fsx aufrufen.
// Falls fsi.exe im interaktiven Modus läuft, mit #quit;; verlassen.

#load "Begrüßung.fs"

open System

Begrüßung.Hallo_sagen()

