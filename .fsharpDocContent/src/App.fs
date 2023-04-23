module App

open Fable.Core.JsInterop
open Browser
open Vide

importSideEffects("./App.scss")

VideApp.Fable.createAndStart
    (document.getElementById("app"))
    Conditions.D.view
|> ignore
