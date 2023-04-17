* Intro
    Allgemein: Die Idee von Vide
    Idee aus DSP
    Similar experience for many tasks, domains and platforms
    Writing WebApps: Fable
    Writing Desktop/Mobile: MAUI
    Writing Desktop/Mobile: Avalonia
    DSP: LocSta
* Technical Stuff
    Vidde.Common

Vide Fable
---

* Intro
  * Fable
  * Beta phase
* Komponenten
    * mit / ohne Children
    * Als HTML-Element (Builder) oder Funktion
* CSS
  * Fable scheint Probleme zu haben, wenn man CSS-Modules importiert.


IDEEN
---

* Doesn't use or need TypeScript, because it uses F#
* Where can I get Support
* Fable / Femto
* Router
* You are always "in the language"
* Try Vide online

* Operators (+=, :=,. etc)
* Docu: Das geht so nicht - Trigger erklären!
        let! currentItems = Mutable.ofValue (ResizeArray())
        let addItem item = currentItems.value.Add(item)
        let removeItem item = currentItems.value.Remove(item) |> ignore
* Access HTMLElement from builder wirh let! or via map/iter




Main Screen
---
Mehr in den Vordergrund stellen, was(!) man tun kann, z.B.
  -> Write Web-Apps
    Write WebApps with Fable
  -> Desktop and Mobile
    ...
  -> DSP (Digital Signal Processing)
    ...
  -> Codebeispiel mit if/for

Misc
---
* CSS imports (rel zum File)
    importSideEffects("./Demo.scss")
* Links (abs.)
    p { img.src("./src/components/logo.png").width("150px") }
* app.OnEval
* Referenz auf Fable mit
  * Was ist F# - damit sollte man sich etwas auskennen
  * Gilt auch für Fable

* importSideEffects("./Demo.scss")
* Optimizations / Lifecycle
* Anders als bei anderen UI-Frameworks: State kann "überall" sein
*
