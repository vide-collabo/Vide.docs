---
title: "Introduction"
description: "TODO"
weight: 1
toc: true
---

Vide is a principle following an idea:

> Composing state-aware functions as easily as if they were just pure functions!

This idea is so basic that it supports various use cases that somehow deal with "changing values over time". Probably, you came here because you are interested in programming UIs. This can be done with Vide, using one of the implementations described here like:

Vide shares a unified approach for all of these use cases. This means, you can learn the basic principle once and then apply it to all of these use cases. This is what this documentation is about. Once you understand how Vide for Fable wors, you can easily apply the same principle to Vide for Avalonia or Vide for MAUI.

Here's an example of a TODO list app in Vide for Fable:

```fsharp
open System
open Vide
open type Vide.Html

type TodoList = { items: TodoItem list }
and TodoItem = { text: string; mutable isDone: bool; key: int }

let todoListView = vide {
    let! todoList = ofMutable {
        {
            items =
                [
                    {| text = "Write Vide docu"; isDone = false |}
                    {| text = "Cook new ramen broth"; isDone = false |}
                    {| text = "Stuff that's already done"; isDone = true |}
                    {| text = "Auto-gen Vide Avalonia API"; isDone = true |}
                    {| text = "Fix a Trulla C# codegen bug"; isDone = false |}
                    {| text = "Make a Trulla version for node"; isDone = false |}
                    {| text = "Write a LSP for Trulla templates"; isDone = false |}
                ]
                |> List.mapi (fun i x -> { text = x.text; isDone = x.isDone; key = i })
        }
    }

    let setItems items = todoList.Value <- { todoList.Value with items = items }

    h1.class'("title") { "TODO List" }

    div.class'("flex-row") {
        let! itemName = ofMutable {""}

        input.bind(itemName)
        button
            .disabled(String.IsNullOrWhiteSpace(itemName.Value))
            .onclick(fun _ ->
                let nextId =
                    match  todoList.Value.items |> List.map (fun x -> x.key) |> List.sortDescending with
                    | [] -> 0
                    | x::_ -> x + 1
                let newItem = { text = itemName.Value; isDone = false; key = nextId }
                do setItems (newItem :: todoList.Value.items)
                do itemName.Reset()
            )
            {
                "Add Item"
            }
    }

    div {
        for item in todoList.Value.items |> For.selfKeyed do
            div.class'("flex-row todo-item") {
                input.bind(item.isDone, fun value -> item.isDone <- value)
                button
                    .disabled(not item.isDone)
                    .onclick(fun _ -> setItems (todoList.Value.items |> List.except [item]))
                    {
                        "Remove"
                    }
                p { item.text }
            }
    }
}

let host = document.getElementById("app")
let app = VideApp.ForHost(host).CreateAndStartWithUntypedState(todoListView)
```

![Todo List Fable](images/todoList_Fable.png?width=200px)

...and here's the same TODO list for Avalonia:

```fsharp
#r "nuget: Avalonia, 11.0.0"
#r "nuget: Avalonia.Desktop, 11.0.0"
#r "nuget: Avalonia.Themes.Fluent, 11.0.0"

#r "nuget: Vide.UI.Avalonia.Interactive"
#r "nuget: Vide.UI.Avalonia"

Vide.UI.Avalonia.Interactive.guardInit ()
// ^ -------------------------------------------------------------
// |_ This is the boilerplate to make the sample work in fsi.
//    Evaluate this _once and separate_ from the rest of the sample.
// ---------------------------------------------------------------


open System
open Vide
open Vide.UI.Avalonia
open Vide.UI.Avalonia.Interactive.Dynamic
open type Vide.UI.Avalonia.Controls
open type Vide.UI.Avalonia.AvaloniaControlsDefaults

type TodoList = { items: TodoItem list }
and TodoItem = { text: string; mutable isDone: bool; key: int }

let todoListView = vide {
    let! todoList = ofMutable {
        {
            items =
                [
                    {| text = "Write Vide docu"; isDone = false |}
                    {| text = "Cook new ramen broth"; isDone = false |}
                    {| text = "Stuff that's already done"; isDone = true |}
                    {| text = "Auto-gen Vide Avalonia API"; isDone = true |}
                    {| text = "Fix a Trulla C# codegen bug"; isDone = false |}
                    {| text = "Make a Trulla version for node"; isDone = false |}
                    {| text = "Write a LSP for Trulla templates"; isDone = false |}
                ]
                |> List.mapi (fun i x -> { text = x.text; isDone = x.isDone ;key = i })
        }
    }

    let setItems items = todoList.Value <- { todoList.Value with items = items }

    DockPanel.Margin(4) {
        H1
            .HorizontalAlignment(HA.Center)
            .DockPanel().Dock(Dock.Top)
            .Text("My TODO List")
        DockPanel
            .Margin(4)
            .DockPanel().Dock(Dock.Bottom) {

            let! itemName = ofMutable {""}

            Button
                .DockPanel().Dock(Dock.Right)
                .Margin(0)
                .IsEnabled(String.IsNullOrWhiteSpace(itemName.Value) |> not)
                .onInit(fun x -> x.node.IsDefault <- true)
                .Click(fun _ ->
                    let nextId =
                        match  todoList.Value.items |> List.map (fun x -> x.key) |> List.sortDescending with
                        | [] -> 0
                        | x::_ -> x + 1
                    let newItem = { text = itemName.Value; isDone = false; key = nextId }
                    do setItems (newItem :: todoList.Value.items)
                    do itemName.Reset()) {
                        "Add Item"
                }
            TextBox.BindText(itemName)
        }

        VStack.Margin(4) {
            for item in todoList.Value.items do
                DockPanel {
                    Button
                        .IsEnabled(item.isDone)
                        .DockPanel().Dock(Dock.Right)
                        .Click(fun _ -> setItems (todoList.Value.items |> List.except [item]))
                        { "Remove" }
                    CheckBox
                        .BindIsChecked(item.isDone, fun value -> item.isDone <- value)
                    TextBlock
                        .VerticalAlignment(VA.Center)
                        .TextTrimming(TextTrimming.CharacterEllipsis)
                        .Text(item.text)
                }
        }
    }
}


let window = Interactive.createWindow 300. 500.
let videApp = Interactive.showView todoListView window
```

![Todo List in Avalonia](images/todoList_Avalonia.png)


## Web Development with Fable

Wanna use the fresh approach of writing web apps with F#, Fable and Vide? Then go directly [here](/docs/vide.ui.fable/getting-started)!

There's a [sample app](https://github.com/vide-collabo/fiddles-n-showcase/tree/main/Vide4Fable) that shows how to use Vide for Fable!

## Desktop / Mobile Development with Avalonia

Wanna use the fresh approach of writing desktop or mobile apps based on Avalonia? Then go directly [here](/docs/vide.ui.avalonia/getting-started)!

There's a [sample app](https://github.com/vide-collabo/fiddles-n-showcase/blob/main/Vide4Avalonia/Vide4Avalonia_todoList.fsx) that shows how to use Vide for Avalonia!

## Tech Background

The basic idea of Vide is derived from [Digital Signal Processing with F#](https://github.com/schlenkr/applied_fsharp_challenge/blob/master/docs/index.md), which was @SchlenkR's submission to the [F# Applied Challenge](https://sergeytihon.com/2019/05/31/f-weekly-22-2019-winners-of-applied-f-challenge/). If you are interested in the core concept of how Vide is working, this might be a good starting point.

Also, you can have a look at [LocSta](https://github.com/fsprojects/LocSta/blob/master/README.md), which is an experimental F# library for describing signal flows using the Vide principle.

