---
title: "Introduction"
description: "TODO"
lead: ""
date: 2020-10-13T15:21:01+02:00
lastmod: 2020-10-13T15:21:01+02:00
draft: false
images: []
menu:
  docs:
    parent: "prologue"
weight: 100
toc: true
---

{{< alert icon="🚨" >}}
**Vide for Fable** and this documentation are still pre-release!
{{< /alert >}}


![A ToDo-List in Vide](images/todoList.png)

```fsharp

type TodoItem = { name: string; mutable isDone: bool }
type TodoList = { items: TodoItem list }

let view = vide {
    let! todoList = Vide.ofMutable { items = [] }

    h1.class'("title") { "TODO List" }
    div {
        let! itemName = Vide.ofMutable ""

        p {
            let addItem () =
                let newItem = { name = itemName.Value; isDone = false }
                do
                    todoList.Value <- { todoList.Value with items = newItem :: todoList.Value.items }
                    itemName.Reset()

            input
                .type'("text")
                .value(itemName.Value)
                .oninput(fun x -> itemName.Value <- x.node.value)

            button
                .disabled(String.IsNullOrWhiteSpace(itemName.Value))
                .onclick(fun _ -> addItem())
                {
                    "Add Item"
                }
        }
    }

    div {
        for item in todoList.Value.items do
            div.class'("flex-row") {
                p { item.name }
                input
                    .type'("checkbox")
                    .checked'(item.isDone)
                    .oninput(fun x -> item.isDone <- x.node.``checked``)
            }
    }
}
```
