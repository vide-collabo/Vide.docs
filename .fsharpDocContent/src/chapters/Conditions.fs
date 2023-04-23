module Conditions

open Vide
open type Html

module A =
    let counter (elementName: string) = vide {
        div {
            let! count = Vide.ofMutable 0

            button.onclick(fun _ -> count.Value <- count.Value + 1) {
                $"Counting {elementName}: ({count.Value})"
            }

            span.hidden(count.Value % 5 <> 0) {
                "...keep counting !"
            }
        }
    }

    let view =
        vide {
            counter "cats"
            counter "dogs"
        }

module B =
    let counter (elementName: string) = vide {
        div {
            let! count = Vide.ofMutable 0

            button.onclick(fun _ -> count.Value <- count.Value + 1) {
                $"Counting {elementName}: ({count.Value})"
            }

            if count.Value % 5 = 0 then
                span { "...keep counting !" }
            else
                Vide.elseForget
        }
    }

    let view =
        vide {
            counter "cats"
            counter "dogs"
        }
