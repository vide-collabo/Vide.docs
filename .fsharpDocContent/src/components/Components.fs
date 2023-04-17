module Components

open Vide
open type Html

module A =
    let view =
        vide {
            // cat counter
            div {
                let! count = Vide.ofMutable 0

                button
                    .onclick(fun _ -> count.Value <- count.Value + 1) {
                    "Count cats!"
                }
                $"cats: {count.Value}"
            }

            // dog counter
            div {
                let! count = Vide.ofMutable 0

                button
                    .onclick(fun _ -> count.Value <- count.Value + 1) {
                    "Count dogs!"
                }
                $"dogs: {count.Value}"
            }
        }

module B =
    let counter (elementName: string) = vide {
        div {
            let! count = Vide.ofMutable 0

            button
                .onclick(fun _ -> count.Value <- count.Value + 1) {
                $"Count {elementName}!"
            }
            $"{elementName}: {count.Value}"
        }
    }

    let view =
        vide {
            counter "cats"
            counter "dogs"
        }
