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
  * Under the hood, all property setters and event handler registrators use "TODO" under the hood. This means that these actions are only carried out when the component (and therefor the underlying DOM element) is created.
* Anders als bei anderen UI-Frameworks: State kann "überall" sein
* Templates + Slots
  * See "Components" and invent a meaningful example for that.
* In-Depth: Wie funktioniert Vide?
* if-else
        "if-else cannot work like that"
        ////// TODO: That should not be used at all? And: That this seems to work
        ////// is only an edge case, because state has same type
        ////if count.Value = 5 then
        ////    div.class'("the-message") {
        ////        $"You have the right to defend yourself!"
        ////    }
        ////else
        ////    p { $"not yet..." }
* Extending NodeBuilder with extensions:
    [<Extension>]
    type BuilderExtensions =

        /// Sets an arbitrary attribute's value on every eval cycle.
        [<Extension>]
        static member attr<'nb,'e,'n
                when 'nb :> NodeBuilder<'e,'n,FableContext>
                and 'e :> HTMLElement
                and 'n :> Node>
            (
                this: 'nb,
                key: string,
                value: string
            ) =
            this.OnEval(fun x -> x.node.setAttribute(key, value))
* Advanced: Explain the "app"
  * manually evaluate
  * have a look at the "state"
  * ref: "The view will automatically re-evaluate itself synchronousely."
* value restriction issues
* Binding state to input:
      input
          .type'("checkbox")
          .checked'(item.isDone)
          .oninput(fun x -> item.isDone <- x.node.``checked``)
      input.bind(item.isDone)
