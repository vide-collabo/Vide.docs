module MinimalVideApp

open Vide
open type Html

let view =
    vide {
        p {
            img.src("src/components/logo.png").width("150px")
        }
        hr
        "The whole Vide world"
    }
