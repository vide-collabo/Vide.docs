module Conditions

open Vide
open type Html

module A =
    let view =
        vide {
            let! count = Vide.ofMutable 0
            button.onclick(fun _ -> count.Value <- count.Value + 1) {
                $"Count = {count.Value}"
            }

            p.hidden(count.Value % 5 <> 0) {
                "...will you go on?"
            }
        }

module B =
    let view =
        vide {
            let! count = Vide.ofMutable 0
            button.onclick(fun _ -> count.Value <- count.Value + 1) {
                $"Count = {count.Value}"
            }

            if count.Value % 5 = 0 then
                p {
                    "...will you go on?"
                }
            else
                Vide.elseForget
        }

module C =
    let view =
        vide {
            let! count = Vide.ofMutable 0
            button.onclick(fun _ -> count.Value <- count.Value + 1) {
                $"Count = {count.Value}"
            }

            if count.Value % 5 = 0 then
                p {
                    "...will you go on?"

                    let! isWillingToGoOn = Vide.ofMutable false
                    input
                        .type'("checkbox")
                        .checked'(isWillingToGoOn.Value)
                        .oninput(fun x -> isWillingToGoOn.Value <- x.node.``checked``)
                }
            else
                Vide.elseForget
        }

module D =
    let view =
        vide {
            let! count = Vide.ofMutable 0
            button.onclick(fun _ -> count.Value <- count.Value + 1) {
                $"Count = {count.Value}"
            }

            if count.Value % 5 = 0 then
                p {
                    "...will you go on?"

                    let! isWillingToGoOn = Vide.ofMutable false
                    input
                        .type'("checkbox")
                        .checked'(isWillingToGoOn.Value)
                        .oninput(fun x -> isWillingToGoOn.Value <- x.node.``checked``)
                }
            else
                Vide.elsePreserve
        }
