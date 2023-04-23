module StateAndReactivity

open Vide
open type Html

let view =
    vide {
        let! count = Vide.ofMutable 0

        p {
            button.onclick(fun _ -> count.Value <- count.Value + 1) {
                "Click me!"
            }
        }
        $"You clicked the button {count.Value} times."
    }
